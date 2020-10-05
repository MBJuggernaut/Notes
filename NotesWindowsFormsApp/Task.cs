using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotesWindowsFormsApp
{
    public class Task : BaseEntity
    {
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime FirstDate { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 5)]
        public string Time { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime AlarmTime { get; set; }

        [Required(ErrorMessage = "Поле примечания не должно оставаться пустым. Примечание к заданию должно содержать от 3-х до 50-ти символов.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Примечание к заданию должно содержать от 3-х до 50-ти символов.")]
        public string Text { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 5)]
        public string Repeating { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 5)]
        public string Alarming { get; set; }

        public virtual List<Tag> Tags { get; set; }
        public virtual List<TaskDate> Dates { get; set; }


        public Task()
        {
            Tags = new List<Tag>();
            Dates = new List<TaskDate>();
        }
        public DateTime PickNextDate(DateTime date)
        {
            if (Dates.Count > 1)
            {
                for (int i = 0; i < Dates.Count - 1; i++)
                {
                    if (Dates[i].Day == date)
                    {
                        return Dates[i + 1].Day;
                    }
                }
            }
            return DateTime.MinValue;
        }
        public void CountNextAlarmTime()
        {
            var date = FirstDate;
            DateTime timeOfStart = date.Add(DateTime.Parse(Time).TimeOfDay);
            var supposedTime = DateTime.MinValue;

            var alarmingParts = Alarming.Split(' ');
            var count = Int32.Parse(alarmingParts[0]);
            var span = alarmingParts[1];

            while (true)
            {
                switch (span)
                {
                    case "мин.":
                        supposedTime = timeOfStart.AddMinutes(-count);
                        break;
                    case "ч.":
                        supposedTime = timeOfStart.AddHours(-count);
                        break;
                    case "д.":
                        supposedTime = timeOfStart.AddDays(-count);
                        break;
                    case "нед.":
                        supposedTime = timeOfStart.AddDays(-7 * count);
                        break;
                    case "мес.":
                        supposedTime = timeOfStart.AddMonths(-count);
                        break;
                    case "г.":
                        supposedTime = timeOfStart.AddYears(-count);
                        break;
                }

                if (DateTime.Compare(supposedTime, DateTime.Now) > 0)
                    break;

                date = PickNextDate(date);

                if (date == DateTime.MinValue)
                {
                    supposedTime = date;
                    break;
                }

                timeOfStart = date.Add(DateTime.Parse(Time).TimeOfDay);
            }
            AlarmTime = supposedTime;
        }
        public List<string> Validate()
        {
           return Validation.Check(this);
        }
    }
}
