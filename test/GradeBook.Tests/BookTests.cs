using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace GradeBook.Tests
{
  [TestClass]
  public class BookTests
  {
    [TestMethod]
    public void BookCalculatesAnAverageGrade()
    {
      //arrange
      var book = new Book("");
      book.AddGrade(89.1);
      book.AddGrade(90.5);
      book.AddGrade(77.3);
      //act
      Statistics result = book.GetStatistics();
      //assert
      Assert.AreEqual(85.6, result.Average, 1);
      Assert.AreEqual(90.5, result.High, 1);
      Assert.AreEqual(77.3, result.Low, 1);
    }

    [TestMethod]

    public void AddingGradeAbove100DoesntAddToBook()
    {
      Book book = new Book("");
      book.AddGrade(105);

      Assert.IsNotNull(book.grades);
      Assert.AreEqual(0, book.grades.Count);
      Assert.IsFalse(book.grades.Any(g => g == 105));
    }
  }
}
