using IRepository.IAnswerInfo;
using Knowledge.Controllers.Base;
using KnowledgeModel.AnswerInfo;
using KnowledgeModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Knowledge.Controllers
{
    /// <summary>
    /// 答题
    /// </summary>
    public class AnswerInfoController : BaseController
    {
        private readonly IAnswerInfo _answerInfo;
        /// <summary>
        /// 答题
        /// </summary>
        /// <param name="answerInfo"></param>
        public AnswerInfoController(IAnswerInfo answerInfo)
        {
            _answerInfo = answerInfo;
        }
        /// <summary>
        /// 新增答题
        /// </summary>
        /// <param name="model"></param>
        [HttpPost]
        public ExecResult AddAnswerInfo(AnswerInfoModel model)
        {
            return _answerInfo.AddAnswerInfo(model);
        }
        /// <summary>
        /// 修改答题
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ExecResult UpdateAnswerInfo(AnswerInfoModel model)
        {
            return _answerInfo.UpdateAnswerInfo(model);
        }
        
    }
}
