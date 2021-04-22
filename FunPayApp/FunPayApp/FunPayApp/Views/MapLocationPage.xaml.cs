using FunPayApp.Models;
using FunPayApp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace FunPayApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapLocationPage : ContentPage
    {
        MapLocationPageViewModel mapLocationPageViewModel;
        

        public MapLocationPage()
        {
            InitializeComponent();

            BindingContext = mapLocationPageViewModel = new MapLocationPageViewModel();

            OpenMapPin();

        }


        /// <summary>
        /// Open Location Map
        /// </summary>
        private async void OpenMapLoaction()
        {
            try
            {
                //預設定位=>台北車站
                //Location location = new Location(25.047955535854893, 121.5178990536724);

                //設定地理位置精確度
                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.High);
                //定位地理位置
                Location location = await Geolocation.GetLocationAsync(request);

                //顯示座標
                MapLaunchOptions options = new MapLaunchOptions
                {
                    //Name:地標名稱
                    Name = "NowLocation",

                    //NavigationMode:路線模式
                    NavigationMode = NavigationMode.None
                };

                //開啟地圖
                await Xamarin.Essentials.Map.OpenAsync(location, options);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Pin Marker by address
        /// </summary>
        private async void OpenMapPin()
        {
            try
            {
                var context = await mapLocationPageViewModel.LoadPin();
                Geocoder geoCoder = new Geocoder();
                IEnumerable<Position> approximateLocations = await geoCoder.GetPositionsForAddressAsync("台北市中正區八德路一段1號");
                Position position = approximateLocations.FirstOrDefault();

                Location location = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.High));
                Distance distance4 = Distance.(position, position);

                foreach (var marker in context)
                {
                    Pin pin = new Pin
                    {
                        Type = PinType.Place,
                        Position = position,
                        Label ="VIew"
                    };

                    pinmap.Pins.Add(pin);
                }

                

                pinmap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Longitude, location.Longitude), Distance.FromMiles(1500)));

            }
            catch (Exception)
            {
                throw;
            }

        }


        
    }
}