using AIRE_App.Data;

namespace AIRE_App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            output.Text = UniqueID.GetDeviceID();
        }
    }
}