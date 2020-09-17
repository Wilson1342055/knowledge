using KnowledgeModel.AnswerInfo;
using KnowledgeModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.IAnswerInfo
{
    public interface IAnswerInfo
    {
        ExecResult AddAnswerInfo(AnswerInfoModel model);
        ExecResult UpdateAnswerInfo(AnswerInfoModel model);

    }
}
