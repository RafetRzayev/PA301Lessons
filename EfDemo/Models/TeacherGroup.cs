namespace EfDemo.Models
{
    internal class TeacherGroup
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public int GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
