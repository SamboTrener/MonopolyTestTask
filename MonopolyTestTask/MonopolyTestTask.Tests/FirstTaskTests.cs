using MonopolyTestTask.DTOs;

namespace MonopolyTestTask.Tests;

public class FirstTaskTests
{
    private readonly List<FirstTaskDto> _groupedPallets;
    private readonly FirstTaskDto _groupWithPallets;
    
    public FirstTaskTests()
    {
        var pallets = PalletDataGenerator.GenerateTestPalletDataForTasks();
        _groupedPallets = TaskSolver.SolveFirstTask(pallets);
        _groupWithPallets = _groupedPallets.FirstOrDefault(g => g.ExpirationDate == new DateOnly(2025, 1, 1))!;
    }
    
    [Fact]
    public void Pallets_GroupsByExpDate()
    {
        Assert.NotNull(_groupWithPallets);
        Assert.Equal(2, _groupWithPallets.Pallets.Count);
    }

    [Fact]
    public void Pallets_SortedByExpDateAsc()
    {
        var actualOrder = _groupedPallets.Select(g => g.ExpirationDate).ToList();
        var expectedOrder = actualOrder.OrderBy(d => d).ToList();
        Assert.Equal(actualOrder, expectedOrder);
    }

    [Fact]
    public void Pallets_SortedByWeightInGroup()
    {
        var actualOrder = _groupWithPallets.Pallets.Select(p => p.Weight).ToList();
        var expectedOrder = actualOrder.OrderBy(w => w).ToList();
        Assert.Equal(actualOrder, expectedOrder);
    }
}
