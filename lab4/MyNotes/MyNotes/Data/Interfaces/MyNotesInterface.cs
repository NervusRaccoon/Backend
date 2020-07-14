using MyNotes.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyNotes.Data.Interfaces
{
    public interface MyNotesInterface
    {
        IEnumerable<Note> GetAll();
        void Add(Note note);
    }
}