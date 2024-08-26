using School.Model.Entities;
using School.Model.Entities.Enums;

namespace School.Model.Dtos
{
    public class EnrollmentDto : BaseDto
    {
        public DateTime EnrollmentDate { get; set; }
        public EnrollmentStatus Status { get; set; }
        public virtual CourseDto Course { get; set; }

        public EnrollmentDto(Enrollment enrollment)
        {
            Id = enrollment.Id;
            EnrollmentDate = enrollment.EnrollmentDate;
            Status = enrollment.Status;
            Course = new CourseDto(enrollment.Course);
        }
    }
}
