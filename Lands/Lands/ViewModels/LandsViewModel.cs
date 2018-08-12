namespace Lands.ViewModels
{
    using Models;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using Xamarin.Forms;

    public class LandsViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<Country> countries;
        #endregion

        #region Properties
        public ObservableCollection<Country> Countries
        {
            get { return this.countries; }
            set { SetValue(ref this.countries, value); }
        }
        #endregion

        #region Constructor
        public LandsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadLands();
        }
        #endregion

        #region Methods
        private async void LoadLands()
        {
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            var response = await this.apiService.GetList<Country>(
                "http://restcountries.eu",
                "/rest",
                "/v2/all");

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            var list = (List<Country>)response.Result;
            this.Countries = new ObservableCollection<Country>(list);

        }
        #endregion
    }
}
