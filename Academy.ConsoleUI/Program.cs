using Academy.BusinessLogicLayer.Dtos;
using Academy.BusinessLogicLayer.Mapping;
using Academy.BusinessLogicLayer.Services;
using Academy.DataAccessLayer.DataContext;
using Academy.DataAccessLayer.Models;
using Academy.DataAccessLayer.Repositories;
using Academy.DataAccessLayer.Repositories.Contracts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Academy.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var appDbContext = new AcademyDbContext();
            IRepository<Student> studentRepository = new StudentWithEfRepository(appDbContext);
            IRepository<Group> groupRepository = new GroupWithEfRepository(appDbContext);

            var studentManager = new StudentManager(studentRepository);
            var groupManager = new GroupManager(groupRepository);

            Dictionary<string, Action> menuCommand = new Dictionary<string, Action>();
            menuCommand.Add("1", PrintStudentMenu);
            menuCommand.Add("2", PrintGroupMenu );
            menuCommand.Add("3", PrintTeacherMenu);
            menuCommand.Add("4", Exit);

            while (true)
            {
                PrintMenu();
                Console.Write("Select an option: ");
                string choice = Console.ReadLine()!;
                if (choice == "4")
                {
                    Exit();
                    break;
                }
                if (menuCommand.ContainsKey(choice))
                {
                    menuCommand[choice].Invoke();

                    if (choice == "1")
                    {
                        while (true)
                        {
                            Console.Write("Select an option: ");
                            string studentChoice = Console.ReadLine()!;
                            if (studentChoice == "5") break;
                            switch (studentChoice)
                            {
                                case "1":
                                    ListStudents(studentManager);
                                    break;
                                case "2":
                                    AddStudent(studentManager);
                                    break;
                                case "3":
                                    UpdateStudent(studentManager);
                                    break;
                                case "4":
                                    DeleteStudent(studentManager);
                                    break;
                                default:
                                    Console.WriteLine("Invalid option. Please try again.");
                                    break;
                            }
                        }
                    }
                    else if (choice == "2")
                    {
                        while (true)
                        {
                            Console.Write("Select an option: ");
                            string groupChoice = Console.ReadLine()!;
                            if (groupChoice == "5") break;
                            switch (groupChoice)
                            {
                                case "1":
                                    PrintGroups(groupManager);
                                    break;
                                case "2":
                                    AddGroup(groupManager);
                                    break;
                                case "3":
                                    UpdateGroup(groupManager);
                                    break;
                                case "4":
                                    DeleteGroup(groupManager);
                                    break;
                                default:
                                    Console.WriteLine("Invalid option. Please try again.");
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("=== Student Management System ===");
            Console.WriteLine("1. Students");
            Console.WriteLine("2. Groups");
            Console.WriteLine("3. Teachers");
            Console.WriteLine("4. Exit");
        }

        private static void PrintStudentMenu()
        {
            Console.WriteLine("1. List Students");
            Console.WriteLine("2. Add Student");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Back to Main Menu");
        }

        private static void PrintGroupMenu()
        {
            Console.WriteLine("1. List Groups");
            Console.WriteLine("2. Add Group");
            Console.WriteLine("3. Update Group");
            Console.WriteLine("4. Delete Group");
            Console.WriteLine("5. Back to Main Menu");
        }

        private static void PrintTeacherMenu()
        {
            Console.WriteLine("1. List Teachers");
            Console.WriteLine("2. Add Teacher");
            Console.WriteLine("3. Update Teacher");
            Console.WriteLine("4. Delete Teacher");
            Console.WriteLine("5. Back to Main Menu");
        }

        private static void ListStudents(StudentManager studentManager)
        {
            Console.WriteLine("Do you want to filter (y/n): ");
            var filterChoice = Console.ReadLine();
            var filterText = string.Empty;
            Expression<Func<Student, bool>> filter = null;

            if (!string.IsNullOrEmpty(filterChoice))
            {
                if (filterChoice == "y")
                {
                    filterText = Console.ReadLine()!;
                    filter = DynamicPredicateBuilder.ParseFilter<Student>(filterText)!;
                }
            }

            var students = filterChoice == "y" ? studentManager.GetAll(predicate:filter) : studentManager.GetAll();

            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.FirstName} {student.LastName}, Group: {student.GroupId},{student.GroupName}");
            }
        }

        private static void AddStudent(StudentManager studentManager)
        {
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine()!;
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine()!;
            Console.Write("Enter Group ID: ");
            int groupId = int.Parse(Console.ReadLine()!);
            studentManager.Add(new CreateStudentDto
            {
                FirstName = firstName,
                LastName = lastName,
                GroupId = groupId,
            });
            Console.WriteLine("Student added successfully.");
        }

        private static void UpdateStudent(StudentManager studentManager)
        {
            Console.Write("Enter Student ID to update: ");
            int id = int.Parse(Console.ReadLine()!);
            Console.Write("Enter New First Name: ");
            string firstName = Console.ReadLine()!;
            Console.Write("Enter New Last Name: ");
            string lastName = Console.ReadLine()!;
            Console.Write("Enter New Group ID: ");
            var groupId = int.Parse(Console.ReadLine()!);
            studentManager.Update(id, new UpdateStudentDto
            {
                FirstName = firstName,
                LastName = lastName,
                GroupId = groupId,
            });
            Console.WriteLine("Student updated successfully.");
        }

        private static void DeleteStudent(StudentManager studentManager)
        {
            Console.Write("Enter Student ID to delete: ");
            int id = int.Parse(Console.ReadLine()!);
            studentManager.Delete(id);
            Console.WriteLine("Student deleted successfully.");
        }

        private static void PrintGroups(GroupManager groupManager)
        {
            var groups = groupManager.GetAll(x => x.Include(y => y.Students));
            foreach (var group in groups)
            {
                Console.WriteLine($"ID: {group.Id}, Name: {group.Name}");

                if (group.StudentNames.Count == 0)
                {
                    Console.WriteLine("  No students in this group.");
                    continue;
                }

                foreach (var item in group.StudentNames)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void AddGroup(GroupManager groupManager)
        {
            Console.Write("Enter Group Name: ");
            string name = Console.ReadLine()!;
            groupManager.Add(new CreateGroupDto
            {
                Name = name,
            });
            Console.WriteLine("Group added successfully.");
        }

        private static void UpdateGroup(GroupManager groupManager)
        {
            Console.Write("Enter Group ID to update: ");
            int id = int.Parse(Console.ReadLine()!);
            Console.Write("Enter New Group Name: ");
            string name = Console.ReadLine()!;
            groupManager.Update(id, new UpdateGroupDto
            {
                Name = name,
            });
            Console.WriteLine("Group updated successfully.");
        }

        private static void DeleteGroup(GroupManager groupManager)
        {
            Console.Write("Enter Group ID to delete: ");
            int id = int.Parse(Console.ReadLine()!);
            groupManager.Delete(id);
            Console.WriteLine("Group deleted successfully.");
        }

        private static void Exit()
        {
            Console.WriteLine("Exiting the application. Goodbye!");
        }
    }
}