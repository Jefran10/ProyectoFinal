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

            // Aquí puedes manejar la selección según el texto seleccionado
            switch (selectedOption)
            {
                case "Inicio":
                    // Lógica para navegar a la página de inicio
                    break;
                case "Negocios":
                    // Lógica para navegar a la página de negocios
                    break;
                case "Perfil":
                    // Lógica para navegar a la página de perfil
                    break;
                    // Agrega más casos según tus necesidades
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
                        // No se han concedido los permisos, manejar esto según tu aplicación
                        Console.WriteLine("Permiso de ubicación no concedido");
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
                    // Mostrar la ubicación en el Entry
                    LocationEntry.Text = $"Latitud: {location.Latitude}, Longitud: {location.Longitude}";

                    // Mostrar la ubicación en el mapa
                    MyMapView.Pins.Clear();
                    /*varpin = new Pin
                    {
                        Label = "Ubicación actual",
                        Location = new Location(location.Latitude, location.Longitude)
                    };
                    MyMapView.Pins.Add(pin);*/
                    MyMapView.MoveToRegion(MapSpan.FromCenterAndRadius(new Location(location.Latitude, location.Longitude), Distance.FromKilometers(1)));
                }
                else
                {
                    // No se pudo obtener la ubicación
                    Console.WriteLine("No se pudo obtener la ubicación actual");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la ubicación: {ex.Message}");
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
                        // No se han concedido los permisos, manejar esto según tu aplicación
                        Console.WriteLine("Permiso de ubicación no concedido");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al verificar los permisos de ubicación: {ex.Message}");
            }
        }
    }
}
