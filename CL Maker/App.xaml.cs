using Syncfusion.Licensing;

namespace CL_Maker
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new AppShell();
			SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NHaF5cXmVCf1JpRGBGfV5yd0VHYVZVRHxcR00DNHVRdkdgWH5ednZWQmBfVERwWEI=");
		}
	}
}