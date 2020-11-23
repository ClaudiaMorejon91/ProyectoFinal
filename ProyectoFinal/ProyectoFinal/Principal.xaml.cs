using ProyectoFinal.Clases;
using ProyectoFinal.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Principal : ContentPage
    {
        public Principal()
        {
            InitializeComponent();
            
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                UserData userData = new UserData();
                var result = await userData.getUserData(Convert.ToInt32(Settings.IdUserLogged));
                if (result.Count() > 0)
                {
                    await DisplayAlert("Success", result.ElementAt(0).name, "Aceptar", "Cancelar");
                }
                else
                {
                    await DisplayAlert("Error", "Usuario o clave incorrecta", "Aceptar", "Cancelar");
                }
            }
            catch (Exception e1)
            {
                await DisplayAlert("Alerta", "ERROR: " + e1.Message, "OK");
            }
        }
    }
}