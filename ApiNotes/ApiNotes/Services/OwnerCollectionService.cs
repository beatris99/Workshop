using ApiNotes.Models;
using ApiNotes.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNotes.Services
{
    public class OwnerCollectionService : IOwnerCollectionService
    {
        private readonly IMongoCollection<Owner> _owner;
        

        public OwnerCollectionService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _owner = database.GetCollection<Owner>(settings.NoteCollectionName);
        }



        public async Task<List<Owner>> GetAll()
        {
            var result = await _owner.FindAsync(owner => true);
            return result.ToList();
        }


        public async Task<bool> Create(Owner owner)
        {
            await _owner.InsertOneAsync(owner);
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _owner.DeleteOneAsync(owner => owner.Id == id);
            if (!result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<Owner> Get(Guid id)
        {
            return (await _owner.FindAsync(owner => owner.Id == id)).FirstOrDefault();
        }

        public async Task<bool> Update(Guid id, Owner owner)
        {
            owner.Id = id;
            var result = await _owner.ReplaceOneAsync(note => note.Id == id, owner);
            if (!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                await _owner.InsertOneAsync(owner);
                return false;
            }

            return true;
        }

        public async Task<List<Owner>> GetOwnerByOwnerId(Guid ownerId)
        {
            return (await _owner.FindAsync(owner => owner.Id == ownerId)).ToList();
        }
    }
}
