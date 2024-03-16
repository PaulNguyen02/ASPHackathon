using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebEnvironment_Hackathon_GaMo.Context
{
    public class WebEnviDbContextFactory : IDesignTimeDbContextFactory<WebEnviDbContext>

    {
        public WebEnviDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var conectionString = configuration.GetConnectionString("WebEnvi");

            var optionBuilder = new DbContextOptionsBuilder<WebEnviDbContext>();
            optionBuilder.UseSqlServer(conectionString);

            return new WebEnviDbContext(optionBuilder.Options);

        }
    }
}
