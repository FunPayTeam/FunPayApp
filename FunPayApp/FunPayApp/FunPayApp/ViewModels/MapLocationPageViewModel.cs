using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Essentials;

namespace FunPayApp.ViewModels
{
    public class MapLocationPageViewModel
    {

        public MapLocationPageViewModel()
        {
           
        }

        public class VehicleLocations
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }

        }

        internal async Task<List<VehicleLocations>> LoadPin()
        {

            //double distance = Location.CalculateDistance(sourceCoordinates, destinationCoordinates, DistanceUnits.Miles);

            List<VehicleLocations> _pins = new List<VehicleLocations>()
            {
                new VehicleLocations{ Latitude=25.04496179196574,Longitude=121.52330638684155 },
                new VehicleLocations{ Latitude=24.04496179196574,Longitude=120.52330638684155 },
                new VehicleLocations{ Latitude=23.04496179196574,Longitude=121.52330638683333 },
                new VehicleLocations{ Latitude=22.04496179196574,Longitude=121.12345678901234 },
                new VehicleLocations{ Latitude=21.04496179196574,Longitude=120.12345678901234 },
            };

            return  _pins;
        }
    }
}