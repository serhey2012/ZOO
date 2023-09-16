using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Mammals main screen.
/// </summary>
public sealed class MammalsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Animals screen.
    /// </summary>
    private DogsScreen _dogsScreen;

    private OrangutanScreen _orangutanScreen;

    private ElephantScreen _elephantScreen;

    private IDataService _dataService;
    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="dogsScreen">Dogs screen</param>
    public MammalsScreen(DogsScreen dogsScreen, OrangutanScreen orangutanScreen, ElephantScreen elephantScreen, IDataService dataService) : base(dataService)
    {
        _dogsScreen = dogsScreen;
        _orangutanScreen = orangutanScreen;
        _elephantScreen = elephantScreen;
        _dataService = dataService;
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
                new ScreenLineEntry{ Text = "0. Exit"},
                new ScreenLineEntry{ Text = "1. Dogs"},
                new ScreenLineEntry{ Text = "2. Orangutan"},
                new ScreenLineEntry{ Text = "3. Elephant"},
            };

            ScreenDefinitionJson = _dataService.settings.MammalSpeciesColor;
            ScreenRender(list);

            SwitchHandler();
            return;


        }
    }


    public override void EnterScreen()
    {
        try
        {
            MammalsScreenChoices choice = (MammalsScreenChoices)currentField;
            switch (choice)
            {
                case MammalsScreenChoices.Dogs:
                    _dogsScreen.Show();
                    break;

                case MammalsScreenChoices.Orangutan:
                    _orangutanScreen.Show();
                    break;
                case MammalsScreenChoices.Elephant:
                    _elephantScreen.Show();
                    break;

                case MammalsScreenChoices.Exit:
                    Console.WriteLine("Going back to parent menu.");
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
