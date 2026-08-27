using System;

namespace SPW.Models;

public record TestDataVm
{
    public required Guid Id { get; init; }
    public string ShortId => Id.ToString()[..8];
    public required string Name { get; init; }
    public required TimeOnly Time { get; init; }
}