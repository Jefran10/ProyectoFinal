using Microsoft.Maui.Controls;
using Microsoft.Maui.Maps;
using System;
using System.Threading.Tasks;

namespace ProyectoFinal.View
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
            CheckAndRequestLocationPermissions();
        }

        private void MenuListView_ItemSelected_1(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            string selectedOption = e.SelectedItem.ToString();

            // Aqu� puedes manejar la selecci�n seg�n el texto seleccionado
            switch (selectedOption)
            {
                case "Inicio":
                    // L�gica para navegar a la p�gina de inicio
                    break;
                case "Negocios":
                    // L�gica para navegar a la p�gina de negocios
                    break;
                case "Perfil":
                    // L�gica para navegar a la p�gina de perfil
                    break;
                    // Agrega m�s casos seg�n tus necesidades
            }

            // Deseleccionar el elemento para que pueda seleccionarse nuevamente
            ((ListView)sender).SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetAndDisplayCurrentLocation();
        }

        private async void GetAndDisplayCurrentLocation()
        {
            try

            {
                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                    if (status != PermissionStatus.Granted)
                    {
                        // No se han concedido los permisos, manejar esto seg�n tu aplicaci�n
                        Console.WriteLine("Permiso de ubicaci�n no concedido");
                        return;
                    }
                }

                var location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Best,
                    Timeout = TimeSpan.FromSeconds(30)
                });

                if (location != null)
                {
                    // Mostrar la ubicaci�n en el Entry
                    LocationEntry.Text = $"Latitud: {location.Latitude}, Longitud: {location.Longitude}";

                    // Mostrar la ubicaci�n en el mapa
                    MyMapView.Pins.Clear();
                    /*varpin = new Pin
                    {
                        Label = "Ubicaci�n actual",
                        Location = new Location(location.Latitude, location.Longitude)
                    };
                    MyMapView.Pins.Add(pin);*/
                    MyMapView.MoveToRegion(MapSpan.FromCenterAndRadius(new Location(location.Latitude, location.Longitude), Distance.FromKilometers(1)));
                }
                else
                {
                    // No se pudo obtener la ubicaci�n
                    Console.WriteLine("No se pudo obtener la ubicaci�n actual");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la ubicaci�n: {ex.Message}");
            }
        }

        private async void CheckAndRequestLocationPermissions()
        {
            try
            {
                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                    if (status != PermissionStatus.Granted)
                    {
                        // No se han concedido los permisos, manejar esto seg�n tu aplicaci�n
                        Console.WriteLine("Permiso de ubicaci�n no concedido");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al verificar los permisos de ubicaci�n: {ex.Message}");
            }
        }
    }
}
