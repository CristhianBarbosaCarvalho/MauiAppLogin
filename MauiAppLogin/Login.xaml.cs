namespace MauiAppLogin;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{

			List<DadosUsuarios> Lista_Usuarios = new List<DadosUsuarios>()
			{
				new DadosUsuarios()
				{
					Usuario = "cristhian",
					Senha = "1234"
				},

                new DadosUsuarios()
                {
                    Usuario = "marcos",
                    Senha = "4321"
                }

            };

			DadosUsuarios dados_digitados = new DadosUsuarios()
			{
				Usuario = txt_usuario.Text,
				Senha = txt_senha.Text
			};

			if (Lista_Usuarios.Any(i => (dados_digitados.Usuario == i.Usuario && dados_digitados.Senha == i.Senha)))
			{

				await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Usuario);

				App.Current.MainPage = new Protegida();

			}
			else 
			{
				throw new Exception("Usuario ou Senha Invalidos");
			}

		}
		catch (Exception ex) 
		{
			await DisplayAlert("Ops", ex.Message, "Fechar");
		}
    }
}