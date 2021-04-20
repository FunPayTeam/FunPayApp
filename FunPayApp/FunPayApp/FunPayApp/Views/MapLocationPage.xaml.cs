using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FunPayApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapLocationPage : ContentPage
    {
        public MapLocationPage()
        {
            InitializeComponent();

            OpenMapLoaction();

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
                await Map.OpenAsync(location, options);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}