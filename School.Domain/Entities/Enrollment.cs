using School.Model.Entities.Enums;

namespace School.Model.Entities
{
    public class Enrollment : BaseEntity
    {
        public DateTime EnrollmentDate { get; set; }
        public EnrollmentStatus Status { get; set; }

        public long StudentId { get; set; }
        public virtual Student Student { get; set; }

        public long CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
