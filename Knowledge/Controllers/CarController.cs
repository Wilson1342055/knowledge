using IRepository.ICar;
using Knowledge.Controllers.Base;
using KnowledgeModel.Common;
using KnowledgeModel.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Knowledge.Controllers
{
    public class CarController : BaseController
    {
        private readonly ICar _car;

        public CarController(ICar car)
        {
            _car = car;
        }
        /// <summary>
        /// 增加卡牌
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ExecResult AddCar(CarModel model)
        {
            return _car.AddCar(model);
        }

        [HttpPost]
        public ExecResult DelCar(string IDs)
        {
            return _car.DelCar(IDs);
        }

        [HttpGet]
        public ExecResult QueryCar(int EmployeeID)
        {
            return _car.QueryCar(EmployeeID);
        }
        [HttpPost]
        public ExecResult UpdateCar(CarModel model)
        {
            return _car.UpdateCar(model);
        }

        /// <summary>
        /// 获取答题卡牌
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <param name="IsRandom"></param>
        /// <returns></returns>
        [HttpGet]
        public ExecResult GetCarAnswer(int EmployeeID, int IsRandom)
        {
            return _car.GetCarAnswer(EmployeeID, IsRandom);
        }
    }
}
