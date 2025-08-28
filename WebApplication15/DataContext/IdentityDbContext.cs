using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Privacy_Web_App.DataContext
{
    public class IdDbContext : IdentityDbContext
    {

        public IdDbContext(DbContextOptions<IdDbContext> options):base(options)
        {
            
        }
    }
}
