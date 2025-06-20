using MonopolyTestTask.Models;

namespace MonopolyTestTask;

public static class PalletDataGenerator
{
    public static List<Pallet> GenerateRandomPalletData()
    {
        var pallets = new List<Pallet>();
        var rnd = new Random();
        
        for (int i = 0; i < 10; i++)
        {
            pallets.Add(new Pallet($"P{i}",rnd.Next(10, 20), rnd.Next(10, 20), rnd.Next(10, 20)));
        }

        var dateRangeStart = new DateOnly(2025, 1, 1);
        var dateRangeEnd = new DateOnly(2026, 1, 1);
        var dateRange = dateRangeEnd.DayNumber - dateRangeStart.DayNumber; 

        foreach (var pallet in pallets)
        {
            var boxCount = rnd.Next(1, 10);
            for (int i = 0; i < boxCount; i++)
            {
                Box box;
                if (rnd.NextDouble() < 0.5)
                {
                    box = Box.FromExpirationDate(dateRangeStart.AddDays(rnd.Next(dateRange)), $"B{i}_{pallet.Id}",
                        rnd.Next(1, 10), rnd.Next(1, 10), rnd.Next(1, 10), rnd.Next(1, 10));
                }
                else
                {
                    box = Box.FromProductionDate(dateRangeStart.AddDays(rnd.Next(dateRange)), $"B{i}_{pallet.Id}",
                        rnd.Next(1, 10), rnd.Next(1, 10), rnd.Next(1, 10), rnd.Next(1, 10));
                }
                pallet.TryAddBox(box);
            }
        }

        return pallets;
    }

    public static List<Pallet> GenerateTestPalletDataForTasks()
    {
        var pallets = new List<Pallet>();

        var palletFirst = new Pallet("P1", 100, 10, 10);
        var boxFirstPalletFirst = Box.FromExpirationDate(new DateOnly(2025, 1, 1), "B1_P1", 1, 1, 1, 1);
        var boxSecondPalletFirst = Box.FromExpirationDate(new DateOnly(2026, 1, 1), "B2_P1", 1, 1, 1, 1);
        palletFirst.TryAddBox(boxFirstPalletFirst);
        palletFirst.TryAddBox(boxSecondPalletFirst);
        
        var palletSecond = new Pallet("P2", 10, 10, 10);
        var boxFirstPalletSecond = Box.FromExpirationDate(new DateOnly(2025, 1, 1), "B1_P2", 1, 1, 1, 5);
        palletSecond.TryAddBox(boxFirstPalletSecond);
        
        var palletThird = new Pallet("P3", 10, 10, 10);
        var boxFirstPalletThird = Box.FromExpirationDate(new DateOnly(2025, 1, 2), "B1_P3", 5, 5, 1, 1);
        palletThird.TryAddBox(boxFirstPalletThird);
                
        var palletFourth = new Pallet("P4", 10, 10, 10);
        var boxFirstPalletFourth = Box.FromExpirationDate(new DateOnly(2025, 1, 3), "B1_P4", 5, 5, 5, 1);
        palletFourth.TryAddBox(boxFirstPalletFourth);
        
        pallets.Add(palletFirst);
        pallets.Add(palletSecond);
        pallets.Add(palletThird);
        pallets.Add(palletFourth);
        
        return pallets;
    }
}