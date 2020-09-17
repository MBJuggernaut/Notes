﻿using System;

namespace NotesWindowsFormsApp
{
    class EveryMonthUpdateRepository
    {
        readonly string timetoupdatepath = "timetoupdate.json";
        public DateTime Get()
        {
            DateTime time;
            var stringFromFile = FileProvider.CreateOrGet(timetoupdatepath);

            if (stringFromFile != "")
                time = DateTime.Parse(stringFromFile);
            else time = DateTime.Now.AddMonths(1);

            return time;
        }
        public void Update(DateTime newtime)
        {
            FileProvider.Replace(timetoupdatepath, newtime.ToString());
        }
    }
}

