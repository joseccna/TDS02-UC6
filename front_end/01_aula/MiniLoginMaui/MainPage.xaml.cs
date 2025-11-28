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
                Feedback.TextColor = Colors.Yellow;
            }

        }

    }

}
