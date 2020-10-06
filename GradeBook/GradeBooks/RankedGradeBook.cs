using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook :BaseGradeBook
    {
        public RankedGradeBook(string name, bool IsWeight) : base(name, IsWeight)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("Not enough students, at least 5 required");
            }
            var twPercent = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(student => student.AverageGrade).Select(student =>student.AverageGrade ).ToList();
            if (grades[twPercent-1] <= averageGrade)
                return 'A';
            if (grades[(twPercent * 2) -1] <=averageGrade)
                // zniżamy do B ( index * 2) i -1 bo index zaczyna od 0
                return 'B';
            if (grades[(twPercent * 3) -1] <=averageGrade)
                //analogicznie zniżamy do C ( index tabicy * 3) i -1 bo index zaczyna od 0
                return 'C';
            if(grades[(twPercent * 4) -1] <=averageGrade)
                return 'D';
            return 'F';

        }

        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5 )
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");   
            }
            else
            {
                base.CalculateStudentStatistics(name); 
            }
        }

        
    }
}