using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Knowledge.Models.Common
{
	/// <summary>
	/// 统一模型枚举
	/// </summary>
    public enum EnumModel
    {

		/// <summary>
		/// 业务全部操作成功
		/// </summary>
		[Description("全部操作成功！")]
		AllSuccess = 10043,
		/// <summary>
		/// 业务部分操作成功
		/// </summary>
		[Description("部分操作成功！")]
		PartSuccess = 10044,
		/// <summary>
		/// 业务全部操作失败
		/// </summary>
		[Description("全部操作失败！")]
		AllFail = 10045,
		/// <summary>
		/// 内部报错，请重试
		/// </summary>
		[Description("内部报错,请重试！")]
		InternalAbnormal = 10088,
		/// <summary>
		/// 必填项验证错误
		/// </summary>
		[Description("必填项验证失败！")]
		RequiredErr = 10099,
    }
}