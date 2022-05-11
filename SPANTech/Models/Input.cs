using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SPANTech.Models
{
    public class Inputs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        [Required]
        public int State { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Display(Name ="No. of new cases Today")]
        [Required]
        public int New_Cases { get; set; }
        [Display(Name = "No. of Recovery Today")]
        [Required]
        public int Recoverys { get; set; }
        [Display(Name = "No. of Deaths Today")]
        [Required]
        public int Deaths { get; set; }
        [NotMapped]
        public string StateName { get; set; }
    }
}