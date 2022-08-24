using CaWorkshop.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CaWorkshop.Application.TodoLists.Commands.UpdateTodoList;

public class UpdateTodoListCommand : IRequest
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
}

public class UpdateTodoListCommandHandler
    : AsyncRequestHandler<UpdateTodoListCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTodoListCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    protected override async Task Handle(UpdateTodoListCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _context.TodoLists
            .FirstOrDefaultAsync(tl => tl.Id == request.Id, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Title = request.Title;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
