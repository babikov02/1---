﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _1С_Франчайзи_Вятка
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities1C : DbContext
    {
        public Entities1C()
            : base("name=Entities1C")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AgentSet> AgentSet { get; set; }
        public virtual DbSet<ClientSet> ClientSet { get; set; }
        public virtual DbSet<DealSet> DealSet { get; set; }
        public virtual DbSet<ItsSet> ItsSet { get; set; }
        public virtual DbSet<ProgramProductSet> ProgramProductSet { get; set; }
        public virtual DbSet<UsersSet> UsersSet { get; set; }
    }
}
