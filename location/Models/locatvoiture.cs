using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace location.Models
{
    public class locatvoiture
    {
        [Key]
        public int LocationID { get; set; }
        [Required]
        [Display(Name = "Date de début")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "Date de fin")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public int voitureID { get; set; }
        public virtual voiture voiture { get; set; }

        public int cltID { get; set; }
        public virtual clt clt { get; set; }

    }
}