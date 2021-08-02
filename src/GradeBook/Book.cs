using System;
using System.Collections.Generic;

namespace GradeBook
{
  public class Book
  {
    public List<double> grades
    {
      get
      {
        return new List<double>(grades);
      }
      private set { }
    }
    public string Name;
    public Book(string name)
    {
      grades = new List<double>();
      Name = name;
    }
    public void AddGrade(double grade)
    {
      if (grade <= 100 && grade >= 0)
      {
        grades.Add(grade);
      }
      else
      {
        Console.WriteLine("invalid value");
      }
    }

    public Statistics GetStatistics()
    {
      Statistics result = new Statistics();
      //wriing comment here for 
      result.Average = 0.0;
      result.High = double.MinValue;
      result.Low = double.MaxValue;

      foreach (double grade in grades)
      {
        result.Low = Math.Min(grade, result.Low);
        result.High = Math.Max(grade, result.High);
        result.Average += grade;
      }

      result.Average /= grades.Count;

      return result;
    }


  }
}
