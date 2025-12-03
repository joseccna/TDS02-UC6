using System.Threading.Tasks;

namespace MiniLoginMaui
{
    public partial class MainPage : ContentPage
    {
        private string _currentProfile = "Administrador";
        public MainPage()
        {
            InitializeComponent();

            Feedback.Text = "Preencha seus dados para entrar";
        }
        private void OnUsernameTextChanged(object sender, TextChangedEventArgs e)
        {
            // Atualiza o feedback quando o usuário digita o nome de usuário

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                Feedback.Text = $"O nome de usuário não pode esta vazio.";
                Feedback.TextColor = Colors.Red;

            }
            else
            {
                Feedback.Text = $"Olá, {e.NewTextValue}! Escollhar seu perfil e clique qm Entrar";
                Feedback.TextColor = Colors.Black;
            }

        }

        private void OnProfileChanged(object sender, EventArgs e)
        {
          if (PerfilPicker.SelectedIndex == -1)
            {
                _currentProfile = "Administrador";
                return;
            }

            _currentProfile = PerfilPicker.Items[PerfilPicker.SelectedIndex];

            Feedback.Text = $"Perfil selecionado: {_currentProfile}";
            Feedback.TextColor = Colors.Black;
        }

        private async Task OnLoginClicked(object sender, EventArgs e)
        {
            var username = UserNameEntry.Text;
            var password = SenhaEntry.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                Feedback.Text = "Usuario e senha sao obrigatórios.";
                Feedback.TextColor = Colors.Red;
                return;

            }

            Feedback.Text = $"Bem-vindo, {username}! Voce entrou como {_currentProfile}.";
            Feedback.TextColor = Colors.Green;

            var route = $"{nameof(HomePage)}? username = " +
                $"{Uri.EscapeDataString(username)} &profile=" +
                $"{Uri.EscapeDataString(_currentProfile)}";

            await Shell.Current.GoToAsync(route);


        }

        public void LoginButton_Clicked(object sender, EventArgs e)
        {
            UserNameEntry.Text = "JoseSilva";
            DisplayActionSheet("Teste", "Mensagem de teste", "Cancel", ["Botao1", "Botao2"]);


        }
    }

}
