using NUnit.Framework;
using Blog.Models;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class ReadFileTest
    {

        [Test]
        public void return_true_if_it_gets_correct_data_is_assigned_to_Title()
        {
            ReadFile test = new ReadFile();

            var resultedFilePath = test.LoadEntries("/Users/hongle/Projects/Blog/Blog/Data");

            var TitleFromSpicyCucumberEntry = resultedFilePath[0].Title;

            Assert.AreEqual("Seasoned Spicy Cucumber", TitleFromSpicyCucumberEntry);
        }
    }
}