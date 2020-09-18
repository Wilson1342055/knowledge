using BestWoDP;
using IRepository.IAnswerInfo;
using KnowledgeModel.AnswerInfo;
using KnowledgeModel.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.AnswerInfo
{
    public class AnswerInfo:IAnswerInfo
    {

        public ExecResult AddAnswerInfo(AnswerInfoModel model)
        {
            string strSql = $"insert into AnswerInfo([CarID], [AnswerContent], [AnswerResult], [EmployeeID], [CreateUser], [CreateTime]) values('{model.CarID}','{model.AnswerContent}','{model.AnswerResult}','{model.EmployeeID}','{ model.CreateUser}','{model.CreateTime}')";
            int intResult = BestWoDP.DapperHelper.ExceSQLReturnID(strSql, BestWoDP.DapperHelper.DBConnection.LogHelper);
            List<ExceDataResult> listResult = new List<ExceDataResult>();

            if (intResult > 0)
            {
                listResult.Add(new ExceDataResult { DocumentNo = intResult.ToString(), Success = true, Remark = "操作成功" });
                return new ExecResult { StatusCode = 1, Message = "操作成功", Data = listResult };
            }
            else
            {
                listResult.Add(new ExceDataResult { DocumentNo = "", Success = false, Remark = "操作失败" });
                return new ExecResult { StatusCode = 1, Message = "操作失败", Data = listResult };
            }
        }
        public ExecResult UpdateAnswerInfo(AnswerInfoModel model)
        {
            string strSql = $"update AnswerInfo set [AnswerResult]='{model.AnswerResult}' where [AnswerInfoID]={model.AnswerInfoID}";
            int intResult = BestWoDP.DapperHelper.ExceSQL(strSql, BestWoDP.DapperHelper.DBConnection.LogHelper);
            List<ExceDataResult> listResult = new List<ExceDataResult>();

            if (intResult > 0)
            {
                listResult.Add(new ExceDataResult { DocumentNo = model.AnswerInfoID.ToString(), Success = true, Remark = "操作成功" });
                return new ExecResult { StatusCode = 1, Message = "操作成功", Data = listResult };
            }
            else
            {
                listResult.Add(new ExceDataResult { DocumentNo = "", Success = false, Remark = "操作失败" });
                return new ExecResult { StatusCode = 1, Message = "操作失败", Data = listResult };
            }
        }
    }
}
