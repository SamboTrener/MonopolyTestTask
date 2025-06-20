using MonopolyTestTask.Interfaces;

namespace MonopolyTestTask.Models;

public class Box : Container, IExpirable
{
    private const int StorageLife = 100;

    public DateOnly ExpirationDate { get; set; }

    private Box(DateOnly expirationDate, string id, float width, float height, float depth, float weight) : base(id,
        width, height, depth)
    {
        ExpirationDate = expirationDate;
        Weight = weight;
    }

    public static Box FromExpirationDate(DateOnly expirationDate, string id, float width, float height, float depth,
        float weight)
        => new(expirationDate, id, width, height, depth, weight);

    public static Box FromProductionDate(DateOnly productionDate, string id, float width, float height, float depth,
        float weight)
        => new(productionDate.AddDays(StorageLife), id, width, height, depth, weight);

    public override string ToString()
        =>
            $"Коробка с Шириной: {Width} и Высотой: {Height} и Глубиной: {Depth} и Весом: {Weight} и Объёмом: {Volume} и Срок выходит: {ExpirationDate}\n";
}