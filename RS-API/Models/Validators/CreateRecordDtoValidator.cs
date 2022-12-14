using FluentValidation;

namespace RS_API.Models.Validators;

public class CreateRecordDtoValidator : AbstractValidator<CreateRecordDto>
{
	public CreateRecordDtoValidator(StoreDbContext dbContext)
	{
		RuleFor(x => x.Title)
			.NotEmpty();
		
		RuleFor(x => x.Artist)
			.NotEmpty();
		
		RuleFor(x => x.Price)
			.NotEmpty();
		
		RuleFor(x => x.Stock)
			.NotEmpty();
	}
}