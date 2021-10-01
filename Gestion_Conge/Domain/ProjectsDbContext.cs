
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestion_Conge.Domain
{
   
    public class ProjectsDbContext : DbContext
    {
        public ProjectsDbContext(DbContextOptions<ProjectsDbContext> options) : base(options)
        { }
        public DbSet<Collaborateur> Collaborateurs { get; set; }
        public DbSet<conge> conges { get; set; }
        public DbSet<role> roles { get; set; }
        public DbSet<statusConge> statusConges { get; set; }
        public DbSet<typeConge> typeConges { get; set; }
        public DbSet<fonctionCollaborateur> fonctionCollaborateurs { get; set; }

    }
}
