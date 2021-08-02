using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace GradeBook.Tests
{
  [TestClass]
  public class TypeTests
  {

    [TestMethod]
    public void StringsBehaveLikeValueTypes()
    {
      string name = "Carson";
      string upper = MakeUpperCase(name);

      Assert.AreEqual("Carson", name);
      Assert.AreEqual("CARSON", upper);
    }

    private string MakeUpperCase(string parameter)
    {
      return parameter.ToUpper();
    }

    [TestMethod]
    public void ValueTypesAlsoPassByValue()
    {
      int x = GetInt();
      SetInt(ref x);

      Assert.AreEqual(42, x);
    }

    private void SetInt(ref int x)
    {
      x = 42;
    }

    private int GetInt()
    {
      return 3;
    }

    [TestMethod]
    public void CSharpCanPassByRef()
    {
      Book book1 = GetBook("Book 1");
      GetBookSetName(ref book1, "New Name");

      Assert.AreEqual("New Name", book1.Name);
    }

    private void GetBookSetName(ref Book book, string name)
    {
      book = new Book(name);
    }



    [TestMethod]
    public void CSharpIsPassByValue()
    {
      Book book1 = GetBook("Book 1");
      GetBookSetName(book1, "New Name");

      Assert.AreEqual("Book 1", book1.Name);
    }

    private void GetBookSetName(Book book, string name)
    {
      book = new Book(name); //this line of code is creating a new object
      //so it is not the same object as what is on line 14 above
    }

    [TestMethod]
    public void CanSetNameFromReference()
    {
      Book book1 = GetBook("Book 1");
      SetName(book1, "New Name");

      Assert.AreEqual("New Name", book1.Name);
    }

    private void SetName(Book book, string name)
    {
      book.Name = name;
    }

    [TestMethod]
    public void GetBookReturnsDifferentObjects()
    {
      Book book1 = GetBook("Book 1");
      Book book2 = GetBook("Book 2");

      Assert.AreEqual("Book 1", book1.Name);
      Assert.AreEqual("Book 2", book2.Name);
    }

    [TestMethod]
    public void TwoVarsCanReferenceSameObject()
    {
      Book book1 = GetBook("Book 1");
      Book book2 = book1;

      Assert.AreSame(book1, book2);
      Assert.IsTrue(object.ReferenceEquals(book1, book2));
    }
    Book GetBook(string name)
    {
      return new Book(name);
    }
  }
}
