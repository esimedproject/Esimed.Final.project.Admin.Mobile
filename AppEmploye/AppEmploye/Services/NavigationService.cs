
using AppEmploye.Helper;
using AppEmploye.Services.Interfaces;
using AppEmploye.View;
using AppEmploye.ViewModels;
using AppEmploye.ViewModels.Base;
using AppEmploye.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace AppEmploye.Services
{
    public class NavigationService : INavigationService
    {
        protected readonly Dictionary<Type, Type> _mappings;
        protected readonly IDialogService _dialogService;
        protected Application CurrentApplication
        {
            get
            {
                return Application.Current;
            }
        }

        public NavigationService(IDialogService dialogService)
        {
            _dialogService = dialogService;
            _mappings = new Dictionary<Type, Type>();

            CreatePageViewModelMappings();
        }

        public Task InitializeAsync()
        {
            if (Constant.Admin != null)
            {
                return NavigateToAsync<MainViewModel>();
            }
            else
            {
                return NavigateToAsync<LoginViewModel>();
            }

        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {

            return InternalNavigateToAsync(typeof(TViewModel), null);

        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {

            return InternalNavigateToAsync(typeof(TViewModel), parameter);

        }

        public Task NavigateToAsync(Type viewModelType)
        {

            return InternalNavigateToAsync(viewModelType, null);

        }

        public Task NavigateToAsync(Type viewModelType, object parameter)
        {

            return InternalNavigateToAsync(viewModelType, parameter);

        }

        public async Task NavigateBackAsync()
        {
            if (CurrentApplication.MainPage is MainPage)
            {
                var mainPage = CurrentApplication.MainPage as MainPage;
                await mainPage.Navigation.PopAsync();
            }
            else if (CurrentApplication.MainPage is LoginPage)
            {
                await CurrentApplication.MainPage.Navigation.PopModalAsync();
            }
            else if (CurrentApplication.MainPage != null)
            {
                await CurrentApplication.MainPage.Navigation.PopAsync();
            }
        }

        public virtual Task RemoveLastFromBackStackAsync()
        {
            var mainPage = CurrentApplication.MainPage as MainPage;

            if (mainPage != null)
            {
                mainPage.Navigation.RemovePage(
                    mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2]);
            }

            return Task.FromResult(true);
        }

        protected virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            try
            {
                Page page = CreateAndBindPage(viewModelType, parameter);

                if (page is MainPage)
                {
                    CurrentApplication.MainPage = page;
                }
                else if (page is LoginPage)
                {
                    CurrentApplication.MainPage = page;
                }
                else
                {
                    var navigationPage = CurrentApplication.MainPage as MainPage;

                    if (navigationPage != null)
                    {
                        await navigationPage.Navigation.PushModalAsync(page);
                    }
                    else
                    {
                        await CurrentApplication.MainPage.Navigation.PushModalAsync(page);
                    }
                }

                await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
            }
            catch (Exception ex)
            {
                throw ;
            }
        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!_mappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return _mappings[viewModelType];
        }

        protected Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            ViewModelBase viewModel = ViewModelLocator.Instance.Resolve(viewModelType) as ViewModelBase;
            page.BindingContext = viewModel;

            if (page is IViewWithParameters)
            {
                ((IViewWithParameters)page).InitializeWith(parameter);
            }

            return page;

        }

        private void CreatePageViewModelMappings()
        {
            //  _mappings.Add(typeof(ItemsSettingsViewModel), typeof(ItemsSettings));
            _mappings.Add(typeof(MainViewModel), typeof(MainPage));
            _mappings.Add(typeof(LoginViewModel), typeof(LoginPage));

            _mappings.Add(typeof(UserViewModel), typeof(UsersPage));
            _mappings.Add(typeof(UserDetailViewModel), typeof(UserDetailPage));

            _mappings.Add(typeof(MagazineViewModel), typeof(MagazinesPage));
            _mappings.Add(typeof(MagazineDetailViewModel), typeof(MagazineDetailPage));

            _mappings.Add(typeof(ContactViewModel), typeof(ContactPage));

            _mappings.Add(typeof(UserMagazineListViewModel), typeof(UserMagazinesListPage));
            // _mappings.Add(typeof(CategoriesSettingsViewModel), typeof(CategoriesSettings));
        }
    }
}
