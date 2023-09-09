using SampleHierarchies.Data;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Gui
{
    public class CreatSettingsScreen : Screen
    {

        // public MainScreen _mainScreen;

        public ISettingsService _settingsService;

        public IDataService _dataService;

        public CreatSettingsScreen(ISettingsService settingsService,IDataService dataService) : base(dataService)
        {
            _settingsService = settingsService;
            // _mainScreen = mainScreen;
        }


        public override void EnterScreen()
        {
            try
            {
                CreatSettingsChoises choice = (CreatSettingsChoises)currentField;
                switch (choice)
                {

                    case CreatSettingsChoises.Read:
                        ReadFromFile();
                        break;

                    case CreatSettingsChoises.Save:
                        SaveToFile();
                        break;

                    case CreatSettingsChoises.Exit:
                        Console.WriteLine("Going back to parent menu.");
                        //_mainScreen.Show();
                        return;

                }
            }
            catch
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }


        public override void Show()
        {
            while (true)
            {

                var list = new List<ScreenLineEntry>
                {
                    new ScreenLineEntry { Text = "0. Exit" },
                    new ScreenLineEntry { Text = "1. Read" },
                    new ScreenLineEntry { Text = "2. Save" },
                };

                ScreenRender(list, "White");

                SwitchHandler();
                return;
            }
        }


        public void ReadFromFile()
        {
            Console.Write("Read data from file: ");
            var filePath = Console.ReadLine();
            if (filePath is null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }
            var set = _settingsService.Read(filePath);

            // Console.WriteLine(set.MainScreenColor);
        }


        public void SaveToFile()
        {
            var settings = AddEditSettingsn();

            Console.Write("Save data to file: ");
            string filePath = Console.ReadLine();

            if (filePath is null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            _settingsService.Write(settings, filePath);

        }


        public Settings AddEditSettingsn()
        {

            Console.WriteLine();

            Console.WriteLine("Color of main screen:");
            string MainScreenColor = ChoisColor();

            Console.WriteLine("Color of animals screen:");
            string AnimalsScreenColor = ChoisColor();

            Console.WriteLine("Color of mammal species:");
            string MammalSpecies = ChoisColor();

            Console.WriteLine("Color of dogs screen:");
            string DogsScreenColor = ChoisColor();

            Console.WriteLine("Color of orungutans screen:");
            string OrungutanScreenColor = ChoisColor();


            Settings settings = new Settings(MainScreenColor, AnimalsScreenColor, MammalSpecies, DogsScreenColor, OrungutanScreenColor);

            return settings;

        }



        public string ChoisColor()
        {

            Console.WriteLine("Your available choices are:");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Red");
            Console.WriteLine("2. Blue");
            Console.WriteLine("3. Cyan");
            Console.WriteLine("4. Yellow");

            string? choiceAsString = Console.ReadLine();

            ColorScreenChoises choice = (ColorScreenChoises)Int32.Parse(choiceAsString);
            switch (choice)
            {
                case ColorScreenChoises.Red:
                    return "Red";

                case ColorScreenChoises.Blue:
                    return "Blue";

                case ColorScreenChoises.Cyan:
                    return "Cyan";

                case ColorScreenChoises.Yellow:
                    return "Yellow";

                case ColorScreenChoises.Exit:
                    Console.WriteLine("Going back to parent menu.");
                    return "White";
            }
            return "White";

        }

    }
}
