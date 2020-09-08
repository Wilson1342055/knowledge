using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeModel.Room
{
    public class RoomModel
    {
        public int FloorID { get; set; }
        public string RoomName { get; set; }

        public string RoomDesc { get; set; }

        public string CreateUser { get; set; }

        public DateTime CreateTime { get; set; }

        public int EmployeeID { get; set; }
    }
}
