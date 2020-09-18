using BestWoDP;
using IRepository.IRoom;
using KnowledgeModel.Common;
using KnowledgeModel.Room;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Room
{
    public class Room : IRoom
    {
        public ExecResult AddRoom(RoomModel room)
        {
            string strSql = $"insert into Room(FloorID,RoomName,RoomDesc,CreateUser,CreateTime,EmployeeID) values('{room.FloorID}','{room.RoomName}','{room.RoomDesc}','{room.CreateUser}','{room.CreateTime}',1)";
            int intResult = BestWoDP.DapperHelper.ExceSQL(strSql, BestWoDP.DapperHelper.DBConnection.LogHelper);
            List<ExceDataResult> listResult = new List<ExceDataResult>();

            if (intResult > 0)
            {
                listResult.Add(new ExceDataResult { DocumentNo = room.RoomName, Success = true, Remark = "操作成功" });
                return new ExecResult { StatusCode = 1, Message = "操作成功", Data = listResult };
            }
            else
            {
                listResult.Add(new ExceDataResult { DocumentNo = "", Success = false, Remark = "操作失败" });
                return new ExecResult { StatusCode = 1, Message = "操作失败", Data = listResult };
            }
        }

        public ExecResult DelRoom(string IDs)
        {
            List<ExceDataResult> listResult = new List<ExceDataResult>();
            foreach (string item in IDs.Split(','))
            {
                string strSql = $"delete Room where RoomID = {item}";
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

        public ExecResult QueryRoom(int EmployeeID)
        {
            DataTable dt = DapperHelper.QueryGetDT("Room rm with(nolock) join Floor fr with(nolock) on rm.FloorID = fr.FloorID", "rm.RoomID,rm.RoomName '房间名称',fr.FloorName '所在楼层',rm.RoomDesc '房间描述',rm.CreateUser '创建人',rm.CreateTime '创建时间'", $"and rm.EmployeeID={EmployeeID}", BestWoDP.DapperHelper.DBConnection.LogHelper);
            return new ExecResult { StatusCode = 1, Message = "操作成功", DTData = dt };
        }

        public ExecResult QueryRoomByFloorID(string FloorID)
        {
            DataTable dt = DapperHelper.QueryGetDT("Room rm with(nolock) ", "rm.RoomID,rm.RoomName ", $"and rm.FloorID in ({FloorID})", BestWoDP.DapperHelper.DBConnection.LogHelper);
            return new ExecResult { StatusCode = 1, Message = "操作成功", DTData = dt };
        }
    }
}
