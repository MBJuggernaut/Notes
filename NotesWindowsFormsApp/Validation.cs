using NotesWindowsFormsApp;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Validation
{
    public static List<string> CheckTask(Task task)
    {
        var validationResults = new List<ValidationResult>();
        var context = new ValidationContext(task, null, null);
        List<string> errors = new List<string>();
        if (!Validator.TryValidateObject(task, context, validationResults, true))
        {
            foreach (var error in validationResults)
            {
                errors.Add(error.ErrorMessage);
            }
        }
        return errors;
    }
}
