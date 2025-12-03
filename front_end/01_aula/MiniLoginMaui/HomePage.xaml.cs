using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniLoginMaui
{
    [QueryProperty(nameof(Username), "username")]
    [QueryProperty(nameof(Profile), "profile")]

    public partial class HomePage : ContentPage
    {
        public string Username { get; set; } = string.Empty;
        public string Profile { get; set; } = string.Empty;

        public HomePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            WelcomeLabel.Text = $"Ola, {Username}!";
            ProfileLabel.Text = $"Perfil: {Profile}";

        }

        private async Task OnLogoutClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
        private async Task OnLoginClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainPage");
        }


    }


    
}
