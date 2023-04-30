using PageValidations.Pages;

namespace PageValidations.ViewModel;
public partial class LoginViewModel : BaseViewModel
{
    #region Propertise
    [ObservableProperty]
    private LoginModel model;
    #endregion

    #region Constructor
    public LoginViewModel()
    {
        Model = new();
    }
    #endregion

    #region Commands
    [RelayCommand]
    private async Task Login()
    {
        if (!Model.Validator.ValidateProperties())
            return;
        await Task.Delay(100);
    }

    [RelayCommand]
    private async Task Registration()
    {
        await Shell.Current.GoToAsync(nameof(RegistrationPage));
    }

    [RelayCommand]
    private async Task ForgotPassword()
    {
        await Task.CompletedTask;
    }
    #endregion
}

