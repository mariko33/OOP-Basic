
    using System;

public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumationForKm;
        private int distanceTraveled;

        public Car(string model, double fuelAmount, double fuelConsumationForKm)
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.fuelConsumationForKm = fuelConsumationForKm;
            this.distanceTraveled = 0;
        }
        
        public string Model { get=>this.model; set=>this.model=value; }
        public double FuelAmount { get=>this.fuelAmount; set=>this.fuelAmount=value; }
        public double FuelConsumationForKm { get=>this.fuelConsumationForKm; set=>this.fuelConsumationForKm=value; }
        public int DistanceTraveled => this.distanceTraveled;

        public void CarMove(int km)
        {
            if (this.FuelConsumationForKm*km<=this.FuelAmount)
            {
                this.distanceTraveled += km;
                this.FuelAmount -= this.FuelConsumationForKm * km;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
        
    }
