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
		[HttpGet]
		public int GetInt()
		{
			return 254;
		}
	}
}
