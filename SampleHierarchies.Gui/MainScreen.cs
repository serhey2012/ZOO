using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using SampleHierarchies.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Application main screen.
/// </summary>
public sealed class MainScreen : Screen
{
    #region Properties And Ctor

    private ISettings _settings;


    /// <summary>
    /// Data service.
    /// </summary>
    private IDataService _dataService;

    /// <summary>
    /// Animals screen.
    /// </summary>
    private AnimalsScreen _animalsScreen;

    /// <summary>
    /// Settings service
    /// </summary>
    private ISettingsService _settingsService;

    /// <summary>
    /// Creat settings screen
    /// </summary>
    private CreatSettingsScreen _creatSettingsScreen;


    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="animalsScreen">Animals screen</param>
    public MainScreen(
        ISettings settings,
        IDataService dataService,
        AnimalsScreen animalsScreen,
        ISettingsService settingsService,
        CreatSettingsScreen creatSettingsScreen) : base (dataService)
    {
        _settings = settings;
        _dataService = dataService;
        _animalsScreen = animalsScreen;
        _settingsService = settingsService;
        _creatSettingsScreen = creatSettingsScreen;
    }
    #endregion Properties And Ctor


    #region Public Methods

    /// <inheritdoc/>
    public override void Show()
    {
        while (true)
        {
            var list = new List<ScreenLineEntry>
            {
                new ScreenLineEntry { Text = "0. Exit" },
                new ScreenLineEntry { Text = "1. Animals" },
                new ScreenLineEntry { Text = "2. Create a new settings" },
            };

            Console.WriteLine();

            ScreenRender(list, _dataService.settings.MainScreenColor);

            SwitchHandler();
            
        }
    }

    public override void EnterScreen()
    {
        try
        {
            MainScreenChoices choice = (MainScreenChoices)currentField;
            switch (choice)
            {
                case MainScreenChoices.Animals:
                    _animalsScreen.Show();
                    break;

                case MainScreenChoices.Settings:
                    _creatSettingsScreen.Show();
                    break;

                case MainScreenChoices.Exit:
                    Console.WriteLine("Goodbye.");
                    return;
            }
        }
        catch
        {
            Console.WriteLine("Invalid choice. Try again.");
        }
    }

    #endregion // Public Methods
}

