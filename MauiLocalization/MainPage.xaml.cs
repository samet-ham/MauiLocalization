using MauiLocalization.Resources.Languages;
using System.Globalization;

namespace MauiLocalization;

public partial class MainPage : ContentPage
{
    public LocalizationResourceManager LocalizationResourceManager =>
        LocalizationResourceManager.Instance;

    int count = 0;

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        var switchToCulture = AppResources.Culture.TwoLetterISOLanguageName.Equals("tr", StringComparison.InvariantCultureIgnoreCase) ? new CultureInfo("en-US") : new CultureInfo("tr-TR");

        LocalizationResourceManager.Instance.SetCulture(switchToCulture);

        count++;

        CounterBtn.Text = String.Format(LocalizationResourceManager["Counter"].ToString(), count);

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}

