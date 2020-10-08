using BestWoDP;
using IRepository.IFloor;
using KnowledgeModel.Common;
using KnowledgeModel.Floor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Floor
{
    public class Floor:IFloor
    {
        public ExecResult AddFloor(FloorModel floor)
        {
            string strSql = $"insert into Floor(FloorName,FloorDesc,CreateUser,CreateTime,EmployeeID) values('{floor.FloorName}','{floor.FloorDesc}','{floor.CreateUser}','{floor.CreateTime}',1)";
            int intResult = BestWoDP.DapperHelper.ExceSQL(strSql, BestWoDP.DapperHelper.DBConnection.KnowledgeHelper);
            List<ExceDataResult> listResult = new List<ExceDataResult>();
            
            if(intResult>0)
            {
                listResult.Add(new ExceDataResult { DocumentNo = floor.FloorName, Success = true, Remark = "操作成功" });
                return new ExecResult { StatusCode = 1, Message = "操作成功", Data = listResult };
            }
            else
            {
                listResult.Add(new ExceDataResult { DocumentNo = "", Success = false, Remark = "操作失败" });
                return new ExecResult { StatusCode = 1, Message = "操作失败", Data = listResult };
            }
        }

        public ExecResult DelFloor(string IDs)
        {
            List<ExceDataResult> listResult = new List<ExceDataResult>();
            foreach (string item in IDs.Split(','))
            {
                string strSql = $"delete Floor where FloorID = {item}";
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

        public ExecResult QueryFloor(int EmployeeID)
        {
            DataTable dt = DapperHelper.QueryGetDT("Floor with(nolock)", "FloorID,FloorName 楼层,FloorDesc 描述,CreateUser 创建人,CreateTime 创建时间", $"and EmployeeID={EmployeeID}", BestWoDP.DapperHelper.DBConnection.KnowledgeHelper);

            return new ExecResult { StatusCode = 1, Message = "操作成功", DTData = dt };
        }
    }
}
