namespace TilterDemo
{
    using Microsoft.Phone.Controls;

    using TilterDemo.ViewModels;

    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Wiring up the datacontext in this way and in the page 
            // constructor is not a recommended approach but I'm trying to 
            // make this demo as simple as possible
            DataContext = new MainPageViewModel();
        }
    }
}
