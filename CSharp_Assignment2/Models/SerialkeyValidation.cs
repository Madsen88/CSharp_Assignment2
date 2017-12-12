using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_Assignment2.Models
{
    public class SerialkeyValidation : ValidationAttribute
    {
        private string[] _SerialkeyList;
        private const string SERIALKEYPATH = @"Models/SerialKeys.txt";

        public SerialkeyValidation()
        {
            _SerialkeyList = GetSerialKeysFromFile(SERIALKEYPATH);
        }

        protected override ValidationResult IsValid(object value, System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            if (value != null)
            {
                //Testing purposes
                var isitvalid = !_SerialkeyList.Contains(value);
                if (isitvalid)
                    return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }

        private string[] GetSerialKeysFromFile(string path)
        {
            var stream = File.ReadAllLines(path);
            stream = stream[0].Split(';');
            return stream;

        }

        private void IsTheKeyUsedForAnotherSubmission()
        {
            // Not implemented yet
        }
    }
}
