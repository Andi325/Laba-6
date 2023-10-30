using System;
using System.Collections.Generic;

abstract class Vehicle
{
    public int Speed { get; set; }
    public int Capacity { get; set; }

    public abstract void Move();
}

class Human : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("Human is walking");
    }
}

partial class Car : Vehicle
{
    public int FuelTankCapacity { get; set; }
    public double FuelConsumption { get; set; }

    public override void Move()
    {
        if (FuelTankCapacity > 0)
        {
            Console.WriteLine("Car is driving");
            FuelTankCapacity -= (int)(Speed * FuelConsumption); 
        }
        else
        {
            Console.WriteLine("Out of fuel. Car cannot move.");
        }
    }
}


partial class Bus : Vehicle
{
    public int NumberOfSeats { get; set; }
    public int CurrentPassengers { get; set; }

    public void BoardPassengers(int passengers)
    {
        if (CurrentPassengers + passengers <= Capacity)
        {
            CurrentPassengers += passengers;
            Console.WriteLine($"{passengers} passengers boarded the bus.");
        }
        else
        {
            Console.WriteLine($"Cannot board {passengers} passengers. Bus is full.");
        }
    }

    public void DisembarkPassengers(int passengers)
    {
        if (CurrentPassengers >= passengers)
        {
            CurrentPassengers -= passengers;
            Console.WriteLine($"{passengers} passengers disembarked from the bus.");
        }
        else
        {
            Console.WriteLine($"Cannot disembark {passengers} passengers. Not enough passengers on the bus.");
        }
    }

    public override void Move()
    {
        if (CurrentPassengers > 0)
        {
            Console.WriteLine($"Bus is moving with {CurrentPassengers} passengers on board.");
        }
        else
        {
            Console.WriteLine("Bus is empty. Cannot move.");
        }
    }
}

partial class Train : Vehicle
{
    public int NumberOfCars { get; set; }
    public int CurrentSpeed { get; private set; }

    public void IncreaseSpeed(int amount)
    {
        if (CurrentSpeed + amount <= MaxSpeed)
        {
            CurrentSpeed += amount;
            Console.WriteLine($"Train speed increased to {CurrentSpeed} km/h.");
        }
        else
        {
            Console.WriteLine($"Cannot increase speed. Maximum speed reached.");
        }
    }

    public int MaxSpeed { get; set; }

    public void DecreaseSpeed(int amount)
    {
        if (CurrentSpeed - amount >= 0)
        {
            CurrentSpeed -= amount;
            Console.WriteLine($"Train speed decreased to {CurrentSpeed} km/h.");
        }
        else
        {
            Console.WriteLine($"Cannot decrease speed further.");
        }
    }

    public override void Move()
    {
        Console.WriteLine($"Train is moving at {CurrentSpeed} km/h with {NumberOfCars} cars.");
    }
}


class Route
{
    public string StartPoint { get; set; }
    public string EndPoint { get; set; }
}

class TransportNetwork
{
    List<Vehicle> vehicles;

    public TransportNetwork()
    {
        vehicles = new List<Vehicle>();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void ControlMovement()
    {
        foreach (var vehicle in vehicles)
        {
            vehicle.Move();
        }
    }
    public Route CalculateOptimalRoute(Vehicle vehicle, Route route)
    {
        if (vehicle is Car)
        {
            Console.WriteLine("Calculating optimal route for a car...");
        }
        else if (vehicle is Bus)
        {
            Console.WriteLine("Calculating optimal route for a bus...");
        }
        else if (vehicle is Train)
        {
            Console.WriteLine("Calculating optimal route for a train...");
        }
        
        return route;
    }

}