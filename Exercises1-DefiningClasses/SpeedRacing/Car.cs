using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRacing
{
  public class Car
  {
      private string model;
      private double fuelConsumptionFor1km;
      private double fuelAmount;
      private double distanceTraveled;

        //<Model> <FuelAmount> <FuelConsumptionFor1km>”
      public Car(string model, double fuelAmount, double fuelConsumptionFor1km)
      {
          this.Model = model;
          this.FuelAmount = fuelAmount;
          this.FuelConsumptionFor1km = this.fuelConsumptionFor1km;
          this.DistanceTraveled = 0;
      }

      public string Model
      {
          get { return this.model; }
            set { this.model = value; }
      }

      public double FuelAmount
      {
          get { return this.fuelAmount; }
            set { this.fuelAmount = value; }
          
      }

      public double FuelConsumptionFor1km
      {
          get { return this.fuelConsumptionFor1km; }
            set { this.fuelConsumptionFor1km = value; }
      }
      public double DistanceTraveled
        { get { return this.distanceTraveled; }
            set { this.distanceTraveled = value; }
        }

      public bool CanCarMoveDistance(double distance)
      {
          if (this.fuelAmount >= (this.fuelConsumptionFor1km * distance))
          {
              return true;
          }
          return false;
      }
    }
}
