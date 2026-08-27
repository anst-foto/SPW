using System;

namespace SPW.Models;

public record TestData
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string Name { get; init; }
    public TimeOnly Time { get; init; } = TimeOnly.FromDateTime(DateTime.Now);
}