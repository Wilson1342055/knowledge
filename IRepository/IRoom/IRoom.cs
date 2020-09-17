using KnowledgeModel.Common;
using KnowledgeModel.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.IRoom
{
    public interface IRoom
    {
        /// <summary>
        /// 添加房间
        /// </summary>
        /// <param name="floor"></param>
        /// <returns></returns>
        ExecResult AddRoom(RoomModel floor);

        ExecResult DelRoom(string IDs);

        ExecResult QueryRoom(int EmployeeID);

        ExecResult QueryRoomByFloorID(int FloorID);
    }
}
