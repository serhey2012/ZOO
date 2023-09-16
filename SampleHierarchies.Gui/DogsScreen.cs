using SampleHierarchies.Data.Mammals;
using SampleHierarchies.Enums;
using SampleHierarchies.Interfaces.Services;

namespace SampleHierarchies.Gui;

/// <summary>
/// Mammals main screen.
/// </summary>
public sealed class DogsScreen : Screen
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
    public DogsScreen(IDataService dataService) : base(dataService) 
    {
        _dataService = dataService;
    }

    #endregion Properties And Ctor

    #region Public Methods

    public override void EnterScreen()
    {
        try
        {

            DogsScreenChoices choice = (DogsScreenChoices)currentField;
            switch (choice)
            {
                case DogsScreenChoices.List:
                    ListDogs();
                    screenLines.Clear();
                    Show();
                    break;

                case DogsScreenChoices.Create:
                    AddDog();
                    screenLines.Clear();
                    Show();
                    break;

                case DogsScreenChoices.Delete:
                    DeleteDog();
                    screenLines.Clear();
                    Show();
                    break;

                case DogsScreenChoices.Modify:
                    EditDogMain();
                    screenLines.Clear();
                    Show();
                    break;

                case DogsScreenChoices.Exit:
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
                new ScreenLineEntry { Text = "1. List all dogs" },
                new ScreenLineEntry { Text = "2. Create a new dog" },
                new ScreenLineEntry { Text = "2. Delete existing dog" },
                new ScreenLineEntry { Text = "2. Modify existing dog" }
            };

            ScreenDefinitionJson = _dataService.settings.DogsScreenColor;
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
    private void ListDogs()
    {
        Console.WriteLine();
        if (_dataService?.Animals?.Mammals?.Dogs is not null &&
            _dataService.Animals.Mammals.Dogs.Count > 0)
        {
            Console.WriteLine("Here's a list of dogs:");
            int i = 1;
            foreach (Dog dog in _dataService.Animals.Mammals.Dogs)
            {
                Console.Write($"Dog number {i}, ");
                dog.Display();
                i++;
            }
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("The list of dogs is empty.");
            Console.ReadLine();
        }
    }

    /// <summary>
    /// Add a dog.
    /// </summary>
    private void AddDog()
    {
        try
        {
            Dog dog = AddEditDog();
            _dataService?.Animals?.Mammals?.Dogs?.Add(dog);
            Console.WriteLine("Dog with name: {0} has been added to a list of dogs", dog.Name);
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Deletes a dog.
    /// </summary>
    private void DeleteDog()
    {
        try
        {
            Console.Write("What is the name of the dog you want to delete? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Dog? dog = (Dog?)(_dataService?.Animals?.Mammals?.Dogs
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (dog is not null)
            {
                _dataService?.Animals?.Mammals?.Dogs?.Remove(dog);
                Console.WriteLine("Dog with name: {0} has been deleted from a list of dogs", dog.Name);
            }
            else
            {
                Console.WriteLine("Dog not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Edits an existing dog after choice made.
    /// </summary>
    private void EditDogMain()
    {
        try
        {
            Console.Write("What is the name of the dog you want to edit? ");
            string? name = Console.ReadLine();
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            Dog? dog = (Dog?)(_dataService?.Animals?.Mammals?.Dogs
                ?.FirstOrDefault(d => d is not null && string.Equals(d.Name, name)));
            if (dog is not null)
            {
                Dog dogEdited = AddEditDog();
                dog.Copy(dogEdited);
                Console.Write("Dog after edit:");
                dog.Display();
            }
            else
            {
                Console.WriteLine("Dog not found.");
            }
        }
        catch
        {
            Console.WriteLine("Invalid input. Try again.");
        }
    }

    /// <summary>
    /// Adds/edit specific dog.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    private Dog AddEditDog()
    {
        Console.Write("What name of the dog? ");
        string? name = Console.ReadLine();
        Console.Write("What is the dog's age? ");
        string? ageAsString = Console.ReadLine();
        Console.Write("What is the dog's breed? ");
        string? breed = Console.ReadLine();

        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        if (ageAsString is null)
        {
            throw new ArgumentNullException(nameof(ageAsString));
        }
        if (breed is null)
        {
            throw new ArgumentNullException(nameof(breed));
        }
        int age = Int32.Parse(ageAsString);
        Dog dog = new Dog(name, age, breed);

        return dog;
    }

    #endregion // Private Methods
}
