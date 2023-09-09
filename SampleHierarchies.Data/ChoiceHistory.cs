using SampleHierarchies.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data
{
    public class ChoiceHistory : IChoiceHistory
    {
        public List<IUnitOfScreenHistori> UnitOfScreenHistoris { get; set; } = new List<IUnitOfScreenHistori>();
    }
}
