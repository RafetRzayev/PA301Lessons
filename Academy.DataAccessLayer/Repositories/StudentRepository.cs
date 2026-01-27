//using Academy.DataAccessLayer.DataContext;
//using Academy.DataAccessLayer.Models;
//using Academy.DataAccessLayer.Repositories.Contracts;

//namespace Academy.DataAccessLayer.Repositories;

//public class StudentRepository : IStudentRepository
//{
//    public void Add(Student entity)
//    {
//        AcademyDataBase.Students.Add(entity);
//    }

//    public void Delete(int id)
//    {
//       var student = GetById(id);

//        if (student is not null)
//        {
//            AcademyDataBase.Students.Remove(student);

//            return;
//        }

//        throw new Exception("Student not found");
//    }

//    public List<Student> GetAll()
//    {
//        return AcademyDataBase.Students;
//    }

//    public Student? GetById(int id)
//    {
//        var student = AcademyDataBase.Students.SingleOrDefault(s => s.Id == id);

//        return student;
//    }

//    public void Update(int id, Student student)
//    {
//        var existingStudent = GetById(id);

//        if (existingStudent is not null)
//        {
//            existingStudent.FirstName = student.FirstName;
//            existingStudent.LastName = student.LastName;
//            existingStudent.Group = student.Group ?? existingStudent.Group;

//            return;
//        }

//        throw new Exception("Student not found");
//    }
//}
