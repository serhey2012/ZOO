using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Interfaces.Data.Mammals
{
    public interface IOrungutan : IMammal
    {
        /// <summary>
        /// lifestyle 
        /// </summary>
        bool ArborealLifstyle { get; set; }
        
        /// <summary>
        /// Opposable thumbs
        /// </summary>
        bool OpposableThumbs {get; set;}

        /// <summary>
        /// High intelligence 
        /// </summary>
        int HighIntelligence { get; set; }

        /// <summary>
        /// Solitary behavior 
        /// </summary>
        bool SolitaryBehavior { get; set; }

        /// <summary>
        /// Slow reproductive rate 
        /// </summary>
        bool SlowReproductiveRate { get; set; }


    }
}
