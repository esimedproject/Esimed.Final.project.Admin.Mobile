using AppEmploye.DataServices;
using AppEmploye.DataServices.Interface;
using AppEmploye.Services;
using AppEmploye.Services.Interfaces;
using System;
using Unity;
using Unity.Lifetime;

namespace AppEmploye.ViewModels.Base
{
    public class ViewModelLocator
    {
        private readonly IUnityContainer _unityContainer;

        private static readonly ViewModelLocator _instance = new ViewModelLocator();

        public static ViewModelLocator Instance
        {
            get
            {
                return _instance;
            }
        }

        protected ViewModelLocator()
        {
            _unityContainer = new UnityContainer();
            _unityContainer.AddExtension(new Diagnostic());

            // Providers

            // Services
            _unityContainer.RegisterType<IDialogService, DialogService>();
            RegisterSingleton<INavigationService, NavigationService>();




            //DataServices
            _unityContainer.RegisterType<IClientServices, UsersServices>();
            _unityContainer.RegisterType<IContactServices, ContactServices>();

            _unityContainer.RegisterType<IMagazineServices, MagazinesServices>();
            _unityContainer.RegisterType<IAdminServices, AdminsServices>();


            // View models
            _unityContainer.RegisterType<MainViewModel>();
            _unityContainer.RegisterType<LoginViewModel>();

            _unityContainer.RegisterType<UserViewModel>();
            _unityContainer.RegisterType<UserDetailViewModel>();

            _unityContainer.RegisterType<MagazineViewModel>();
            _unityContainer.RegisterType<MagazineDetailViewModel>();

            _unityContainer.RegisterType<ContactViewModel>();

            _unityContainer.RegisterType<UserMagazineListViewModel>();



        }

        public T Resolve<T>()
        {
            return _unityContainer.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _unityContainer.Resolve(type);
        }

        public void Register<T>(T instance)
        {
            _unityContainer.RegisterInstance<T>(instance);
        }

        public void Register<TInterface, T>() where T : TInterface
        {
            _unityContainer.RegisterType<TInterface, T>();
        }

        public void RegisterSingleton<TInterface, T>() where T : TInterface
        {
            _unityContainer.RegisterType<TInterface, T>(new ContainerControlledLifetimeManager());
        }
    }
}
