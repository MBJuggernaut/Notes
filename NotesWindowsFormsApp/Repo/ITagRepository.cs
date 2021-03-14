using NotesWindowsFormsApp.Models;
using System.Collections.Generic;

namespace NotesWindowsFormsApp.Repo
{
    public interface ITagRepository
    {
        List<Tag> GetAll();
        void Add(Tag tag);
        Tag FindByText(string text);
        void Delete(string text);
    }
}
