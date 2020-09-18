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
    /// <summary>
    /// 卡牌
    /// </summary>
    public class CarController : BaseController
    {
        private readonly ICar _car;
        /// <summary>
        /// 卡牌
        /// </summary>
        /// <param name="car"></param>
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
        /// <summary>
        /// 删除卡牌
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        [HttpPost]
        public ExecResult DelCar(string IDs)
        {
            return _car.DelCar(IDs);
        }
        /// <summary>
        /// 查看卡牌
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <returns></returns>
        [HttpGet]
        public ExecResult QueryCar(int EmployeeID)
        {
            return _car.QueryCar(EmployeeID);
        }
        /// <summary>
        /// 更新卡牌
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
