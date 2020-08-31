using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knowledge.Models.Common
{
    /// <summary>
    /// 通用返回模型
    /// </summary>
    public class ResponseModel
    {
        /// <summary>
        /// 请求结果编码
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 请求结果说明
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 请求返回数据
        /// </summary>
        public object Data { get; set; }
    }
    /// <summary>
    /// 明细数据返回结果模型
    /// </summary>
    public class ResponseDataModel
    {
        /// <summary>
        /// 单据号
        /// </summary>
        public string DocumentNo { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}