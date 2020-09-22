using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesWindowsFormsApp
{
    class ExitTimeRepository
    {
        readonly string timepath = "timeofexit.txt";
        public DateTime Get()
        {
            DateTime time;
            var stringFromFile = FileProvider.CreateOrGet(timepath);

            if (stringFromFile != "")
                time = DateTime.Parse(stringFromFile);
            else time = DateTime.Now;

            return time;
        }
        public void Update(DateTime newtime)
        {
            FileProvider.Replace(timepath, newtime.ToString());
        }
    }
}
