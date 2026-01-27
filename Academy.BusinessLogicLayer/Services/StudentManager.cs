using Academy.BusinessLogicLayer.Services.Contracts;
using Academy.BusinessLogicLayer.Dtos;
using Academy.DataAccessLayer.Repositories.Contracts;
using Academy.DataAccessLayer.Models;

namespace Academy.BusinessLogicLayer.Services;

public class StudentManager : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentManager(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public void AddStudent(CreateStudentDto createStudentDto)
    {
        _studentRepository.Add(new Student
        {
            FirstName = createStudentDto.FirstName,
            LastName = createStudentDto.LastName,
            GroupId = createStudentDto.GroupId
        });
    }

    public void DeleteStudent(int id)
    {
        _studentRepository.Delete(id);
    }

    public StudentDto? GetStudentById(int id)
    {
        var student = _studentRepository.GetById(id);

        if (student is null)
        {
            return null;
        }

        return new StudentDto
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            GroupName = student.Group?.Name
        };
    }

    public List<StudentDto> GetStudents()
    {
        var students = _studentRepository.GetAll();

        return students.Select(student => new StudentDto
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            GroupName = student.Group?.Name,
            GroupId = student.GroupId
        }).ToList();
    }

    public void UpdateStudent(int id, UpdateStudentDto updateStudentDto)
    {
        var student = new Student
        {
            FirstName = updateStudentDto.FirstName,
            LastName = updateStudentDto.LastName,
            GroupId = updateStudentDto.GroupId
        };

        _studentRepository.Update(id, student);
    }
}