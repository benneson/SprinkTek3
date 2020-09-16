using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace SprintTek.EntityFrameworkCore
{
    public static class SprintTekDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SprintTekDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<SprintTekDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}