﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Interfaces.Data
{
    public interface IChoiceHistory
    {
        List<IUnitOfScreenHistori> UnitOfScreenHistoris { get; set; }
    }
}
