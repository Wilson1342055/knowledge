using IRepository.IFloor;
using Knowledge.Controllers.Base;
using KnowledgeModel.Common;
using KnowledgeModel.Floor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Knowledge.Controllers
{
    public class FloorController :BaseController
    {
        private readonly IFloor _floor;

        public FloorController(IFloor floor)
        {
            _floor = floor;
        }
        /// <summary>
        /// 新增楼层
        /// </summary>
        /// <param name="model"></param>
        [HttpPost]
        public ExecResult AddFloor(FloorModel model)
        {
            return _floor.AddFloor(model);
        }

        [HttpGet]
        public ExecResult DelFloor(string FloorID)
        {
            return _floor.DelFloor(FloorID);
        }

        [HttpGet]
        public ExecResult QueryFloor(int EmployeeID)
        {
            return _floor.QueryFloor(EmployeeID);
        }


    }
}
