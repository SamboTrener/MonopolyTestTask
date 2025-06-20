using System.Collections;
using MonopolyTestTask.DTOs;
using MonopolyTestTask.Models;

namespace MonopolyTestTask;

public static class TaskSolver
{
    public static List<FirstTaskDto> SolveFirstTask(List<Pallet> pallets)
    {
        var resultCollection =
            pallets
                .GroupBy(p => p.ExpirationDate)
                .OrderBy(g => g.Key)
                .Select(g => new
                    FirstTaskDto(g.Key, g.OrderBy(p => p.Weight).ToList()))
                .ToList();
        return resultCollection;
    }

    public static List<SecondTaskDto> SolveSecondTask(List<Pallet> pallets)
    {
        var taskSecond =
        pallets
            .Select(pallet => new 
                SecondTaskDto(pallet, pallet.Boxes.Select(b => b.ExpirationDate).Max()))
            .OrderByDescending(s => s.MaxExpDate)
            .Take(3)
            .OrderBy(s => s.Pallet.Volume)
            .ToList();
        return taskSecond;
    }
}