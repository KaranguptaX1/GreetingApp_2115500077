﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ModelLayer.Model
{
    public class GreetingModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
