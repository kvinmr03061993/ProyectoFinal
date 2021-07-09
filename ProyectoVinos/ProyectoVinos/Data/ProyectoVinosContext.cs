﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoVinos.Models;

namespace ProyectoVinos.Data
{
    public class ProyectoVinosContext : DbContext
    {
        public ProyectoVinosContext (DbContextOptions<ProyectoVinosContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoVinos.Models.Cliente> Cliente { get; set; }
    }
}