using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Gui
{
    public static class ScreenDefinitionService 
    {

        public static ScreenDefinition Load(string jsonFileName)
        {

            string json = File.ReadAllText(jsonFileName);
            ScreenDefinition screenDefinition = JsonConvert.DeserializeObject<ScreenDefinition>(json);
            return screenDefinition;
        }


        public static bool Save(ScreenDefinition screenDefinition, string jsonFileName)
        {
            return true;
        }


    }
}
