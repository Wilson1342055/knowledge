using KnowledgeModel.Common;
using KnowledgeModel.Floor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.IFloor
{
    public interface IFloor
    {
        /// <summary>
        /// 添加楼层
        /// </summary>
        /// <param name="floor"></param>
        /// <returns></returns>
        ExecResult AddFloor(FloorModel floor);

        ExecResult DelFloor(string IDs);

        ExecResult QueryFloor(int EmployeeID);
    }
}
