
namespace ContratosOP1.Data
{
    using ContratosOP1.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
   

    public partial class ContratosContainer : DbContext
    {
        public ContratosContainer(DbContextOptions<ContratosContainer> options)
            : base(options)
        {
        }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Contratacion> Contrataciones { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<TipoDeContrato> TipoDeContratos { get; set; }
        public DbSet<Unidad> Unidades { get; set; }
    }
}
