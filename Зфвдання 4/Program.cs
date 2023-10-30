using System;
using System.Collections.Generic;

abstract class GraphicPrimitive
{
    public int X { get; set; }
    public int Y { get; set; }

    public abstract void Draw();

    public void Move(int x, int y)
    {
        X += x;
        Y += y;
    }
}

class Circle : GraphicPrimitive
{
    public int Radius { get; set; }

    public override void Draw()
    {
        Console.WriteLine($"Drawing Circle at ({X}, {Y}) with radius {Radius}");
    }

    public void Scale(float factor)
    {
        Radius = (int)(Radius * factor);
    }
}

class Rectangle : GraphicPrimitive
{
    public int Width { get; set; }
    public int Height { get; set; }

    public override void Draw()
    {
        Console.WriteLine($"Drawing Rectangle at ({X}, {Y}) with width {Width} and height {Height}");
    }

    public void Scale(float factor)
    {
        Width = (int)(Width * factor);
        Height = (int)(Height * factor);
    }
}

class Triangle : GraphicPrimitive
{
    public int Side1 { get; set; }
    public int Side2 { get; set; }
    public int Side3 { get; set; }

    public override void Draw()
    {
        Console.WriteLine($"Drawing Triangle at ({X}, {Y}) with sides {Side1}, {Side2}, {Side3}");
    }

    public void Scale(float factor)
    {
        Side1 = (int)(Side1 * factor);
        Side2 = (int)(Side2 * factor);
        Side3 = (int)(Side3 * factor);
    }
}

class Group : GraphicPrimitive
{
    private List<GraphicPrimitive> elements = new List<GraphicPrimitive>();

    public void AddElement(GraphicPrimitive element)
    {
        elements.Add(element);
    }

    public override void Draw()
    {
        foreach (var element in elements)
        {
            element.Draw();
        }
    }

    public void Move(int x, int y)
    {
        base.Move(x, y);
        foreach (var element in elements)
        {
            element.Move(x, y);
        }
    }
}