using System.Collections.Generic;

namespace NotesWindowsFormsApp
{
    interface ITagRepository
    {
        List<Tag> GetAll();
        void Add(Tag tag);
        Tag FindByText(string text);
        void Delete(Tag tagToDelete);
    }
}
