using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace location.Models
{
    public class Modele
    {
        [Key]
        public int modelID { get; set; }
        [StringLength(50)]
        public String nom { get; set; }
        [StringLength(50)]
        public String serie { get; set; }
    }

}