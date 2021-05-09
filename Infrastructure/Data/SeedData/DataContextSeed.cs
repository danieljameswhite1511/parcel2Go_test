using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace Infrastructure.SeedData
{
    public class DataContextSeed
    {

        private static void LoadTable<T>(T Entity, DataContext context, string fileName) where T : BaseEntity
        {
             var set = context.Set<T>();
             var jsonDataFile = File.ReadAllText($"../Infrastructure/Data/SeedData/{fileName}.json");
             var data = JsonSerializer.Deserialize<List<T>>(jsonDataFile);

             if(!set.Any()){
                 
             foreach (var row in data)
                    {
                        set.Add(row);
                    }
             }
            context.SaveChanges();
        }


        
        public static async Task  SeedAsync(DataContext context, ILoggerFactory loggerFactory)
        {
            try
            {
               LoadTable<Tenant>(new Tenant(), context, "tenants" );
               LoadTable<Menu>(new Menu(), context, "menu" );
               LoadTable<MenuItem>(new MenuItem(), context, "menuItem" );

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<DataContextSeed>();
                logger.LogError(ex.Message);
            }

        }

    }
}