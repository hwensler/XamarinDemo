namespace PortableVersion.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadApplication(new PortableVersion.App());
        }
    }
}