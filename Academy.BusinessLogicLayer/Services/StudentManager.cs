using Academy.BusinessLogicLayer.Services.Contracts;
using Academy.BusinessLogicLayer.Dtos;
using Academy.DataAccessLayer.Repositories.Contracts;
using Academy.DataAccessLayer.Models;
using AutoMapper;

namespace Academy.BusinessLogicLayer.Services;

public class StudentManager : CrudManager<Student, StudentDto, CreateStudentDto, UpdateStudentDto>, IStudentService
{
    public StudentManager(IRepository<Student> repository) : base(repository)
    {
    }
}