using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeModel.Car
{
    public class CarModel
    {
        public int CarID { get; set; }
        public string CarQuestion { get; set; }
        public string CarAnswer { get; set; }

        public int FloorID { get; set; }

        public int RoomID { get; set; }
        public string CreateUser { get; set; }

        public DateTime CreateTime { get; set; }

        public int EmployeeID { get; set; }
        public int IsStop { get; set; }
    }
}
