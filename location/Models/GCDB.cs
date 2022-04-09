using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace location.Models
{
    public class GCDB: DbContext
    {
        public GCDB() : base("name=GCCS")
        {

        }
       
        public DbSet<clt> clts { get; set; }
        public DbSet<categorie> categories { get; set; }

        public DbSet<Modele> Modeles { get; set; }

        public DbSet<voiture> voitures { get; set; }
        public DbSet<locatvoiture> locatvoitures { get; set; }
    }
}