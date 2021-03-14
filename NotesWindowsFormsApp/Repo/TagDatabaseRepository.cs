using NotesWindowsFormsApp.Context;
using NotesWindowsFormsApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace NotesWindowsFormsApp.Repo
{
    public class TagDatabaseRepository : ITagRepository
    {
        private readonly TaskContext context;
        public TagDatabaseRepository(TaskContext context)
        {
            this.context = context;
        }
        public void Add(Tag tag)
        {
            context.Tags.Add(tag);
            context.SaveChanges();
        }
        public Tag FindByText(string text)
        {
            return context.Tags.FirstOrDefault(t => t.Text == text);
        }
        public List<Tag> GetAll()
        {
            var listOfTags = new List<Tag>();
            foreach (var t in context.Tags)
            {
                listOfTags.Add(t);
            }
            return listOfTags;
        }
        public void Delete(string textOfTagToDelete)
        {
            var tagToDelete = FindByText(textOfTagToDelete);
            if (tagToDelete != null)
            {
                context.Tags.Remove(tagToDelete);
                context.SaveChanges();
            }
        }

    }
}
