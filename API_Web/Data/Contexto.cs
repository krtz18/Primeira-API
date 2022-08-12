using Microsoft.EntityFrameworkCore;

namespace API_Web.Data
{
    public class Contexto : DbContext
    {


        //protected readonly IConfiguration Configuration;

        //public Contexto(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    // connect to sql server with connection string from app settings
        //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

        //}

        public Contexto(DbContextOptions<Contexto> options)
                : base(options)
            { }


            public DbSet<TB_CADASTRO> TB_CADASTRO { get; set; }
    }

}

