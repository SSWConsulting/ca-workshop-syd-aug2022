using CaWorkshop.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CaWorkshop.Application.TodoLists.Commands.CreateTodoList;

public class CreateTodoListCommandValidator
    : AbstractValidator<CreateTodoListCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateTodoListCommandValidator(
        IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Title)
            .MaximumLength(240)
            .NotEmpty()
            .MustAsync(BeUniqueTitle)
                .WithMessage("The specified '{PropertyName}' ({PropertyValue}) already exists. 😡");
    }

    public async Task<bool> BeUniqueTitle(string title,
        CancellationToken cancellationToken)
    {
        return await _context.TodoLists
            .AllAsync(l => l.Title != title, cancellationToken);
    }
}
