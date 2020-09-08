using BestWoDP;
using IRepository.IFloor;
using Knowledge.Controllers.Base;
using Knowledge.Models.Common;
using KnowledgeModel.Common;
using KnowledgeModel.Floor;
using Repository.Floor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Knowledge.Controllers
{
    /// <summary>
    /// test控制器
    /// </summary>
    public class ValuesController :BaseController
    {
        private readonly IFloor _floor;
        public ValuesController(IFloor floor)
        {
            _floor = floor;
        }
        // GET api/values
        public HttpResponseMessage Get()
        {
            //return new string[] { "value1", "value2" };
            List<string> listResult = new List<string>();
            DataTable dtSource = DapperHelper.QueryGetDT("Employee", "LoginName,PassWord", "Status=1", DapperHelper.DBConnection.SystemHelper);
            foreach (DataRow item in dtSource.Rows)
            {
                listResult.Add(item["LoginName"].ToString());
            }
            return ReturnHttpResponseMessage(EnumModel.AllSuccess, listResult);
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

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
