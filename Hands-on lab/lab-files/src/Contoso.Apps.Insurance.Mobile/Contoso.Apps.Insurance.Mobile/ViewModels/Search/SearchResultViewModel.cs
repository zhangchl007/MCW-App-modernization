using System.Threading.Tasks;
using CIMobile.ViewModels.Base;
using CIMobile.Services;
using CIMobile.Statics;
using CIMobile.Models.Local;
using Xamarin.Forms;
using CIMobile.Pages.Search;

namespace CIMobile.ViewModels.Search
{
    public class SearchResultViewModel : BaseViewModel
    {
        Value _result;
        public Value Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged("Result");
            }
        }

        readonly IServiceCalls _dataService;

        public SearchResultViewModel(Value result)
        {
            this.Title = "PDF Search Result";
            //this.Icon = "list.png";

            _dataService = DependencyService.Get<IServiceCalls>();
            Result = result;

            MessagingCenter.Subscribe<Value>(this, MessagingServiceConstants.ACCOUNT, (account) =>
            {
                IsInitialized = false;
            });
        }

        Command _openPdfCommand;

        /// <summary>
        /// Command to open policy Pdf file.
        /// </summary>
        public Command OpenPdfCommand
        {
            get { return _openPdfCommand ?? (_openPdfCommand = new Command(async () => await ExecuteOpenPdfCommand())); }
        }

        private async Task ExecuteOpenPdfCommand()
        {
            IsBusy = true;
            OpenPdfCommand.ChangeCanExecute();

            var fileLink = $"{ApplicationSettings.BlobContainerUrl}/{Result.metadata_storage_name}";

            await Navigation.PushAsync(new WebViewPage(fileLink));

            IsBusy = false;
            OpenPdfCommand.ChangeCanExecute();
        }

    }
}
