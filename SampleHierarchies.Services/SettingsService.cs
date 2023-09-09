using Newtonsoft.Json;
using SampleHierarchies.Data;
using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Services;
using System.Diagnostics;

namespace SampleHierarchies.Services;

/// <summary>
/// Settings service.
/// </summary>
public class SettingsService : ISettingsService
{
    #region ISettings Implementation

    public IDataService _dataService;

    // public ISettings Settings { get; set;  }


    public SettingsService(IDataService dataService)
    {
        _dataService = dataService;
    }




    /// <inheritdoc/>
    public ISettings? Read(string jsonPath)
    {
        //ISettings? Settings;

        try
        {
            string jsonContent = File.ReadAllText(jsonPath);
            var jsonSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects
            };
            Settings settings = JsonConvert.DeserializeObject<Settings>(jsonContent, jsonSettings);

           _dataService.settings = settings;

            //Console.WriteLine(_dataService.settings.OrungutanScreenColor);


            return settings;


        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }

        return new Settings();
    }



    /// <inheritdoc/>
    public void Write(ISettings settings, string jsonPath)
    {
        try
        {
            var jsonSettings = new JsonSerializerSettings();
            string jsonContent = JsonConvert.SerializeObject(settings);
            string jsonContentFormatted = jsonContent.FormatJson();
            File.WriteAllText(jsonPath, jsonContentFormatted);

            Read(jsonPath);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }

    #endregion // ISettings Implementation

    //public SettingsService()
    //{
    //    Settings = new Settings();
    //}



    public void SetttingColor()
    {

    }


}