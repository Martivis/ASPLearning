using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPLearning.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : ControllerBase
	{
		/// <summary>
		///	Get test value
		/// </summary>
		/// <returns>254</returns>
		[ApiVersion("1.0")]
		[HttpGet("")]
		public int GetInt()
		{
			return 254;
		}

		/// <summary>
		/// Get test value 2.0
		/// </summary>
		/// <returns>15</returns>
		[ApiVersion("2.0")]
		[HttpGet("")]
		public int GetNewInt()
		{
			return 15;
		}
	}
}
