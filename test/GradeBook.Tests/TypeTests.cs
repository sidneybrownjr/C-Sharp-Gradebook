using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void Test1()
        {
            //Given
            var x = GetInt();
            SetInt(ref x);
            //When
            
            //Then
            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt(){
            return 3;
        }



        [Fact]
        public void CSharpCanPassByRef()
        {
            //arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");
            //act

            //assert
            Assert.Equal("New Name", book1.Name);
            
        }

        private void GetBookSetName(ref Book book, string name) {
            book = new Book(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            //arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");
            //act

            //assert
            Assert.Equal("Book 1", book1.Name);
            
        }

        private void GetBookSetName(Book book, string name) {
            book = new Book(name);
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            //act

            //assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
            
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            //arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;

            //act

            //assert
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
            
        }

        Book GetBook(string name) {
            return new Book(name);
        }

        [Fact]
        public void IsGradeInRange()
        {
        //Given
        var book1 = GetBook("NewBook");
    
        //When
        book1.AddGrade(105);
        //Then

        
        }


    }
}
