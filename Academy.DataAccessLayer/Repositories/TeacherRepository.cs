//using Academy.DataAccessLayer.DataContext;
//using Academy.DataAccessLayer.Models;
//using Academy.DataAccessLayer.Repositories.Contracts;

//namespace Academy.DataAccessLayer.Repositories;

//public class TeacherRepository : ITeacherRepository
//{
//    public void Add(Teacher entity)
//    {
//        AcademyDataBase.Teachers.Add(entity);
//    }

//    public void Delete(int id)
//    {
//        var teacher = GetById(id);

//        if (teacher is not null)
//        {
//            AcademyDataBase.Teachers.Remove(teacher);
//            return;
//        }

//        throw new Exception("Teacher not found");
//    }

//    public List<Teacher> GetAll()
//    {
//        return AcademyDataBase.Teachers;
//    }

//    public Teacher? GetById(int id)
//    {
//        var teacher = AcademyDataBase.Teachers.SingleOrDefault(t => t.Id == id);

//        return teacher;
//    }

//    public void Update(int id, Teacher entity)
//    {
//        var existingTeacher = GetById(id);

//        if (existingTeacher is not null)
//        {
//            existingTeacher.FirstName = entity.FirstName;
//            existingTeacher.LastName = entity.LastName;
//            return;
//        }

//        throw new Exception("Teacher not found");
//    }
//}
