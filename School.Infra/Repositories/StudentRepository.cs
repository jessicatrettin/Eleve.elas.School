using Microsoft.EntityFrameworkCore;

namespace School.Infra.Repositories
{
    public class StudentRepository : BaseRepository
    {
        public StudentRepository(DbContext context) : base(context)
        {
        }
    }
}
