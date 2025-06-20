using MonopolyTestTask.Models;

namespace MonopolyTestTask.DTOs;

public class FirstTaskDto(DateOnly expirationDate, List<Pallet> pallets)
{
    public DateOnly ExpirationDate { get; } = expirationDate;
    public List<Pallet> Pallets { get; } = pallets;
}