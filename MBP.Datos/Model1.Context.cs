﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MBP.Datos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MyBattlePongEntities : DbContext
    {
        public MyBattlePongEntities()
            : base("name=MyBattlePongEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cuenta> Cuenta { get; set; }
        public virtual DbSet<Dispositivo> Dispositivo { get; set; }
        public virtual DbSet<Jugador> Jugador { get; set; }
        public virtual DbSet<Moderador> Moderador { get; set; }
        public virtual DbSet<Nave> Nave { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<Partida_Nave> Partida_Nave { get; set; }
        public virtual DbSet<PartidaHistorica> PartidaHistorica { get; set; }
        public virtual DbSet<PartidaVivo> PartidaVivo { get; set; }
        public virtual DbSet<Poder> Poder { get; set; }
        public virtual DbSet<Tablero_Virtual_1> Tablero_Virtual_1 { get; set; }
        public virtual DbSet<Tablero_Virtual_2> Tablero_Virtual_2 { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Partida> Partida { get; set; }
        public virtual DbSet<Estadistica> Estadistica { get; set; }
    }
}
