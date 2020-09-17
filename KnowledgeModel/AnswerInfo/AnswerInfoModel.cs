using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeModel.AnswerInfo
{
    public class AnswerInfoModel
    {
        public int AnswerInfoID { get; set; }

        public int CarID { get; set; }

        public string AnswerContent { get; set; }

        public string AnswerResult { get; set; }

        public int EmployeeID { get; set; }

        public string CreateUser { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
