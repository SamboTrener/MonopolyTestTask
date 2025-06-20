using System.Text;
using MonopolyTestTask.Interfaces;

namespace MonopolyTestTask.Models;

public class Pallet : Container, IExpirable
{
    private const int OwnWeight = 30;

    public DateOnly ExpirationDate { get; set; }
    public List<Box> Boxes { get; } = [];

    public override float Volume => Width * Height * Depth + Boxes.Sum(x => x.Volume);
    
    public Pallet(string id, float width, float height, float depth) : base(id, width, height, depth)
    {
        Weight = OwnWeight;
        ExpirationDate = DateOnly.MaxValue; 
    }

    public bool TryAddBox(Box box)
    {
        if (box.Width > Width || box.Depth > Depth)
        {
            return false;
        }
        
        Boxes.Add(box);
        Weight += box.Weight;
        if (box.ExpirationDate < ExpirationDate)
        {
            ExpirationDate = box.ExpirationDate;
        }
        return true;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Паллета c Id={Id}, Шириной: {Width}, Выостой: {Height}, Глубиной: {Depth}, Весом: {Weight}, " +
                  $"Объёмом: {Volume} и Срок выходит: {ExpirationDate} содержит коробки:");
        foreach (var box in Boxes)
        {
            sb.Append(box);
        }
        return sb.ToString();
    }
}