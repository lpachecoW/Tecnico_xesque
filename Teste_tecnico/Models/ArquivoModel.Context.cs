﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Teste_tecnico.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class refatoradoEntitiesModel : DbContext
    {
        public refatoradoEntitiesModel()
            : base("name=refatoradoEntitiesModel")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tb_documentos> tb_documentos { get; set; }
        public virtual DbSet<tb_fileupload> tb_fileupload { get; set; }
    }
}