using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _06_Classes
{
    public enum VehicleType { Car, Truck, StationWagon, SUV, Motorcycle, ATV, Spaceship, Boar, HorseAndBuggy}
    public class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal Mileage { get; set; }
        public VehicleType TypeOfVehicle { get; set; }

        public Vehicle() { }
        public Vehicle(string make, string model, decimal mileage, VehicleType type)
        {
            Make = make;
            Model = model;
            Mileage = mileage;
            TypeOfVehicle = type;
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        private string _lastname;
        public string LastName
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public string FullName
        {
            get { return $"{FirstName} {LastName}";  }
        }

        public DateTime DOB { get; set; }

        public int Age
        {
            get
            {
                TimeSpan timeSpan = DateTime.Now - DOB;
                double totalAgeInYears = timeSpan.TotalDays / 365.25;
                int yearsOld = Convert.ToInt32(Math.Floor(totalAgeInYears));
                return yearsOld;
            }
        }

        public bool IsAdult
        {
            get
            {
                if (Age >= 21)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Person() { }
        public Person(string firstName, string lastName, DateTime dob)
        {
            FirstName = firstName;
            LastName = lastName;
            DOB = dob;
        }
    }

    public enum WBMaterialType { Plastic, Metal, Rubber}
    public class Waterbottle
    {
        public string BottleLength { get; set; }
        public string BottleWidth { get; set; }
        public int BottleGallons { get; set; }
        public WBMaterialType TypeOfMaterial { get; set; }
        public Waterbottle(string bottleLength, string bottleWidth, int bottleGallons, WBMaterialType matType)
        {
            BottleLength = bottleLength;
            BottleWidth = bottleWidth;
            BottleGallons = bottleGallons;
            TypeOfMaterial = matType;
        }
    }
}
