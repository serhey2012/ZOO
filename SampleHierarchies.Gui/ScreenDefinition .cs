using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Gui
{
    public class ScreenDefinition
    {
        public string ScreenName { get; set; }
        public string ScreenType { get; set; }
        public List<ScreenLineEntry>? LineEntries { get; set; }     
    }
}
