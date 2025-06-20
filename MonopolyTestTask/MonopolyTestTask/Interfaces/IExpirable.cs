namespace MonopolyTestTask.Interfaces;

public interface IExpirable
{
    public DateOnly ExpirationDate { get; set; }
}