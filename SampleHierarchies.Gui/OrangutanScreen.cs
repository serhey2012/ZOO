using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Gui
{
    public class OrangutanScreen : Screen
    {


        private IDataService _dataService;

        //  private MammalsScreen _mammalsScreen;

        public OrangutanScreen(IDataService dataService) : base(dataService)
        {
            // _mammalsScreen = mammalsScreen;
            _dataService = dataService;
        }


        




        public override void Show()
        {
            while (true)
            {
                var list = new List<ScreenLineEntry>
                {
                    new ScreenLineEntry { Text = "0. Exit" },
                    new ScreenLineEntry { Text = "1. List all orungutans" },
                    new ScreenLineEntry { Text = "2. Create a new orungutan" },
                    new ScreenLineEntry { Text = "2. Delete existing orungutan" },
                    new ScreenLineEntry { Text = "2. Modify existing orungutan" }
                };

                ScreenDefinitionJson = _dataService.settings.OrungutanScreenColor;
                ScreenRender(list);

                SwitchHandler();

                return;
            }
        }

        public override void EnterScreen()
        {
            try
            {
                OrungutanScreenChoices choice = (OrungutanScreenChoices)currentField;
                switch (choice)
                {
                    case OrungutanScreenChoices.List:
                        ListOrungutans();
                        screenLines.Clear();
                        Console.ReadLine();
                        Show();
                        break;

                    case OrungutanScreenChoices.Create:
                        AddOrungutan();
                        screenLines.Clear();
                        Show();
                        break;

                    case OrungutanScreenChoices.Delete:
                        DeleteOrungutan();
                        screenLines.Clear();
                        Console.ReadLine();
                        Show();
                        break;

                    case OrungutanScreenChoices.Modify:
                        EditOrungutanMain();
                        screenLines.Clear();
                        Console.ReadLine();
                        Show();
                        break;

                    case OrungutanScreenChoices.Exit:
                        Console.WriteLine("Going back to parent menu.");
                        //_mammalsScreen.Show();
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }


        /// <summary>
        /// List all orungutans.
        /// </summary>
        private void ListOrungutans()
        {
            Console.WriteLine();
            if (_dataService?.Animals?.Mammals?.Orungutans is not null &&
                _dataService.Animals.Mammals.Orungutans.Count > 0)
            {
                Console.WriteLine("Here's a list of orungutans:");
                int i = 1;
                foreach (Orungutan orungutan in _dataService.Animals.Mammals.Orungutans)
                {
                    Console.Write($"Orungutan number {i}, ");
                    orungutan.Display();
                    i++;
                }
            }
            else
            {
                Console.WriteLine("The list of orungutans is empty.");
            }
        }

        /// <summary>
        /// Add a orungutan.
        /// </summary>
        private void AddOrungutan()
        {
            try
            {
                Orungutan orungutan = AddEditOrungutan();
                _dataService?.Animals?.Mammals?.Orungutans?.Add(orungutan);
                Console.WriteLine("Orungutan with name: {0} has been added to a list of orungutans", orungutan.Name);
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Deletes a orungutan.
        /// </summary>
        private void DeleteOrungutan()
        {
            try
            {
                Console.Write("What is the name of the orungutan you want to delete? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Orungutan? orungutan = (Orungutan?)(_dataService?.Animals?.Mammals?.Orungutans
                    ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (orungutan is not null)
                {
                    _dataService?.Animals?.Mammals?.Orungutans?.Remove(orungutan);
                    Console.WriteLine("Orungutan with name: {0} has been deleted from a list of orungutans", orungutan.Name);
                }
                else
                {
                    Console.WriteLine("Orungutan not found.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }

        /// <summary>
        /// Edits an existing orungutan after choice made.
        /// </summary>
        private void EditOrungutanMain()
        {
            try
            {
                Console.Write("What is the name of the orungutan you want to edit? ");
                string? name = Console.ReadLine();
                if (name is null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                Orungutan? orungutan = (Orungutan?)(_dataService?.Animals?.Mammals?.Orungutans
                    ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
                if (orungutan is not null)
                {
                    Orungutan orungutanEdited = AddEditOrungutan();
                    orungutan.Copy(orungutanEdited);
                    Console.Write("Orungutan after edit:");
                    orungutan.Display();
                }
                else
                {
                    Console.WriteLine("Orungutan not found.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }

        /// <summary>
        /// Adds/edit specific orungutan.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private Orungutan AddEditOrungutan()
        {
            Console.Write("What name of the Orungutan? ");
            string? name = Console.ReadLine();
            Console.Write("What is the Orungutan's age? ");
            string? ageAsString = Console.ReadLine();

            Console.Write("What is the orungutan's arboreal lifstyle? Answer yes or no : ");
            bool arborealLifstyle = false;
            string? AnswerForArborealLifstyle = Console.ReadLine().ToLower();
            if (AnswerForArborealLifstyle == "yes" || AnswerForArborealLifstyle == "y")
            {
                arborealLifstyle = true;
            }

            Console.Write("What is the orungutan's opposable thumbs? Answer yes or no : ");
            bool opposableThumbs = false;
            string? AnswerOpposableThumbs = Console.ReadLine().ToLower();
            if (AnswerOpposableThumbs == "yes" || AnswerOpposableThumbs == "y")
            {
                opposableThumbs = true;
            }

            Console.Write("What is the orungutan's high intelligence? ");
            string? highIntelligenceAsString = Console.ReadLine();

            Console.Write("What is the orungutan's solitary behavior? Answer yes or no : ");
            bool solitaryBehavior = false;
            string? AnswersolitaryBehavior = Console.ReadLine();
            if (AnswersolitaryBehavior == "yes" || AnswersolitaryBehavior == "y")
            {
                solitaryBehavior = true;
            }

            Console.Write("What is the orungutan's slow reproductive rate? Answer yes or no : ");
            bool slowReproductiveRate = false;
            string? AnswerslowReproductiveRate = Console.ReadLine();
            if (AnswerslowReproductiveRate == "yes" || AnswerslowReproductiveRate == "y")
            {
                slowReproductiveRate = true;
            }

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ageAsString is null)
            {
                throw new ArgumentNullException(nameof(ageAsString));
            }
            if (highIntelligenceAsString is null)
            {
                throw new ArgumentNullException(nameof(highIntelligenceAsString));
            }
            //if (arborealLifstyle is null)
            //{
            //    throw new ArgumentNullException(nameof(arborealLifstyle));
            //}
            //if (opposableThumbs is null)
            //{
            //    throw new ArgumentNullException(nameof(opposableThumbs));
            //}
            //if (solitaryBehavior is null)
            //{
            //    throw new ArgumentNullException(nameof(solitaryBehavior));
            //}
            //if (slowReproductiveRate is null)
            //{
            //    throw new ArgumentNullException(nameof(slowReproductiveRate));
            //}



            int highIntelligence = Int32.Parse(highIntelligenceAsString);
            int age = Int32.Parse(ageAsString);
            Orungutan orungutan = new Orungutan(name, age, arborealLifstyle, opposableThumbs, highIntelligence, solitaryBehavior, slowReproductiveRate);

            return orungutan;
        }
        //   Orungutan orungutan = new Orungutan(name, age, arborealLifstyle, opposableThumbs, highIntelligence, solitaryBehavior, slowReproductiveRate);
        //#endregion // Private Methods

    }
}
