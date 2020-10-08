using KnowledgeModel.Car;
using KnowledgeModel.Common;
using KnowledgeModel.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.ICar
{
    public interface ICar
    {
        /// <summary>
        /// 添加房间
        /// </summary>
        /// <param name="floor"></param>
        /// <returns></returns>
        ExecResult AddCar(CarModel car);

        ExecResult DelCar(string IDs);

        ExecResult QueryCar(int EmployeeID);

        ExecResult UpdateCar(CarModel car);

        ExecResult GetCarAnswer(int EmployeeID, int IsRandom);

        ExecResult QueryCarByRoomIDs(string RoomIDs);
        ExecResult QueryCarByID(int CarID);
    }
}
