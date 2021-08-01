using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoVinos.Models;

namespace ApiVinos.Data
{
    public class ApiVinosContext : DbContext
    {
        public ApiVinosContext (DbContextOptions<ApiVinosContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoVinos.Models.Cliente> Cliente { get; set; }

        public DbSet<ProyectoVinos.Models.Pedido> Pedido { get; set; }

        public DbSet<ProyectoVinos.Models.Vino> Vino { get; set; }
    }
}
