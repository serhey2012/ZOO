using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Data.Mammals;
using SampleHierarchies.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Gui
{
    public sealed class ElephantScreen : Screen
    {
        #region Properties And Ctor

        /// <summary>
        /// Data service.
        /// </summary>
        private IDataService _dataService;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="dataService">Data service reference</param>
        public ElephantScreen(IDataService dataService) : base(dataService)
        {
            _dataService = dataService;
        }

        #endregion Properties And Ctor

        #region Public Methods

        public override void EnterScreen()
        {
            try
            {

                ElephantScreenChoices choice = (ElephantScreenChoices)currentField;
                switch (choice)
                {
                    case ElephantScreenChoices.List:
                        ListElephant();
                        screenLines.Clear();
                        Show();
                        break;

                    case ElephantScreenChoices.Create:
                        AddElephant();
                        screenLines.Clear();
                        Show();
                        break;

                    case ElephantScreenChoices.Delete:
                        DeleteElephant();
                        screenLines.Clear();
                        Show();
                        break;

                    case ElephantScreenChoices.Modify:
                        EditElephantMain();
                        screenLines.Clear();
                        Show();
                        break;

                    case ElephantScreenChoices.Exit:
                        Console.WriteLine("Going back to parent menu.");
                        return;
                }
            }
            catch
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }

        /// <inheritdoc/>
        public override void Show()
        {
            while (true)
            {

                var list = new List<ScreenLineEntry>
            {
                new ScreenLineEntry { Text = "0. Exit" },
                new ScreenLineEntry { Text = "1. List all elephant" },
                new ScreenLineEntry { Text = "2. Create a new elephant" },
                new ScreenLineEntry { Text = "2. Delete existing elephant" },
                new ScreenLineEntry { Text = "2. Modify existing elephant" }
            };

                ScreenDefinitionJson = _dataService.settings.ElephantScreenColor;
                ScreenRender(list);

                SwitchHandler();

                return;
            }
        }

        #endregion // Public Methods

        #region Private Methods

        /// <summary>
        /// List all dogs.
        /// </summary>
        private void ListElephant()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Elephants is not null &&
                _dataService.Animals.Mammals.Elephants.Count > 0)
            {
                Console.WriteLine("Here's a list of elephants:");
                int i = 1;
                foreach (Elephant elephant in _dataService.Animals.Mammals.Elephants)
                {
                    Console.Write($"Elephant number {i}, ");
                    elephant.Display();
                    i++;
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("The list of elephant is empty.");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Add a elephant.
        /// </summary>
        private void AddElephant()
        {
            try
            {
                Elephant elephant = AddEditElephant();
                _dataService?.Animals?.Mammals?.Elephants?.Add(elephant);
                Console.WriteLine("Dog with name: {0} has been added to a list of elephant", elephant.Name);
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Deletes a Elephant.
        /// </summary>
        private void DeleteElephant()
        {
            try
            {
                Console.Write("What is the name of the elephant you want to delete? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Elephant? elephant = (Elephant?)(_dataService?.Animals?.Mammals?.Elephants
                    ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (elephant is not null)
                {
                    _dataService?.Animals?.Mammals?.Elephants?.Remove(elephant);
                    Console.WriteLine("Elephant with name: {0} has been deleted from a list of elephants", elephant.Name);
                }
                else
                {
                    Console.WriteLine("Elephant not found.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Edits an existing Elephant after choice made.
        /// </summary>
        private void EditElephantMain()
        {
            try
            {
                Console.Write("What is the name of the elephant you want to edit? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Elephant? elephant = (Elephant?)(_dataService?.Animals?.Mammals?.Elephants
                    ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (elephant is not null)
                {
                    Elephant elephantEdited = AddEditElephant();
                    elephant.Copy(elephantEdited);
                    Console.Write("Elephant after edit:");
                    elephant.Display();
                }
                else
                {
                    Console.WriteLine("Elephant not found.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }

        /// <summary>
        /// Adds/edit specific Elephant.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Elephant AddEditElephant()
        {
            Console.Write("What name of the elephant? ");
            string? name = Console.ReadLine();
            Console.Write("What is the Elephant's age? ");
            string? ageAsString = Console.ReadLine();
            Console.Write("What height of the elephant? ");
            string? heightAsString = Console.ReadLine();
            Console.Write("What weight of the elephant? ");
            string? weightAsString = Console.ReadLine();
            Console.Write("What tusk lenght of the elephant? ");
            string? tusklenghtAsString = Console.ReadLine();
            Console.Write("What long lifespan of the elephant? ");
            string? longlifespanAsString = Console.ReadLine();
            Console.Write("What social behavior of the elephant? ");
            string? socialbehavior = Console.ReadLine();

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ageAsString is null)
            {
                throw new ArgumentNullException(nameof(ageAsString));
            }
            if (heightAsString is null)
            {
                throw new ArgumentNullException(nameof(heightAsString));
            }
            if (weightAsString is null)
            {
                throw new ArgumentNullException(nameof(weightAsString));
            }
            if (tusklenghtAsString is null)
            {
                throw new ArgumentNullException(nameof(tusklenghtAsString));
            }
            if (longlifespanAsString is null)
            {
                throw new ArgumentNullException(nameof(longlifespanAsString));
            }
            if (socialbehavior is null)
            {
                throw new ArgumentNullException(nameof(socialbehavior));
            }

            int age = Int32.Parse(ageAsString);
            float height = float.Parse(heightAsString);
            float weight = float.Parse(weightAsString);
            float tusklenght = float.Parse(tusklenghtAsString);
            int longlifespan = Int32.Parse(longlifespanAsString);
            Elephant elephant = new Elephant(name, age, height, weight, tusklenght, longlifespan, socialbehavior);

            return elephant;
        }

        #endregion // Private Methods
    }
}
