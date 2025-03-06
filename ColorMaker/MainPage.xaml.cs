using System.Diagnostics;

namespace ColorMaker
{
    public partial class MainPage : ContentPage
    {
        public bool isRandom = false;

        public string hexValue="#000000";

        public MainPage()
        {
            InitializeComponent();

        }

        private void sld_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (!isRandom)
            {
                var red = sldRed.Value;
                var green = sldGreen.Value;
                var blue = sldBlue.Value;
                Color color = Color.FromRgb(red, green, blue);
                SetColor(color);
            }

        }
        private void SetColor(Color color)
        {
            Debug.WriteLine(color.ToString());
            btnRandom.BackgroundColor = color;
            Container.BackgroundColor = color;
            lblHex.Text = color.ToHex();
            hexValue = color.ToHex();
        }

        private void btnRandom_Clicked(object sender, EventArgs e)
        {
            isRandom = true;
            var random = new Random();
            var color = Color.FromRgb(random.Next(255), random.Next(255), random.Next(255));
            SetColor(color);
            sldRed.Value = color.Red;
            sldGreen.Value = color.Green;
            sldBlue.Value = color.Blue;
            isRandom = false;
        }

        private async void ImageButton_ClickedAsync(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(hexValue);
            var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Color copied", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
            if (DeviceInfo.Platform == DevicePlatform.Android) await toast.Show();
        }


    }

}
