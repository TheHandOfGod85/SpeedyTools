using Microsoft.EntityFrameworkCore;

namespace SpeedyTools.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
    }
}
