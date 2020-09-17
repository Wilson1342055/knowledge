using IRepository.IRoom;
using Knowledge.Controllers.Base;
using KnowledgeModel.Common;
using KnowledgeModel.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Knowledge.Controllers
{
    public class RoomController : BaseController
    {
        private readonly IRoom _room;

        public RoomController(IRoom room)
        {
            _room = room;
        }
        /// <summary>
        /// 新增楼层
        /// </summary>
        /// <param name="model"></param>
        [HttpPost]
        public ExecResult AddRoom(RoomModel model)
        {
            return _room.AddRoom(model);
        }

        [HttpPost]
        public ExecResult DelRoom(string IDs)
        {
            return _room.DelRoom(IDs);
        }

        [HttpGet]
        public ExecResult QueryRoom(int EmployeeID)
        {
            return _room.QueryRoom(EmployeeID);
        }

        [HttpGet]
        public ExecResult QueryRoomByFloorID(int FloorID)
        {
            return _room.QueryRoomByFloorID(FloorID);
        }

    }
}
