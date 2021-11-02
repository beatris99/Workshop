using ApiNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNotes.Services
{
    public interface IOwnerCollectionService: ICollectionService<Owner>
    {
        Task<List<Owner>> GetOwnerByOwnerId(Guid ownerId);
    }
}
