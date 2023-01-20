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
	Task AddText(EditTextModel model);
	Task UpdateText(Guid guid, EditTextModel model);
	Task DeleteText(Guid guid);
}
