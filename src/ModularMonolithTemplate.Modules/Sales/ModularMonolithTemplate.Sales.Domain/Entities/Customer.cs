using ModularMonolithTemplate.SharedKernel.Domain;

namespace ModularMonolithTemplate.Sales.Domain.Entities;

public class Customer : BaseEntity
{
    public string Name { get; private set; } = default!;
    public string Email { get; private set; } = default!;
}
