namespace ASPLearning.Services.Texts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface ITextService
{
	Task<IEnumerable<TextModel>> GetAllTexts(int page = 0, int pageSize = 10);
	Task<TextModel> GetText(Guid guid);
	Task<TextModel> AddText(AddTextModel model);
	Task DeleteBook(Guid guid);
}
