//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projekt2.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProjektEntities : DbContext
    {
        public ProjektEntities()
            : base("name=ProjektEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Druzyna> Druzyna { get; set; }
        public virtual DbSet<Kierownik> Kierownik { get; set; }
        public virtual DbSet<Licencja> Licencja { get; set; }
        public virtual DbSet<Masazysta> Masazysta { get; set; }
        public virtual DbSet<Ogloszenia> Ogloszenia { get; set; }
        public virtual DbSet<Pozycja> Pozycja { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Trener> Trener { get; set; }
        public virtual DbSet<Zawodnik> Zawodnik { get; set; }
    }
}
