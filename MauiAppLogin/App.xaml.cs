namespace MauiAppLogin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            string? usuario_logado = null;

            Task.Run(async () =>
            {
                usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");

                if (usuario_logado == null) 
                {
                    MainPage = new Login();
                }
                else
                {
                    MainPage = new Protegida();
                }

            });

            MainPage = new Login();
        }

        protected override Window CreateWindow(IActivationState ActivationState)
        {
            var window = base.CreateWindow(ActivationState);

            window.Width = 400;
            window.Height = 700;
            
            return window;

        }

    } // fecha classe

} // fecha namespace
