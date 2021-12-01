using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            var cohortCount = Math.Floor(Students.Count * .2);
            var orderedGradeList = Students.OrderBy(x => x.AverageGrade);
            var higherGradeCount = orderedGradeList.Where(x => x.AverageGrade > averageGrade).Count();
            var gradeLevelsToSubtract = Math.Floor(higherGradeCount / cohortCount);

            switch (gradeLevelsToSubtract)
            {
                case 0:
                    return 'A';
                case 1:
                    return 'B';
                case 2:
                    return 'C';
                case 3:
                    return 'D';
            }
            return 'F';
        }
    }
}
