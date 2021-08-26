﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.Models
{
    public class Person
    {
        [Key]
        public string NIK { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Phone]
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public int Salary { get; set; }
        [Required]
        public string Email { get; set; }
        public enum Gender { 
            Male,
            Female
        }
        public Gender gender { get; set; }

    }
}
