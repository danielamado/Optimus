using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Optimus
{
    public partial class App : Application
    {
        public static bool UseMockDataStore = true;
        public static string BackendUrl = "https://localhost:5000";
        public static MasterDetailPage Master { get; set; }

        public App()
        {
            InitializeComponent();

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<CloudDataStore>();
            /*
            if (Device.RuntimePlatform == Device.iOS)
                MainPage = new MainPage();
            else
                MainPage = new NavigationPage(new MainPage());*/
            MainPage = new InicialPage();
        }

        public async static Task GoTo(Page page, int aba)
        {
            //NavigationPage.SetBackButtonTitle(App.Master.Detail,"Voltar");
            //NavigationPage.SetBackButtonTitle(page, "Voltar");
            //await App.Master.Detail.Navigation.PushAsync(page);
            //App.Master.Children[aba] = page;
        }

    }
}
