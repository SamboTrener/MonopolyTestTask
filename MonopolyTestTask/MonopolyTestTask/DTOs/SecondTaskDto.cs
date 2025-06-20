using MonopolyTestTask.Models;

namespace MonopolyTestTask.DTOs;

public class SecondTaskDto(Pallet pallet, DateOnly maxExpDate)
{
    public Pallet Pallet => pallet;
    public DateOnly MaxExpDate => maxExpDate;
}