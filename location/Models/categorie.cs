using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace location.Models
{
    public class categorie
    {
        public enum TypeCategorie
        {
            DEFAULT,
            Citadine,
            Urban,
            Break,
            Berlin
        }
        [Key]
        public int CategorieID { get; set;}
        [Required]
        public TypeCategorie? type { get; set; }


    }
}