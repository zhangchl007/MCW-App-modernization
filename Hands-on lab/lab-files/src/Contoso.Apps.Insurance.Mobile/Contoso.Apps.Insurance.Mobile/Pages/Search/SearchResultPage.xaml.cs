using System;
using CIMobile.Pages.Base;
using CIMobile.ViewModels.Search;

namespace CIMobile.Pages.Search
{
	public partial class SearchResultPage : SearchResultPageXaml
    {
		public SearchResultPage ()
		{
			InitializeComponent ();
		}

	    private void Button_OnClicked(object sender, EventArgs e)
	    {
	        ViewModel.OpenPdfCommand.Execute(null);
	    }
	}

    public abstract class SearchResultPageXaml : ModelBoundContentPage<SearchResultViewModel>
    {
        
    }
}
