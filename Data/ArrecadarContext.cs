using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Arrecadar.Models;

namespace Arrecadar.Data
{
    public class ArrecadarContext : DbContext
    {
        public ArrecadarContext (DbContextOptions<ArrecadarContext> options)
            : base(options)
        {
        }

        public DbSet<Arrecadar.Models.Usuario> Usuario { get; set; } = default!;
        public DbSet<Arrecadar.Models.Ong> Ong { get; set; } = default!;
        public DbSet<Arrecadar.Models.Campanha> Campanha { get; set; } = default!;
        public DbSet<Arrecadar.Models.Doacao> Doacao { get; set; } = default!;
        public DbSet<Arrecadar.Models.Atualizacao_Campanha> Atualizacao_Campanha { get; set; } = default!;
    }
}
