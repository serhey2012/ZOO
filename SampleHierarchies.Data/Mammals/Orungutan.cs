using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data.Mammals
{
    public class Orungutan : MammalBase, IOrungutan
    {

        public override void MakeSound()
        {
            Console.WriteLine("My name is: {0} and I am barking", Name);
        }

        /// <inheritdoc/>
        public override void Move()
        {
            Console.WriteLine("My name is: {0} and I am running", Name);
        }

        /// <inheritdoc/>
        public override void Display()
        {
            Console.WriteLine($"My name is: {Name}, my age is: {Age} and I am a orungutan");
        }



        public override void Copy(IAnimal animal)
        {
            if (animal is IOrungutan ad)
            {
                base.Copy(animal);
                ArborealLifstyle = ad.ArborealLifstyle;
                OpposableThumbs = ad.OpposableThumbs;
                HighIntelligence = ad.HighIntelligence;
                SolitaryBehavior = ad.SolitaryBehavior;
                SlowReproductiveRate = ad.SlowReproductiveRate;
            }
        }



        public bool ArborealLifstyle { get; set; }
        public bool OpposableThumbs { get; set; }
        public int HighIntelligence { get; set; }
        public bool SolitaryBehavior { get; set; }
        public bool SlowReproductiveRate { get; set; }




        public Orungutan(string name, int age,
            bool arborealLifstyle,
            bool opposableThumbs,
            int highIntelligence,
            bool solitaryBehavior, 
            bool slowReproductiveRate) : base(name, age, MammalSpecies.Orungutan)
        {
            ArborealLifstyle = arborealLifstyle;
            OpposableThumbs  = opposableThumbs;
            HighIntelligence = highIntelligence;
            SolitaryBehavior = solitaryBehavior;
            SlowReproductiveRate = slowReproductiveRate;
        }
    }
}
