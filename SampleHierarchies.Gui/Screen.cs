using SampleHierarchies.Data;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Abstract base class for a screen.
/// </summary>
public abstract class Screen 
{
    #region Public Methods

    /// <summary>
    /// 
    /// </summary>
    public int currentField = 0;

    /// <summary>
    /// 
    /// </summary>
    private IDataService _dataService;

    /// <summary>
    /// 
    /// </summary>
    public List<ScreenLineEntry> screenLines { get; set; } = new List<ScreenLineEntry>();

    /// <summary>
    /// 
    /// </summary>
    public string ScreenColor { get; set; }

    public string ScreenDefinitionJson { get; set; }

    #region ctor
    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="dataService"></param>
    public Screen(IDataService dataService)
    {
        _dataService = dataService;
    }
    #endregion


    #region Hisory
    public virtual void HistoryHandler()
    {
        if (currentField != 0)

         _dataService.choiceHistory.UnitOfScreenHistoris.Add(new UnitOfScreenHistori { ScreenNmae = $" -> {screenLines[currentField].Text}" });
    }
   

    public void HistoriRender()
    {
        if (_dataService.choiceHistory.UnitOfScreenHistoris != null)
        {
            foreach (var unit in _dataService.choiceHistory.UnitOfScreenHistoris)
            {
                Console.Write(unit.ScreenNmae);
            }
        }
    }
    #endregion


    #region ScreenRender

    public void ScreenRender(List<ScreenLineEntry> Lines )
    {

        if (screenLines.Count == 0)
        {
            screenLines.AddRange(Lines);
        }

        Console.Clear();

        Console.WriteLine();
 
        // -> ... -> ... ->
        HistoriRender();

        Console.WriteLine();
        Console.WriteLine();

        ScreenLinesRender(Lines);
    }
    #endregion


    #region ScreenColorHendlerRender

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ListOfLines"></param>
    public void ScreenLinesRender(List<ScreenLineEntry> ListOfLines)
    {
        ScreenColoreDefinition();

        CursorHandler(ListOfLines, "Red");

        Console.WriteLine("Your available choices are:");
        Console.WriteLine();

        foreach (var screenline in ListOfLines)
        {
            if (Enum.TryParse(screenline.ForegroundColor, out ConsoleColor color))
            {
                Console.ForegroundColor = color;
            }
            Console.WriteLine(screenline.Text);

            Console.ResetColor();
        }

        ScreenColoreDefinition();

        Console.WriteLine();
        Console.WriteLine("Your available choices are:");
    
    }

    public string ScreenColoreDefinition()
    {
        if (Enum.TryParse(ScreenDefinitionJson, out ConsoleColor color))
        {
            Console.ForegroundColor = color;
            return ScreenDefinitionJson;
        }
        return null;
    }

    public virtual void CursorHandler(List<ScreenLineEntry> ListOfLines, string ColorOfCursor)
    {
        for (int i = 0; i < ListOfLines.Count; i++)
        {
            if (i != currentField)
            {
                ListOfLines[i].ForegroundColor = ScreenColoreDefinition();
            }
        }
        ListOfLines[currentField].ForegroundColor = ColorOfCursor;
    }
    #endregion


    /// <summary>
    /// Show the screen.
    /// </summary>
    public virtual void Show()
    {
        Console.WriteLine("Showing screen");
    }


    #region Navigation

    public void SwitchHandler()
    {

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                    MoveDown();
                    break;
                case ConsoleKey.Enter:

                    HistoryHandler();

                    EnterScreen();

                    screenLines.Clear();
                    return;
            }
        }
    }


    public virtual void MoveUp()
    {
        if (currentField > 0)
        {
            currentField--;

            ScreenRender(screenLines);

            Console.WriteLine($"You have moved to the screen: {currentField}. --- {screenLines[currentField].Text}");
        }
    }

    public virtual void MoveDown()
    {
        if (currentField < screenLines.Count - 1)
        {
            currentField++;

            ScreenRender(screenLines);

            Console.WriteLine($"You have moved to the screen: {currentField}. --- {screenLines[currentField].Text}");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract void EnterScreen();


    #endregion

    #endregion // Public Methods
}
