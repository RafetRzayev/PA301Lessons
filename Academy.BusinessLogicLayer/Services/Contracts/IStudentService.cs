using Academy.BusinessLogicLayer.Dtos;
using Academy.DataAccessLayer.Models;

namespace Academy.BusinessLogicLayer.Services.Contracts;

public interface IStudentService : ICrudService<Student, StudentDto, CreateStudentDto, UpdateStudentDto>
{
}