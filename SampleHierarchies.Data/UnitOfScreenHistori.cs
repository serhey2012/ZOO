using SampleHierarchies.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data
{
    public class UnitOfScreenHistori : IUnitOfScreenHistori
    {
        public string? ScreenNmae { get; set; }
        public string? ScreenHist { get; set; }
    }
}
