using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.DataAccessLayer.Models
{
    public class TeacherGroup : Entity
    {
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public int GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
