﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Address : IValidatableObject
    {
        public int AddressId { get; set; }        
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string PostalCode { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}