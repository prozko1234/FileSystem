using IdeoTask.Services.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdeoTask.EntityFramework.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider) {
            using (var context = new ApplicationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationContext>>())) {
                if (context.Catalogs.Any())
                {
                    return;   // DB has been seeded
                }

                context.Catalogs.AddRange(
                    new Catalog
                    {
                        Name = "Root",
                        ParentCatalog = null,
                        IsLeaf = false
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
