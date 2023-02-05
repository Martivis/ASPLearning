using ASPLearning.Common.Security;
using ASPLearning.Services.Texts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPLearning.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TextsController : ControllerBase
	{
		private readonly ILogger<TextsController> _logger;
		private readonly ITextService _textService;

		public TextsController(ILogger<TextsController> logger, ITextService textService)
		{
			_logger = logger;
			_textService = textService;
		}

		/// <summary>
		/// Get all texts
		/// </summary>
		/// <param name="page">Page number</param>
		/// <param name="pageSize">Elements per page</param>
		/// <response code="200">List of TextModels</response>
		[ProducesResponseType(typeof(IEnumerable<TextModel>), 200)]
		[HttpGet("")]
		[Authorize]
		public async Task<IEnumerable<TextModel>> GetAllTexts([FromQuery]int page = 0, [FromQuery]int pageSize = 10)
		{
			var texts = await _textService.GetAllTexts(page, pageSize);
			return texts;
		}

		/// <summary>
		/// Add new text
		/// </summary>
		/// <param name="model">New EditTextModel</param>
		/// <response code="200"></response>
		[HttpPost("")]
		[Authorize(Policy = AppScopes.TextsWrite)]
		public async Task<IActionResult> AddText([FromBody] EditTextModel model)
		{
			await _textService.AddText(model);
			return Ok();
		}

		/// <summary>
		/// Get text by guid
		/// </summary>
		/// <param name="guid">Text guid</param>
		/// <response code="200">TextModel</response>response>
		[ProducesResponseType(typeof(TextModel), 200)]
		[HttpGet("{guid}")]
		[Authorize(Policy = AppScopes.TextsRead)]
		public async Task<TextModel> GetText([FromRoute] Guid guid)
		{
			var text = await _textService.GetText(guid);
			return text;
		}

		/// <summary>
		/// Update existing text
		/// </summary>
		/// <param name="guid">Target text guid</param>
		/// <param name="model">Updated text EditTextModel</param>
		/// <response code="200"></response>
		[HttpPut("{guid}")]
		[Authorize(Policy = AppScopes.TextsWrite)]
		public async Task<IActionResult> UpdateText([FromRoute] Guid guid, [FromBody] EditTextModel model)
		{
			await _textService.UpdateText(guid, model);
			return Ok();
		}

		/// <summary>
		/// Delete existing text
		/// </summary>
		/// <param name="guid">Target text guid</param>
		/// <response code="200"></response>
		[HttpDelete("{guid}")]
		[Authorize(Policy = AppScopes.TextsWrite)]
		public async Task<IActionResult> DeleteText([FromRoute] Guid guid)
		{
			await _textService.DeleteText(guid);
			return Ok();
		}
	}
}
