using FunPayApp.Models;
using System;
using System.Collections.Generic;
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
        public MapLocationPage()
        {
            InitializeComponent();

            Task.Delay(2000);

            OpenMapPin();

            //OpenMapLoaction();

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
        private void OpenMapPin()
        {
            try
            {

                //預設定位=>台北車站
                Position position = new Position(25.047955535854893, 121.5178990536724);
                MapSpan mapSpan = MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(100));

                Xamarin.Forms.Maps.Map pinmap = new Xamarin.Forms.Maps.Map(mapSpan)
                {
                    //顯示街道地圖
                    MapType = MapType.Street,
                    //允許縮放
                    HasZoomEnabled = true,
                    //顯示使用者的位置
                    IsShowingUser = false,  
                };

                
                Pin pin = new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(25.044408803729674, 121.52938387998931),
                    Label = "華山",
                    Address = "台北市中正區八德路一段1號",
                };

                pinmap.Pins.Add(pin);

                pinmap.MoveToRegion(mapSpan);

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}