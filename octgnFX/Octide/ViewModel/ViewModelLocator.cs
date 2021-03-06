/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Octide"
                           x:Key="Locator" />
  </Application.Resources>

  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;

namespace Octide.ViewModel
{
    using CommonServiceLocator;

    using Ninject;
    using Octide.ItemModel;

	/// <summary>
	/// This class contains static references to all the view models in the
	/// application and provides an entry point for the bindings.
	/// </summary>
	public class ViewModelLocator
	{
		public static IKernel ViewModelKernel = new StandardKernel();
		public static IServiceLocator CurrentServiceLocator = new NInjectServiceLocator(ViewModelKernel);

		static ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(new ServiceLocatorProvider(() => CurrentServiceLocator));
		}

		/// <summary>
		/// Initializes a new instance of the ViewModelLocator class.
		/// </summary>
		public ViewModelLocator()
		{
			if (ViewModelBase.IsInDesignModeStatic)
			{
				// Create design time view services and models
				//SimpleIoc.Default.Register<IDataService, DesignDataService>();
			}
			else
			{
				// Create run time view services and models
				//SimpleIoc.Default.Register<IDataService, DataService>();
			}

			ViewModelLocator.ViewModelKernel.Bind<GameLoader>().To<GameLoader>().InSingletonScope();
			ViewModelLocator.ViewModelKernel.Bind<GameTabViewModel>().To<GameTabViewModel>().InSingletonScope();
			ViewModelLocator.ViewModelKernel.Bind<ActionViewModel>().To<ActionViewModel>().InSingletonScope();
			ViewModelLocator.ViewModelKernel.Bind<ActionMenuViewModel>().To<ActionMenuViewModel>().InSingletonScope();
			ViewModelLocator.ViewModelKernel.Bind<AssetsTabViewModel>().To<AssetsTabViewModel>().InSingletonScope();
			ViewModelLocator.ViewModelKernel.Bind<SymbolTabViewModel>().To<SymbolTabViewModel>().InSingletonScope();
			ViewModelLocator.ViewModelKernel.Bind<DocumentTabViewModel>().To<DocumentTabViewModel>().InSingletonScope();
			ViewModelLocator.ViewModelKernel.Bind<SoundTabViewModel>().To<SoundTabViewModel>().InSingletonScope();
			ViewModelLocator.ViewModelKernel.Bind<PropertyTabViewModel>().To<PropertyTabViewModel>().InSingletonScope();
			ViewModelLocator.ViewModelKernel.Bind<SetTabViewModel>().To<SetTabViewModel>().InSingletonScope();
			ViewModelLocator.ViewModelKernel.Bind<ProxyTabViewModel>().To<ProxyTabViewModel>().InSingletonScope();
			ViewModelLocator.ViewModelKernel.Bind<ProxyOverlayViewModel>().To<ProxyOverlayViewModel>().InSingletonScope();
			ViewModelLocator.ViewModelKernel.Bind<ProxyTextBlockViewModel>().To<ProxyTextBlockViewModel>().InSingletonScope();
			ViewModelLocator.ViewModelKernel.Bind<PreviewTabViewModel>().To<PreviewTabViewModel>().InSingletonScope();
		}


		public static GameLoader GameLoader => ServiceLocator.Current.GetInstance<GameLoader>();
		public static GameTabViewModel GameTabViewModel => ServiceLocator.Current.GetInstance<GameTabViewModel>();
		public static ActionViewModel ActionViewModel => ServiceLocator.Current.GetInstance<ActionViewModel>();
		public static ActionMenuViewModel ActionMenuViewModel => ServiceLocator.Current.GetInstance<ActionMenuViewModel>();
		public static AssetsTabViewModel AssetsTabViewModel => ServiceLocator.Current.GetInstance<AssetsTabViewModel>();
		public static SoundTabViewModel SoundTabViewModel => ServiceLocator.Current.GetInstance<SoundTabViewModel>();
		public static DocumentTabViewModel DocumentTabViewModel => ServiceLocator.Current.GetInstance<DocumentTabViewModel>();
		public static SymbolTabViewModel SymbolTabViewModel => ServiceLocator.Current.GetInstance<SymbolTabViewModel>();
		public static PropertyTabViewModel PropertyTabViewModel => ServiceLocator.Current.GetInstance<PropertyTabViewModel>();
		public static SetTabViewModel SetTabViewModel => ServiceLocator.Current.GetInstance<SetTabViewModel>();
		public static ProxyTabViewModel ProxyTabViewModel => ServiceLocator.Current.GetInstance<ProxyTabViewModel>();
		public static ProxyOverlayViewModel ProxyOverlayViewModel => ServiceLocator.Current.GetInstance<ProxyOverlayViewModel>();
		public static ProxyTextBlockViewModel ProxyTextBlockViewModel => ServiceLocator.Current.GetInstance<ProxyTextBlockViewModel>();
		public static PreviewTabViewModel PreviewTabViewModel => ServiceLocator.Current.GetInstance<PreviewTabViewModel>();

		public static void Cleanup()
		{
			ServiceLocator.Current.GetInstance<MainViewModel>().Cleanup();
			ServiceLocator.Current.GetInstance<GameTabViewModel>().Cleanup();
			ServiceLocator.Current.GetInstance<ActionViewModel>().Cleanup();
			ServiceLocator.Current.GetInstance<ActionMenuViewModel>().Cleanup();
			ServiceLocator.Current.GetInstance<AssetsTabViewModel>().Cleanup();
			ServiceLocator.Current.GetInstance<SoundTabViewModel>().Cleanup();
			ServiceLocator.Current.GetInstance<DocumentTabViewModel>().Cleanup();
			ServiceLocator.Current.GetInstance<SymbolTabViewModel>().Cleanup();
			ServiceLocator.Current.GetInstance<PropertyTabViewModel>().Cleanup();
			ServiceLocator.Current.GetInstance<SetTabViewModel>().Cleanup();
		//	ServiceLocator.Current.GetInstance<ProxyTabViewModel>().Cleanup();
			ServiceLocator.Current.GetInstance<ProxyOverlayViewModel>().Cleanup();
			ServiceLocator.Current.GetInstance<ProxyTextBlockViewModel>().Cleanup();
			ServiceLocator.Current.GetInstance<PreviewTabViewModel>().Cleanup();
		}
	}
}