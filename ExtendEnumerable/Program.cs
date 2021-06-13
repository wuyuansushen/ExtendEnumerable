using System;
using System.Linq;
using System.Collections.Generic;

namespace ExtendEnumerable
{
    public class student
    {
        public string? Name { get; set; }
        public double Scores { get; set; }

        public static double operator +(student a, student b) => a.Scores + b.Scores;
    }

    public static class LinqExtension
    {
        public static double Median<T>(this IEnumerable<T>? source) where T:student
        {
            if (!(source?.Any() ?? false))
            {
                throw new InvalidOperationException("Null or empty set.");
            }

            //Immediate Execution
            var ordered = (from item in source
                           orderby item.Scores
                           select item).ToList();
            int itemIndex = ordered.Count / 2;

            if((ordered.Count)%2!=0)
            {
                return ordered[itemIndex].Scores;
            }
            else
            {
                return (ordered[itemIndex] + ordered[itemIndex - 1]) / 2;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<student>
            {
                new student{Name="Wang",Scores=88.5},
                new student{Name="Li",Scores=21.2},
                new student{Name="John",Scores=234},
                new student{Name="Jack",Scores=43.6},
                new student{Name="Tom",Scores=65.2},
                new student{Name="Marry",Scores=72.1}
            };

            var median= students.Median();
            Console.WriteLine(median);
        }
    }
}
