﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Validation
{
    public static List<string> Check<T>(T obj)
        where T: class
    {
        var validationResults = new List<ValidationResult>();
        var context = new ValidationContext(obj);
        var errors = new List<string>();
        if (!Validator.TryValidateObject(obj, context, validationResults, true))
        {
            foreach (var error in validationResults)
            {
                errors.Add(error.ErrorMessage);
            }
        }
        return errors;
    }
}
