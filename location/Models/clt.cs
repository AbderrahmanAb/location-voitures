using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace location.Models
{
    
    public class clt
    {
        [Key] // ==> PRIMARY KEY
        public int CID { get; set; }
        [Required]
        // ==> NOT NULL
        [MinLength(4), MaxLength(100)]
        public string Nom { get; set; }
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string AdresseMail { get; set; }
        [Required]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        public string MotDePasse { get; set; }
        [Required]
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateNaissance { get; set; }

        public String CIN { get; set; }

        public String permis { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageCin { get; set; }
        [NotMapped]
        public HttpPostedFileBase Imagepermis { get; set; }
        public Boolean IsAdmin { get; set; }

        public clt()
        {
            IsAdmin = true;

        }
    }
}