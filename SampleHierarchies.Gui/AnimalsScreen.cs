using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Animals main screen.
/// </summary>
public sealed class AnimalsScreen : Screen
{
    #region Properties And Ctor

    /// <summary>
    /// Data service.
    /// </summary>
    private IDataService _dataService;

    /// <summary>
    /// Animals screen.
    /// </summary>
    private MammalsScreen _mammalsScreen;


    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="dataService">Data service reference</param>
    /// <param name="animalsScreen">Animals screen</param>
    public AnimalsScreen(
        DogsScreen dogsScreen,
        IDataService dataService,
        MammalsScreen mammalsScreen) : base(dataService)
    {
        _dataService = dataService;
        _mammalsScreen = mammalsScreen;
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
                new ScreenLineEntry { Text = "1. Mammals" },
                new ScreenLineEntry { Text = "2. Save to file" },
                new ScreenLineEntry { Text = "3. Read from file" }
            };
            Console.WriteLine();

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
            AnimalsScreenChoices choice = (AnimalsScreenChoices)currentField;
            switch (choice)
            {
                case AnimalsScreenChoices.Mammals:
                    _mammalsScreen.Show();
                    break;

                case AnimalsScreenChoices.Read:
                    ReadFromFile();
                    break;

                case AnimalsScreenChoices.Save:
                    SaveToFile();
                    break;

                case AnimalsScreenChoices.Exit:
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

    #region Private Methods

    /// <summary>
    /// Save to file.
    /// </summary>
    private void SaveToFile()
    {
        try
        {
            Console.Write("Save data to file: ");
            var fileName = Console.ReadLine();
            if (fileName is null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }
            _dataService.Write(fileName);
            Console.WriteLine("Data saving to: '{0}' was successful.", fileName);
        }
        catch
        {
            Console.WriteLine("Data saving was not successful.");
        }
    }

    /// <summary>
    /// Read data from file.
    /// </summary>
    private void ReadFromFile()
    {
        try
        {
            Console.Write("Read data from file: ");
            var fileName = Console.ReadLine();
            if (fileName is null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }
            _dataService.Read(fileName);
            Console.WriteLine("Data reading from: '{0}' was successful.", fileName);
        }
        catch
        {
            Console.WriteLine("Data reading from was not successful.");
        }
    }

    #endregion // Private Methods
}
