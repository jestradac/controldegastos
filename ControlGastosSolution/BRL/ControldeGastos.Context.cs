﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BRL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class db_ControlGastosEntities1 : DbContext
    {
        public db_ControlGastosEntities1()
            : base("name=db_ControlGastosEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_Concepto> tbl_Concepto { get; set; }
        public virtual DbSet<tbl_Cuenta> tbl_Cuenta { get; set; }
        public virtual DbSet<tbl_Transaccion> tbl_Transaccion { get; set; }
        public virtual DbSet<tbl_Usuario> tbl_Usuario { get; set; }
    }
}