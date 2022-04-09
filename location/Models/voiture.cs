using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace location.Models
{
    public class voiture
    {
        public enum TypeCarburant
        {
            ParDefaut,
            Essance,
            Diesel
        }
        [Key]
        public int voitureID { get; set; }
        public String numero_matriculation { get; set; }
        [Required]
        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date_mise_circulation { get; set; }
        [Required]
        [Range(100, 600)]
        public int prix_Par_Jour { get; set; }
        [Required]
        public TypeCarburant? carburant { get; set; }
        public String image { get; set; }
        public int categorieID { get; set; }

        public virtual categorie Categorie { get; set; }
        public int modelID { get; set; }
        public virtual Modele Modele { get; set; }
        [NotMapped]
        public HttpPostedFileBase Imagevoiture { get; set; }

    }
}