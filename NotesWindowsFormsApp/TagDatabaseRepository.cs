using System;
using System.Collections.Generic;
using System.Linq;

namespace NotesWindowsFormsApp
{
    public class TagDatabaseRepository : ITagRepository
    {
        private readonly TaskContext context;
        public TagDatabaseRepository(IServiceProvider provider)
        {
            this.context = (TaskContext)provider.GetService(typeof(TaskContext));
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
        public void Delete(Tag tagToDelete)
        {
            context.Tags.Remove(tagToDelete);
            context.SaveChanges();
        }

    }
}
