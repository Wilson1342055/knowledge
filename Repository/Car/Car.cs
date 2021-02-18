using BestWoDP;
using IRepository.ICar;
using IRepository.IRoom;
using KnowledgeModel.Car;
using KnowledgeModel.Common;
using KnowledgeModel.Room;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Car
{
    public class Car : ICar
    {
        public ExecResult AddCar(CarModel car)
        {
            string strSql = $"insert into Car([CarQuestion],[CarAnswer],[FloorID],[RoomID],[CreateUser],[CreateTime],[IsStop],[EmployeeID],[Points]) values('{car.CarQuestion}','{car.CarAnswer}','{car.FloorID}','{car.RoomID}','{car.CreateUser}','{car.CreateTime}',{car.IsStop},1,{car.Points})";
            int intResult = BestWoDP.DapperHelper.ExceSQL(strSql, BestWoDP.DapperHelper.DBConnection.KnowledgeHelper);
            List<ExceDataResult> listResult = new List<ExceDataResult>();

            if (intResult > 0)
            {
                listResult.Add(new ExceDataResult { DocumentNo = car.CarQuestion, Success = true, Remark = "操作成功" });
                return new ExecResult { StatusCode = 1, Message = "操作成功", Data = listResult };
            }
            else
            {
                listResult.Add(new ExceDataResult { DocumentNo = "", Success = false, Remark = "操作失败" });
                return new ExecResult { StatusCode = 1, Message = "操作失败", Data = listResult };
            }
        }

        public ExecResult DelCar(string IDs)
        {
            List<ExceDataResult> listResult = new List<ExceDataResult>();
            foreach (string item in IDs.Split(','))
            {
                string strSql = $"update Car set [IsStop]=1 where CarID = {item}";
                int intResult = BestWoDP.DapperHelper.ExceSQL(strSql, BestWoDP.DapperHelper.DBConnection.KnowledgeHelper);
                if (intResult > 0)
                {
                    listResult.Add(new ExceDataResult { DocumentNo = item.ToString(), Success = true, Remark = "操作成功" });
                }
                else
                {
                    listResult.Add(new ExceDataResult { DocumentNo = item.ToString(), Success = false, Remark = "操作失败" });
                }
            }
            return new ExecResult { StatusCode = 1, Message = "操作成功", Data = listResult };
        }

        public ExecResult QueryCar(int EmployeeID)
        {
            DataTable dt = DapperHelper.QueryGetDT("Car cr with(nolock) join Floor fr with(nolock) on cr.FloorID = fr.FloorID join Room rm with(nolock) on rm.RoomID=cr.RoomID", "cr.CarID,fr.FloorName+'('+rm.RoomName+')' '楼层房间',cr.CarQuestion '牌面',cr.[CarAnswer] '答案',cr.CreateUser '创建人',cr.CreateTime '创建时间'", $"and cr.EmployeeID={EmployeeID} and cr.[IsStop]=0", BestWoDP.DapperHelper.DBConnection.KnowledgeHelper);
            return new ExecResult { StatusCode = 1, Message = "操作成功", DTData = dt };

        }

        public ExecResult QueryCarByRoomIDs(string RoomIDs)
        {
            DataTable dt = DapperHelper.QueryGetDT("Car cr with(nolock) ", "cr.CarID", $"and cr.RoomID in ({RoomIDs}) and cr.[IsStop]=0", BestWoDP.DapperHelper.DBConnection.KnowledgeHelper);
            return new ExecResult { StatusCode = 1, Message = "操作成功", DTData = dt };

        }
        public ExecResult QueryCarByID(int CarID)
        {
            DataTable dt = DapperHelper.QueryGetDT("Car cr with(nolock) ", "cr.*", $"and cr.CarID in ({CarID}) and cr.[IsStop]=0", BestWoDP.DapperHelper.DBConnection.KnowledgeHelper);
            return new ExecResult { StatusCode = 1, Message = "操作成功", DTData = dt };

        }

        public ExecResult UpdateCar(CarModel car)
        {
            string strSql = $"update Car set [Points]={car.Points},CarQuestion='{car.CarQuestion}',CarAnswer='{car.CarAnswer}',FloorID={car.FloorID},RoomID={car.RoomID} where CarID = {car.CarID}";
            int intResult = BestWoDP.DapperHelper.ExceSQL(strSql, BestWoDP.DapperHelper.DBConnection.KnowledgeHelper);

            List<ExceDataResult> listResult = new List<ExceDataResult>();

            if (intResult > 0)
            {
                listResult.Add(new ExceDataResult { DocumentNo = car.CarID.ToString(), Success = true, Remark = "操作成功" });
                return new ExecResult { StatusCode = 1, Message = "操作成功", Data = listResult };
            }
            else
            {
                listResult.Add(new ExceDataResult { DocumentNo = "", Success = false, Remark = "操作失败" });
                return new ExecResult { StatusCode = 1, Message = "操作失败", Data = listResult };
            }
        }

        public ExecResult GetCarAnswer(int EmployeeID, int IsRandom)
        {
            DataTable dt = new DataTable();
            if (IsRandom == 1)
                dt = DapperHelper.QueryGetDT("Car cr with(nolock) join Floor fr with(nolock) on cr.FloorID = fr.FloorID join Room rm with(nolock) on rm.RoomID = cr.RoomID", "top 1 cr.Points,cr.CarID,cr.[CarQuestion],cr.[CarAnswer],rm.RoomName,fr.FloorName,cr.FloorID,cr.RoomID", $"and cr.EmployeeID={EmployeeID} ORDER BY NEWID()", BestWoDP.DapperHelper.DBConnection.KnowledgeHelper);
            else
                dt = DapperHelper.QueryGetDT("Car cr with(nolock) join Floor fr with(nolock) on cr.FloorID = fr.FloorID join Room rm with(nolock) on rm.RoomID = cr.RoomID", "top 1 cr.Points,cr.CarID,cr.[CarQuestion],cr.[CarAnswer],rm.RoomName,fr.FloorName,cr.FloorID,cr.RoomID", $"and cr.EmployeeID={EmployeeID} and cr.Points<1 ORDER BY NEWID()", BestWoDP.DapperHelper.DBConnection.KnowledgeHelper);
            if (dt.Rows.Count == 0)
            {
                dt = DapperHelper.QueryGetDT("Car cr with(nolock) join Floor fr with(nolock) on cr.FloorID = fr.FloorID join Room rm with(nolock) on rm.RoomID = cr.RoomID", "top 1 cr.Points,cr.CarID,cr.[CarQuestion],cr.[CarAnswer],rm.RoomName,fr.FloorName,cr.FloorID,cr.RoomID", $"and cr.EmployeeID={EmployeeID} ORDER BY NEWID()", BestWoDP.DapperHelper.DBConnection.KnowledgeHelper);
            }
            return new ExecResult { StatusCode = 1, Message = "操作成功", DTData = dt };
        }
    }
}
