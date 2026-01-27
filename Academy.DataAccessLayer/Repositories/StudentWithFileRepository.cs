//using Academy.DataAccessLayer.Models;
//using Academy.DataAccessLayer.Repositories.Contracts;

//namespace Academy.DataAccessLayer.Repositories
//{
//    public class StudentWithFileRepository : IStudentRepository
//    {
//        private const string PATH = "data\\student.txt";
//        public void Add(Student entity)
//        {
//            File.AppendAllLines(PATH, [entity.ToString()]);
//        }

//        public void Delete(int id)
//        {
//            var students = GetAll();
//            var existingStudent = students.SingleOrDefault(x => x.Id == id);
//            if (existingStudent != null)
//            {
//                students.Remove(existingStudent);
//                var lines = students.Select(g => g.ToString());
//                File.WriteAllLines(PATH, lines);
//            }
//            else
//            {
//                throw new Exception("Student not found");
//            }
//        }

//        public List<Student> GetAll()
//        {
//            //bad practise, dont alone in home
//            var groupRepository = new GroupWithFileRepository(this);
//            var groups = groupRepository.GetAll();

//            var students = File.ReadAllLines(PATH);
//            List<Student> result = new List<Student>();
//            foreach (var student in students)
//            {
//                var id = int.Parse(student.Substring(0, 6).Trim());
//                var firstName = student.Substring(6, 10).Trim();
//                var lastName = student.Substring(16, 10).Trim();
//                var groupId = int.Parse(student.Substring(26).Trim());

//                var group = groups.Find(g => g.Id == groupId);
//                result.Add(new Student
//                {
//                    Id = id,
//                    FirstName = firstName,
//                    LastName = lastName,
//                    GroupId = groupId,
//                    Group = group
//                });
//            }

//            return result;
//        }

//        public Student? GetById(int id)
//        {
//            var students = GetAll();
//            var student = students.Find(x => x.Id == id);

//            return student;
//        }

//        public List<Student> GetStudentsWithStudents()
//        {
//            throw new NotImplementedException();
//        }

//        public void Update(int id, Student entity)
//        {
//            var students = GetAll();
//            var existingStudent = students.SingleOrDefault(x => x.Id == id);
//            if (existingStudent != null)
//            {
//                existingStudent.FirstName = entity.FirstName;
//                existingStudent.LastName = entity.LastName;
//                existingStudent.GroupId = entity.GroupId;
//                var lines = students.Select(g => g.ToString());
//                File.WriteAllLines(PATH, lines);
//            }
//            else
//            {
//                throw new Exception("Student not found");
//            }
//        }
//    }

//}