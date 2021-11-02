using ApiNotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNotes.Services
{
    public interface INoteCollectionService: ICollectionService<Note>
    {
        Task<List<Note>> GetNotesByOwnerId(Guid ownerId);
    }
}
