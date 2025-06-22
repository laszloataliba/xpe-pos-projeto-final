using Microsoft.EntityFrameworkCore;
using XPE.Desafio.Final5.API.Model.Domains;

namespace XPE.Desafio.Final5.API.Model.Respositories.Data.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) :
            base(options)
        { }

        public DbSet<Product> Products { get; set; }
    }
}
