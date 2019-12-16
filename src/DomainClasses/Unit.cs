using System;

namespace EFNewFeature.DomainClasses
{
    public class Unit
    {
        public int UnitId { get; set; }
        public Location Location { get; set; }
        public BrewerType BrewType { get; set; }
        public DateTime Acquired { get; set; }
    }

    public class BrewerType
    {
        public int BrewerTypeId { get; set; }
        public string Description { get; set; }

        public Recipe Recipe { get; set; }
    }

    public class Recipe
    {
        public int WaterTemperature { get; set; }
        public int GrindSize { get; set; }
        public int GrindOunces { get; set; }
        public int WaterOunces { get; set; }
        public int BrewMinutes { get; set; }
        public string Description { get; set; }

    }
}