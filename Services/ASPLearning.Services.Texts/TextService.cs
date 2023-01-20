namespace ASPLearning.Services.Texts;

using ASPLearning.Context;
using ASPLearning.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPLearning.Context.Entities;
using System.Security.Cryptography.X509Certificates;

public class TextService : ITextService
{
	private readonly IDbContextFactory<AppDbContext> _dbContextFactory;
	private readonly IMapper _mapper;
	private readonly IModelValidator<AddTextModel> _addTextModelValidator;

	public TextService(
		IDbContextFactory<AppDbContext> dbContextFactory,
		IMapper mapper, 
		IModelValidator<AddTextModel> addTextModelValidator
		)
	{
		_dbContextFactory = dbContextFactory;
		_mapper = mapper;
		_addTextModelValidator = addTextModelValidator;
	}

	public async Task<IEnumerable<TextModel>> GetAllTexts(int page, int pageSize)
	{
		using var context = await _dbContextFactory.CreateDbContextAsync();

		IQueryable<Text> texts = context.Set<Text>()
			.AsQueryable()
			.Skip(page * pageSize)
			.Take(pageSize);

		IEnumerable<TextModel> data = (await texts.ToListAsync()).Select(_mapper.Map<TextModel>);

		return data;
	}

	public async Task<TextModel> AddText(AddTextModel model)
	{
		_addTextModelValidator.Check(model);

		using var context = await _dbContextFactory.CreateDbContextAsync();

		Text text = _mapper.Map<Text>(model);

		await context.AddAsync(text);
		context.SaveChanges();

		return _mapper.Map<TextModel>(text);
	}

	public async Task DeleteBook(Guid guid)
	{
		using var context = await _dbContextFactory.CreateDbContextAsync();

		var text = context.Set<Text>().FirstOrDefaultAsync(x => x.Uid == guid)
			?? throw new Exception($"The text with Uid {guid} was not found");

		context.Remove(text);
		context.SaveChanges();
	}


	public async Task<TextModel> GetText(Guid guid)
	{
		using var context = await _dbContextFactory.CreateDbContextAsync();

		var text = await context.Set<Text>().FirstOrDefaultAsync(x => x.Uid == guid)
			?? throw new Exception($"The text with Uid {guid} was not found");

		return _mapper.Map<TextModel>(text);
	}
}
