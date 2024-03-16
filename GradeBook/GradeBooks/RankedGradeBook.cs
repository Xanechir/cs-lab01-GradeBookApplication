using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks {
    public class RankedGradeBook : BaseGradeBook {
        public RankedGradeBook(string name) : base(name) {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade) {
            if (Students.Count < 5)
                throw new InvalidOperationException("Less than 5 students in the GradeBook");

            int totalGradeCount = 0;
            int higherGradeCount = 0;

            foreach (var student in Students) {
                foreach (var grade in student.Grades) {
                    totalGradeCount++;

                    if (grade > averageGrade) {
                        higherGradeCount++; 
                    } 
                } 
            } 

            float percentageOfHigher = (float)higherGradeCount / (float)totalGradeCount;

            if (percentageOfHigher < 0.2f) {
                return 'A';
            }
            else if (percentageOfHigher < 0.4f) {
                return 'B';
            }
            else if (percentageOfHigher < 0.6f) {
                return 'C';
            }
            else if (percentageOfHigher < 0.8f) {
                return 'D';
            }
            else {
                return 'F';
            }
        }

        public override void CalculateStatistics() {
            if (Students.Count < 5) {
                Console.Write("Ranked grading requires at least five students.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name) {
            if (Students.Count < 5) {
                Console.Write("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
