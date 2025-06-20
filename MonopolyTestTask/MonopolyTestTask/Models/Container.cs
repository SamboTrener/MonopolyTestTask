namespace MonopolyTestTask.Models;

public abstract class Container
{
    public string Id { get;}
    public float Width { get;}
    public float Height { get;}
    public float Depth { get;}
    public float Weight { get; protected set; }
    
    public virtual float Volume => Width * Height * Depth;
    
    protected Container(string id, float width, float height, float depth)
    {
        Id = id;
        Width = width;
        Height = height;
        Depth = depth;
    }
}