using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Interfaces.Data.Mammals
{
    public interface IElephant : IMammal
    {
        #region Interface Members
        float Height { get; set; }
        float Weight { get; set; }
        float TuskLenght { get; set; }
        int LongLifespan { get; set; }
        string SocialBehavior { get; set; }
        /// <summary>
        /// </summary>
        
        #endregion // Interface Members
    }
}
