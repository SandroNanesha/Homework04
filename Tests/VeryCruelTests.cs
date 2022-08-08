using System;
using System.Linq;
using Homework04;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private CustomGenericList<string> _listOfStrings;
        private CustomGenericList<int> _listOfIntegers;

        [SetUp]
        public void Setup()
        {
            _listOfIntegers = new CustomGenericList<int>();
            _listOfStrings = new CustomGenericList<string>();
        }

        [Test]
        public void TestAddingOfIntegers()
        {
            _listOfIntegers.Add(1);
            Assert.True(_listOfIntegers.ElementAt(0) == 1, "List should have the ability to add items");
        }
        
        [Test]
        public void TestAddingOfStrings()
        {
            _listOfStrings.Add("God, why do I have to do all this?");
            Assert.True(_listOfStrings.ElementAt(0) == "God, why do I have to do all this?");
        }
        
        [Test]
        public void TestInsert()
        {
            _listOfStrings.Add("Just an item");
            _listOfStrings.Insert(0, "Another item");
            
            Assert.True(_listOfStrings.ElementAt(0) == "Another item", "After inserting element at index 0, it must be at 0");
        }
        
        [Test]
        public void TestInsertWithWrongIndex()
        {
            _listOfStrings.Add("Just an item");

            Assert.Throws<ArgumentOutOfRangeException>(() => _listOfStrings.Insert(1, "Oops!"), 
                "When inserted at index that is not present, \"Insert()\" method should throw correct exception");
        }
        
        [Test]
        public void TestRemoveAt()
        {
            _listOfStrings.Add("Just an item");
            _listOfStrings.RemoveAt(0);

            var count = _listOfStrings.Count;
            
            Assert.AreEqual(0, count, $"Expected to have 0 items after removal, but was {count}");
        }
        
        [Test]
        public void TestRemoveAtWrongIndex()
        {
            _listOfStrings.Add("Just an item");
            _listOfStrings.Add("Just another item");

            Assert.Throws<ArgumentOutOfRangeException>(() => _listOfStrings.RemoveAt(2), "When removing at index that is not present, \"RemoveAt()\" method should throw correct exception");
        }
        
        [Test]
        public void TestCounter()
        {
            _listOfIntegers.Add(1);
            _listOfIntegers.Add(1);
            _listOfIntegers.Add(1);
            _listOfIntegers.Add(1);
            _listOfIntegers.Add(1);
            
            Assert.AreEqual(5, _listOfIntegers.Count, $"After adding 5 items, List count must be 5, but was {_listOfIntegers.Count}");
        }
        
        [Test]
        public void TestClear()
        {
            _listOfIntegers.Add(1);
            _listOfIntegers.Add(1);
            _listOfIntegers.Add(1);
            
            _listOfIntegers.Clear();
            
            Assert.AreEqual(0, _listOfIntegers.Count, "After clearing list should become empty");
        }
        
        [Test]
        public void TestContains()
        {
            _listOfStrings.Add("ABBA");
            _listOfStrings.Add("QUEEN");
            _listOfStrings.Add("Def Leppard");
            _listOfStrings.Add("Morgenshtern");
            
            Assert.True(_listOfStrings.Contains("Morgenshtern"), "The list have to contain Morgenshtern (sadly)");
        }
        
        
        [Test]
        public void TestNotContains()
        {
            _listOfStrings.Add("ABBA");
            _listOfStrings.Add("QUEEN");
            _listOfStrings.Add("Def Leppard");
            
            Assert.False(_listOfStrings.Contains("Morgenshtern"), "The list shouldn't contain Morgenshtern, ha!");
        }
        
        [Test]
        public void TestRemovalOnThreeElements()
        {
            _listOfIntegers.Add(1);
            _listOfIntegers.Add(0);
            _listOfIntegers.Add(1);

            _listOfIntegers.Remove(1);
            
            Assert.AreEqual(2, _listOfIntegers.Count, "List count doesn't became smaller after element removal");
            Assert.True(_listOfIntegers.ElementAt(0) == 0, "Array elements must shift after one of elements was removed");
        }
        
        [Test]
        public void TestRemovalOnTwoElements()
        {
            _listOfIntegers.Add(0);
            _listOfIntegers.Add(1);

            _listOfIntegers.Remove(1);
            
            Assert.AreEqual(1, _listOfIntegers.Count, $"List must contain 1 element after removing one. Actual {_listOfIntegers.Count}");
            Assert.True(_listOfIntegers.ElementAt(0) == 0);
        }
        
        [Test]
        public void TestRemovalNonExistentItem()
        {
            _listOfIntegers.Add(0);
            _listOfIntegers.Add(1);

            Assert.False(_listOfIntegers.Remove(3), "List doesn't contain element to be deleted, so \"Remove()\" should return \"false\"");
        }
        
        [Test]
        public void TestIndexOfElement()
        {
            _listOfStrings.Add("I am not the element you're looking for");
            _listOfStrings.Add("I am not the element you're looking for too");
            _listOfStrings.Add("I am the element you're looking for!");

            var index = _listOfStrings.IndexOf("I am the element you're looking for!");

            Assert.True(index == 2, $"Element we are looking for should have index 2, but was {index}");
        }
        
        [Test]
        public void TestIndexOfNonexistentElement()
        {
            _listOfStrings.Add("I am not the element you're looking for");
            _listOfStrings.Add("I am not the element you're looking for too");

            var index = _listOfStrings.IndexOf("No such element");

            Assert.True(index == -1, $"Element we are looking for should have index -1, because there are no such element, but was {index}");
        }
        
        [Test]
        public void TestIndexerGetter()
        {
            _listOfStrings.Add("I am the element you're looking for");

           Assert.True(_listOfStrings[0] == "I am the element you're looking for", 
               "Indexer should return an item of list with provided zero-based index");
        }
        
        [Test]
        public void TestIndexerGetterWrongIndex()
        {
            _listOfStrings.Add("I am the element you're looking for");

            Assert.Throws<ArgumentOutOfRangeException>(()=> _ = _listOfStrings[1], 
               "Indexer should throw a proper exception when trying to access element at nonexistent index");
        }
        
        [Test]
        public void TestIndexerSetter()
        {
            _listOfStrings.Add("I am not the element you're looking for too");
            _listOfStrings[0] = "I am the element you're looking for";

            Assert.True(_listOfStrings[0] == "I am the element you're looking for", 
                "Indexer should ve able to change an item of list with provided zero-based index");
        }
        
        [Test]
        public void TestIndexerSetterWrongIndex()
        {
            _listOfStrings.Add("I am the element you're looking for");

            Assert.Throws<ArgumentOutOfRangeException>(()=> _listOfStrings[1] = "Oops!", 
                "Indexer should throw a proper exception when trying to set value at nonexistent index");
        }

        [Test]
        public void TestCopy()
        {
            _listOfStrings = new CustomGenericList<string> { "Mic", "Check", "One", "Two", "One", "Two"};
            var copyOfList = new string[6];
            _listOfStrings.CopyTo(copyOfList, 0);

            for (int i = 0; i < copyOfList.Length; i++)
            {
               Assert.True(_listOfStrings.ElementAt(i).Equals(copyOfList[i]), 
                   $"List should be able to be copied to array without any changes. Elements doesn't match at index {i}");
            }
        }
    }
}