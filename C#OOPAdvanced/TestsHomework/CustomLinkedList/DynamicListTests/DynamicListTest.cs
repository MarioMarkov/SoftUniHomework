using CustomLinkedList;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ConstructorSetCountToZero()
        {
            //Arrange 
            DynamicList<int> customList = new DynamicList<int>();

            //Act
            int expectedCount = 0;
            int actualCount = customList.Count;
            //Assert
            Assert.AreEqual(expectedCount, actualCount,"Constructor doesn't set count to 0");
        }
        [Test]
        public void IndexOperatorReturnsValue()
        {
            //Arrange 
            DynamicList<int> customList = new DynamicList<int>() ;

            //Act
            customList.Add(420);
            customList.Add(69);
            int expectedResult = 69;
            int actualResult = customList[1];
            //Assert
            Assert.AreEqual(expectedResult, actualResult,"Index operator doesn't return right value");
        }
        [Test]
        public void IndexOperatorSetsValue()
        {
            //Arrange 
            DynamicList<int> customList = new DynamicList<int>();

            //Act
            customList.Add(420);
            customList[0] = 69;

            int expectedResult = 69;
            int actualResult = customList[0];

            //Assert
            Assert.AreEqual(expectedResult, actualResult, "Index operator doesn't set right value");
            
        }
        [Test]
        public void RemoveAtRemovesValueAtIndex()
        {
            //Arrange 
            DynamicList<int> customList = new DynamicList<int>();

            //Act
            customList.Add(420);
            customList.RemoveAt(0);

            int expectedCount = 0;
            int actualCount = customList.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount, "RemoveAt method doesn't remove right value");

        }
        [Test]
        public void RemoveAtReturnesAndRemovesValueAtIndex()
        {
            //Arrange 
            DynamicList<int> customList = new DynamicList<int>();

            //Act
            customList.Add(420);
            int removedValue = customList.RemoveAt(0);

            int expectedResult = 420;
            int actualResult = removedValue;

            //Assert
            Assert.AreEqual(expectedResult, actualResult, "RemoveAt method doesn't return right value");

        }
        [Test]
        public void RemoveAtThrowsExceptionWhenIndexIsInvalid()
        {
            //Arrange 
            DynamicList<int> customList = new DynamicList<int>();

            //Act
            customList.Add(420);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>customList.RemoveAt(5), "RemoveAt method doesn't throw exception when index is invalid");

        }
        [Test]
        public void RemoveRemovesAnElement()
        {
            //Arrange 
            DynamicList<int> customList = new DynamicList<int>();

            //Act
            customList.Add(420);
            customList.Add(52);
            customList.Remove(420);
            int expectedResult = 1;
            int actualResult = customList.Count;
            //Assert
            Assert.AreEqual(expectedResult, actualResult,"Remove does not remove an element");

        }
        [Test]
        public void RemoveReturnsRemovedElementsIndex()
        {
            //Arrange 
            DynamicList<int> customList = new DynamicList<int>();

            //Act
            customList.Add(420);
            customList.Add(52);
            
            int expectedResult = 1;
            int actualResult = customList.Remove(52); 
            //Assert
            Assert.AreEqual(expectedResult, actualResult, "Remove does not return an element's index");

        }
        [Test]
        public void RemoveReturnsMinus1WhenElementIsNotInTheList()
        {
            //Arrange 
            DynamicList<int> customList = new DynamicList<int>();

            //Act
            customList.Add(420);
            customList.Add(52);

            int expectedResult = -1;
            int actualResult = customList.Remove(33);
            //Assert
            Assert.AreEqual(expectedResult, actualResult, "Remove does not return -1 when element does not exist in the list ");

        }
        [Test]
        public void ContainsChecksIfTheElementExistsInList()
        {
            //Arrange 
            DynamicList<int> customList = new DynamicList<int>();

            //Act
            customList.Add(420);


            bool  expectedResult = true;
            bool actualResult = customList.Contains(420);
            //Assert
            Assert.AreEqual(expectedResult, actualResult, "Remove does not return -1 when element does not exist in the list ");

        }
    }
}