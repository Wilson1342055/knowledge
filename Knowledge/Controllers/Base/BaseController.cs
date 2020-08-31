using Knowledge.Models.Common;
using Knowledge.Until;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Knowledge.Controllers.Base
{
    /// <summary>
    /// 控制器基类
    /// </summary>
    public class BaseController : ApiController
    {
        /// <summary>
        /// 封装返回数据
        /// </summary>
        /// <returns></returns>
        protected HttpResponseMessage ReturnHttpResponseMessage(EnumModel statusCode, string msg, object data = null)
        {
            var responseModel = new ResponseModel
        {
                Code = (int)statusCode,
                Message = msg,
                Data = data
            };
            string json = JsonConvert.SerializeObject(responseModel);

            return new HttpResponseMessage { Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 封装返回数据
        /// </summary>
        /// <returns></returns>
        protected HttpResponseMessage ReturnHttpResponseMessage(EnumModel statusCode, object data = null)
        {
            var responseModel = new ResponseModel
            {
                Code = (int)statusCode,
                Message = EnumUntil.GetDescription(typeof(EnumModel), statusCode),
                Data = data
            };
            string json = JsonConvert.SerializeObject(responseModel);

            return new HttpResponseMessage { Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json") };
        }
    }
}
