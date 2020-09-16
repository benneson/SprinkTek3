using SprintTek.EntityFrameworkCore;

namespace SprintTek.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly SprintTekDbContext _context;

        public InitialHostDbBuilder(SprintTekDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
            new InitialPeopleCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
