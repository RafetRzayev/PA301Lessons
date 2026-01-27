using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDemo.Models
{
    internal class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Student> Students { get; set; } = [];

        public List<TeacherGroup> TeacherGroups { get; set; } = [];
    }
}
