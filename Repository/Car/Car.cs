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
            string strSql = $"insert into Car([CarQuestion],[CarAnswer],[FloorID],[RoomID],[CreateUser],[CreateTime],[IsStop],[EmployeeID]) values('{car.CarQuestion}','{car.CarAnswer}','{car.FloorID}','{car.RoomID}','{car.CreateUser}','{car.CreateTime}',{car.IsStop},1)";
            int intResult = BestWoDP.DapperHelper.ExceSQL(strSql, BestWoDP.DapperHelper.DBConnection.LogHelper);
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
                int intResult = BestWoDP.DapperHelper.ExceSQL(strSql, BestWoDP.DapperHelper.DBConnection.LogHelper);
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
            DataTable dt = DapperHelper.QueryGetDT("Car cr with(nolock) join Floor fr with(nolock) on cr.FloorID = fr.FloorID join Room rm with(nolock) on rm.RoomID=cr.RoomID", "cr.CarID,fr.FloorName+'('+rm.RoomName+')' '楼层房间',cr.CarQuestion '牌面',cr.[CarAnswer] '答案',cr.CreateUser '创建人',cr.CreateTime '创建时间'", $"and cr.EmployeeID={EmployeeID} and cr.[IsStop]=0", BestWoDP.DapperHelper.DBConnection.LogHelper);
            if(dt.Rows.Count==0)
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
            }
            return new ExecResult { StatusCode = 1, Message = "操作成功", DTData = dt };

        }

        public ExecResult UpdateCar(CarModel car)
        {
            string strSql = $"update Car set [Points]={1} where CarID = {car.FloorID}";
            int intResult = BestWoDP.DapperHelper.ExceSQL(strSql, BestWoDP.DapperHelper.DBConnection.LogHelper);
            return new ExecResult { StatusCode = 1, Message = "操作成功", Data = null };
        }

        public ExecResult GetCarAnswer(int EmployeeID, int IsRandom)
        {
            DataTable dt = new DataTable();
            if (IsRandom == 1)
                dt = DapperHelper.QueryGetDT("Car cr with(nolock) join Floor fr with(nolock) on cr.FloorID = fr.FloorID join Room rm with(nolock) on rm.RoomID = cr.RoomID", "top 1 cr.Points,cr.CarID,cr.[CarQuestion],cr.[CarAnswer],rm.RoomName,fr.FloorName", $"and cr.EmployeeID={EmployeeID} ORDER BY NEWID()", BestWoDP.DapperHelper.DBConnection.LogHelper);
            else
                dt = DapperHelper.QueryGetDT("Car cr with(nolock) join Floor fr with(nolock) on cr.FloorID = fr.FloorID join Room rm with(nolock) on rm.RoomID = cr.RoomID", "cr.CarID,cr.[CarQuestion],cr.[CarAnswer],rm.RoomName,fr.FloorName", $"and cr.EmployeeID={EmployeeID} and cr.Points<1 ORDER BY NEWID()", BestWoDP.DapperHelper.DBConnection.LogHelper);
            if (dt.Rows.Count == 0)
            {
                dt = DapperHelper.QueryGetDT("Car cr with(nolock) join Floor fr with(nolock) on cr.FloorID = fr.FloorID join Room rm with(nolock) on rm.RoomID = cr.RoomID", "top 1 cr.Points,cr.CarID,cr.[CarQuestion],cr.[CarAnswer],rm.RoomName,fr.FloorName", $"and cr.EmployeeID={EmployeeID} ORDER BY NEWID()", BestWoDP.DapperHelper.DBConnection.LogHelper);

                if (dt.Rows.Count == 0)
                {
                    DataRow dr = dt.NewRow();
                    dt.Rows.Add(dr);
                }
            }
            return new ExecResult { StatusCode = 1, Message = "操作成功", DTData = dt };
        }
    }
}
