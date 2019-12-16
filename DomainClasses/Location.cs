using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFNewFeature.DomainClasses
{
    public class Location
    {
        public Location(string streetAddress, string openTime, string closeTime)
        {
            StreetAddress = streetAddress;
            OpenTime = openTime;
            CloseTime = closeTime;
            LocationId = Guid.NewGuid();
        }
        public Guid LocationId { get; private set; }
        public string StreetAddress { get; private set; }
        public string OpenTime { get; private set; }
        public string CloseTime { get; private set; }

        public List<Unit> BrewingUnits { get; set; }
    }
}
