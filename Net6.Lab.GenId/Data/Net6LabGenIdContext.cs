#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Net6.Lab.GenId;

namespace Net6.Lab.GenId.Data
{
    public class Net6LabGenIdContext : DbContext
    {
        public Net6LabGenIdContext (DbContextOptions<Net6LabGenIdContext> options)
            : base(options)
        {
        }

        public DbSet<Net6.Lab.GenId.WeatherForecast> WeatherForecast { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //利用值產生器來建立 SequentialGuidValueGenerator
            modelBuilder.Entity<WeatherForecast>(c => c.Property("Id").HasValueGenerator<SequentialGuidValueGenerator>());
        }

    }
}
