using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using StackOverflow.Model;
using System.Linq;

namespace Bss.EnumerableStack.Data.Test
{
    [TestClass]
    public class EnumerableStack_Posts_Should
    {
        public TestContext TestContext { get; set; }


        [TestMethod]
        public void ReturnTheCorrectResultsWhenACustomContextIsUsed()
        {
            var actualResults = new EnumerableStack().Posts;
            DisplayPosts(actualResults);
            Assert.AreEqual(95, actualResults.Count());
        }

        [TestMethod]
        public void ReturnTheCorrectResultsWhenQuestionsMethodIsUsed()
        {
            var actualResults = new EnumerableStack().Posts.Questions();
            DisplayPosts(actualResults);
            Assert.AreEqual(93, actualResults.Count());
        }

        [TestMethod]
        public void ReturnTheCorrectResultsWhenQuestionsPropertyIsUsed()
        {
            var actualResults = new EnumerableStack().Questions;
            DisplayPosts(actualResults);
            Assert.AreEqual(93, actualResults.Count());
        }

        [TestMethod]
        public void ReturnTheCorrectResultsWhenWithAcceptedAnswerMethodIsUsed()
        {
            var actualResults = new EnumerableStack().Questions.WithAcceptedAnswer();
            DisplayPosts(actualResults);
            Assert.AreEqual(32, actualResults.Count());
        }

        [TestMethod]
        public void ReturnTheCorrectResultsWhenAskedInLast30DaysExpressionIsUsed()
        {
            var actualResults = new EnumerableStack().Questions.Where(Asked.InLast(30.Days()));
            DisplayPosts(actualResults);
            Assert.AreEqual(93, actualResults.Count());
        }

        [TestMethod]
        public void ReturnTheCorrectResultsWhenTaggedWithOdataMethodIsUsed()
        {
            var actualResults = new EnumerableStack().Questions.TaggedWith("odata");
            DisplayPosts(actualResults);
            Assert.AreEqual(8, actualResults.Count());
        }

        [TestMethod]
        public void ReturnTheCorrectResultsWhenTheFullQueryExpressionIsUsed()
        {
            var actualResults = new EnumerableStack().Questions.WithAcceptedAnswer()
                .Where(Asked.InLast(30.Days()))
                .TaggedWith("odata");
            DisplayPosts(actualResults);
            Assert.AreEqual(2, actualResults.Count());
        }

        private void DisplayPosts(IEnumerable<Post> actuals)
        {
            foreach (var actual in actuals)
            {
                TestContext.WriteLine("{0} - Created: {1}", actual.Title, actual.CreationDate);
            }
        }

    }
}
