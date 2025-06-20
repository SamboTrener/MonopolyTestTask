using MonopolyTestTask.Models;

namespace MonopolyTestTask.Tests;

public class PalletTests
{
    private readonly List<Pallet> _pallets = PalletDataGenerator.GenerateTestPalletDataForTasks();

    [Fact]
    public void Pallet_Volume_IsCorrect()
    {
        var pallet = _pallets.First(p => p.Id == "P1");
        Assert.Equal(10002, pallet.Volume);
    }

    [Fact]
    public void Pallet_CantContainBoxBiggerThanSelf()
    {
        var pallet = new Pallet("PTest", 10, 10, 10);
        var largeBox = Box.FromExpirationDate(new DateOnly(2026, 1, 1), "B1_PTest", 11, 10, 10, 1);
        pallet.TryAddBox(largeBox);
        Assert.DoesNotContain(largeBox, pallet.Boxes);
    }

    [Fact]
    public void Pallet_Weight_IsCorrect()
    {
        var pallet = _pallets.First(p => p.Id == "P1");
        Assert.Equal(32, pallet.Weight);
    }

    [Fact]
    public void Pallet_ExpDate_IsCorrect()
    {
        var pallet = _pallets.First(p => p.Id == "P1");
        Assert.Equal(new DateOnly(2025, 1, 1), pallet.ExpirationDate);
    }
    
    
}