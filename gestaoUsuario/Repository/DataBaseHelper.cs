using gestaoUsuario.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestaoUsuario.Repository
{
    internal static class DataBaseHelper
    {
        public static void ModelCreate(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);
        }

        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User()
                {
                    Id = 1,
                    Name = "Elenilson",
                    Avatar = "Perfil Negocio",
                    Email = "elenilson@gmail.com",
                    City = "Salinopolis"
                }
            });
        }
    }
}
