using SampleHierarchies.Interfaces.Data;

namespace SampleHierarchies.Interfaces.Services;

/// <summary>
/// Data service interface.
/// </summary>
public interface IDataService
{
    #region Interface Members

    /// <summary>
    /// Animals collection.
    /// </summary>
    IAnimals? Animals { get; set; }

    ISettings settings { get; set; }

    IChoiceHistory choiceHistory { get; set; }

    /// <summary>
    /// Reads animals from a json path.
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <returns>True if success, false otherwise</returns>
    bool Read(string jsonPath);

    /// <summary>
    /// Writes animals to a json path.
    /// </summary>
    /// <param name="jsonPath"></param>
    /// <returns>True if success, false otherwise</returns>
    bool Write(string jsonPath);

    //ISettings Settings { get; set; }


    #endregion // Interface Members
}
