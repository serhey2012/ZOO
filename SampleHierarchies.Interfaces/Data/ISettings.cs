namespace SampleHierarchies.Interfaces.Data;

/// <summary>
/// Settings interface.
/// </summary>
public interface ISettings
{
    #region Interface Members

    /// <summary>
    /// Version of settings.
    /// </summary>
    string Version { get; set; }

    /// <summary>
    /// the color of the main screen
    /// </summary>
    string MainScreenColor { get; set; }

    /// <summary>
    /// the color of the Animals Screen 
    /// </summary>
    string AnimalsScreenColor { get; set; }

    /// <summary>
    /// the color of the Mammal Species
    /// </summary>
    string MammalSpeciesColor { get; set; }

    /// <summary>
    /// the color of the Dogs Screen
    /// </summary>
    string DogsScreenColor { get; set; }

    /// <summary>
    /// the color of the Orungutan Screen
    /// </summary>
    string OrungutanScreenColor { get; set; }

    /// <summary>
    /// the color of the Elephant Screen
    /// </summary>
    string ElephantScreenColor { get; set; }

    #endregion // Interface Members
}

