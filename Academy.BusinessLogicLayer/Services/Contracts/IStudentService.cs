using Academy.BusinessLogicLayer.Dtos;

namespace Academy.BusinessLogicLayer.Services.Contracts;

public interface IStudentService
{
    List<StudentDto> GetStudents();
    StudentDto? GetStudentById(int id);
    void AddStudent(CreateStudentDto createStudentDto);
    void UpdateStudent(int id, UpdateStudentDto updateStudentDto);
    void DeleteStudent(int id);
}