namespace School.Model.Entities
{

    public class Course : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }

        public long TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        private (bool, string?) AddStudent(Enrollment enrollment)
        {
            if (Enrollments.Count < 30)
            {
                Enrollments.Add(enrollment);
                return (true, null);
            }

            return (false, "A quantidade de alunos para esse curso foi atingida.");
        }
    }
}
