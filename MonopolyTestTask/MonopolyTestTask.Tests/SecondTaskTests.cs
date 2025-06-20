using MonopolyTestTask.DTOs;

namespace MonopolyTestTask.Tests;

public class SecondTaskTests
{
    private readonly List<SecondTaskDto> _top3Pallets;
    
    public SecondTaskTests()
    {
        var pallets = PalletDataGenerator.GenerateTestPalletDataForTasks();
        _top3Pallets = TaskSolver.SolveSecondTask(pallets);
    }
    
    [Fact]
    public void Pallets_CountIsThree()
    {
        Assert.Equal(3, _top3Pallets.Count);
    }

    [Fact]
    public void Pallets_WithNewestBoxes()
    {
        Assert.Contains(_top3Pallets, dto => dto.Pallet.Id == "P1");
        Assert.Contains(_top3Pallets, dto => dto.Pallet.Id == "P3");
        Assert.Contains(_top3Pallets, dto => dto.Pallet.Id == "P4");
    }

    [Fact]
    public void Pallets_SortedWithVolumeAscending()
    {
        var actualOrder = _top3Pallets.Select(dto => dto.Pallet.Volume).ToList();
        var expectedOrder = actualOrder.OrderBy(v => v).ToList();
        Assert.Equal(actualOrder, expectedOrder);
    }
}