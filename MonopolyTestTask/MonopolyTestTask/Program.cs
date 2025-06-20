using MonopolyTestTask;

var pallets = PalletDataGenerator.GenerateRandomPalletData();

foreach (var pallet in pallets)
{
    Console.WriteLine(pallet.ToString());
}

Console.WriteLine($"Сгруппировать все паллеты по сроку годности, отсортировать по возрастанию срока годности, в каждой группе отсортировать паллеты по весу:\n\n");

var taskFirstResultCollection = TaskSolver.SolveFirstTask(pallets);

foreach (var group in taskFirstResultCollection)
{
    Console.WriteLine($"Группа, в которой срок выходит: {group.ExpirationDate}");
    foreach (var pallet in group.Pallets)
    {
        Console.WriteLine(pallet.ToString());
    }
} 

Console.WriteLine("3 паллеты, которые содержат коробки с наибольшим сроком годности, отсортированные по возрастанию объема:\n");

var taskSecondResultCollection = TaskSolver.SolveSecondTask(pallets);

foreach (var palletWithDate in taskSecondResultCollection)
{
    Console.WriteLine($"Максимальная дата выхода срока годности коробки - {palletWithDate.MaxExpDate}");
    Console.WriteLine(palletWithDate.Pallet.ToString());
}