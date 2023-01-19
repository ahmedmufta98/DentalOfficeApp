using DentalOffice.Entities.dbContext;
using Microsoft.EntityFrameworkCore;

namespace DentalOffice.API.Helper
{
    public static class DbSeed
    {
        public static void SeedDB(AppDbContext context)
        {
            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
