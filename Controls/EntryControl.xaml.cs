using System.Windows.Input;

namespace PageValidations.Controls;

public partial class EntryControl : ContentView
{
	public EntryControl()
	{
		InitializeComponent();
	}

    #region Title (Bindable Title)
    public static readonly BindableProperty EntryTitleProperty = BindableProperty.Create(
                                                                    nameof(EntryTitle),
                                                                   typeof(string),
                                                                 typeof(EntryControl),
                                                                   string.Empty);

    public string EntryTitle
    {
        get { return (string)GetValue(EntryTitleProperty); }
        set { SetValue(EntryTitleProperty, value); }
    }
    #endregion Title (Bindable text)

    #region SmartText (Bindable text)
    public static readonly BindableProperty TextProperty = BindableProperty.Create(
                                                                    nameof(Text),
                                                                   typeof(string),
                                                                 typeof(EntryControl),
                                                                   string.Empty);

    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }
    #endregion SmartText (Bindable text)

    #region ValidationField (Bindable Errors)
    public static readonly BindableProperty ErrorsProperty = BindableProperty.Create(
                                                                    nameof(Errors),
                                                                   typeof(List<string>),
                                                                 typeof(EntryControl),
                                                                   new List<string>());

    public List<string> Errors
    {
        get { return (List<string>)GetValue(ErrorsProperty); }
        set { SetValue(ErrorsProperty, value); }
    }
    #endregion ValidationField (Bindable text)

    #region ValidationField (Bindable ValidationField)
    public static readonly BindableProperty ValidationFieldProperty = BindableProperty.Create(
                                                                    nameof(ValidationField),
                                                                   typeof(string),
                                                                 typeof(EntryControl),
                                                                   string.Empty);

    public string ValidationField
    {
        get { return (string)GetValue(ValidationFieldProperty); }
        set { SetValue(ValidationFieldProperty, value); }
    }
    #endregion ValidationField (Bindable text)

    #region IsEnabled (Bindable bool)
    public static readonly new BindableProperty IsEnabledProperty = BindableProperty.Create(
                                                                  nameof(IsEnabled), //Public name to use
                                                                  typeof(bool), //this type
                                                                  typeof(EntryControl), //parent type (tihs control)
                                                                  true); //default value
    public new bool IsEnabled
    {
        get { return (bool)GetValue(IsEnabledProperty); }
        set { SetValue(IsEnabledProperty, value); }
    }
    #endregion IsEnabled (Bindable bool)

    #region Placeholder (Bindable text)
    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
                                                                    nameof(Placeholder),
                                                                   typeof(string),
                                                                 typeof(EntryControl),
                                                                   string.Empty);

    public string Placeholder
    {
        get { return (string)GetValue(PlaceholderProperty); }
        set { SetValue(PlaceholderProperty, value); }
    }
    #endregion Placeholder (Bindable text)

    #region FontSize (Bindable double)
    public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
                                                                  nameof(FontSize), //Public name to use
                                                                  typeof(double), //this type
                                                                  typeof(EntryControl), //parent type (tihs control)
                                                                  14.0); //default value
    public double FontSize
    {
        get { return (double)GetValue(FontSizeProperty); }
        set { SetValue(FontSizeProperty, value); }
    }
    #endregion FontSize (Bindable double)

    #region Icon (Bindable text)
    public static readonly BindableProperty IconProperty = BindableProperty.Create(
                                                                    nameof(Icon),
                                                                   typeof(string),
                                                                 typeof(EntryControl),
                                                                   string.Empty);
    public string Icon
    {
        get { return (string)GetValue(IconProperty); }
        set { SetValue(IconProperty, value); }
    }
    #endregion Icon (Bindable text)

    #region IconWidth (Bindable double)
    public static readonly BindableProperty IconWidthProperty = BindableProperty.Create(
                                                                  nameof(IconWidth), //Public name to use
                                                                  typeof(double), //this type
                                                                  typeof(EntryControl), //parent type (tihs control)
                                                                  14.0); //default value
    public double IconWidth
    {
        get { return (double)GetValue(IconWidthProperty); }
        set { SetValue(IconWidthProperty, value); }
    }
    #endregion IconWidth (Bindable double)

    #region IsPassword (Bindable bool)
    public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(
                                                                  nameof(IsPassword), //Public name to use
                                                                  typeof(bool), //this type
                                                                  typeof(EntryControl), //parent type (tihs control)
                                                                  false); //default value
    public bool IsPassword
    {
        get { return (bool)GetValue(IsPasswordProperty); }
        set { SetValue(IsPasswordProperty, value); }
    }

    #endregion IsPassword (Bindable bool)

    #region MaxLength (Bindable int)
    public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create(
                                                                  nameof(MaxLength), //Public name to use
                                                                  typeof(int), //this type
                                                                  typeof(EntryControl), //parent type (tihs control)
                                                                  100); //default value
    public int MaxLength
    {
        get { return (int)GetValue(MaxLengthProperty); }
        set { SetValue(MaxLengthProperty, value); }
    }
    #endregion MaxLength (Bindable int)

    #region Keyboard (Bindable int)
    public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(
                                                                  nameof(Keyboard), //Public name to use
                                                                  typeof(Keyboard), //this type
                                                                  typeof(EntryControl), //parent type (tihs control)
                                                                  Keyboard.Default); //default value
    public Keyboard Keyboard
    {
        get { return (Keyboard)GetValue(KeyboardProperty); }
        set { SetValue(KeyboardProperty, value); }
    }
    #endregion Keyboard (Bindable int)

    #region Bindable Command
    public static readonly BindableProperty CommandProperty =
       BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(EntryControl), null);

    public ICommand Command
    {
        get { return (ICommand)GetValue(CommandProperty); }
        set { SetValue(CommandProperty, value); }
    }
    #endregion
}