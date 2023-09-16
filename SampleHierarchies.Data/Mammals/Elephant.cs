using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data.Mammals
{
    public class Elephant : MammalBase, IElephant
    {
        public float Height { get; set; }
        public float Weight { get; set; }
        public float TuskLenght { get; set; }
        public int LongLifespan { get; set; }
        public string SocialBehavior { get; set; }

        public override void Copy(IAnimal animal)
        {
            if (animal is IElephant ad)
            {
                base.Copy(animal);
            }
            
        }
        public Elephant(string name, int age, float height, float weight, float tusklenght, int longlifespan, string socialbehavior) : base(name, age, MammalSpecies.Elephant) 
        {
            Height = height;
            Weight = weight;
            TuskLenght = tusklenght;
            LongLifespan = longlifespan;    
            SocialBehavior = socialbehavior;
        }
        public override void MakeSound()
        {
            Console.WriteLine("My name is: {0} and I am noise", Name);
        }

        /// <inheritdoc/>
        public override void Move()
        {
            Console.WriteLine("My name is: {0} and I am running", Name);
        }

        /// <inheritdoc/>
        public override void Display()
        {
            Console.WriteLine($"My name is: {Name}, my age is: {Age} and I am a elephant");
        }
    }
    
}
