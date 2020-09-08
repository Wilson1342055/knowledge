using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeModel.Common
{
    /// <summary>
    /// 执行模式统一返回模型
    /// </summary>
    public class ExecResult
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public List<ExceDataResult> Data { get; set; }

        public DataTable DTData { get; set; }
    }
    /// <summary>
    /// 返回数据统一模型
    /// </summary>
    public class ExceDataResult
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
