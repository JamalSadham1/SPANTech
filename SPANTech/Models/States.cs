using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SPANTech.Models
{
    public class States
    {
        [Key]
        public int ID { get; set; }
        public string StateName { get; set; }
    }
}