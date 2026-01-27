using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDemo.Models
{
    internal class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!; 
        
        public List<TeacherGroup> TeacherGroups { get; set; } = [];
    }
}
