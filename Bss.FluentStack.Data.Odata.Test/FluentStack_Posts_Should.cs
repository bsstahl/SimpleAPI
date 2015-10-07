using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Bss.FluentStack.Data.Odata.Test
{
    [TestClass]
    public class FluentStack_Posts_Should
    {
        // private const string _stackoverflowServiceRoot = "http://data.stackexchange.com/stackoverflow/atom";
        private const string _stackoverflowServiceRoot = "http://localhost:54290/StackOverflowData.svc/";

        public TestContext TestContext { get; set; }

        #region Demo1

        [TestMethod]
        public void ReturnResultsFromTheBaselineQuery()
        {
            var results = new StackOverflowService.Entities(new Uri(_stackoverflowServiceRoot)).Posts
                .Where(p => p.Parent == null && p.AcceptedAnswerId != null
                    && p.CreationDate > DateTime.UtcNow.Subtract(TimeSpan.FromDays(30))
                    && p.Tags.Contains("<odata>"));

            DisplayPosts(results);
        }

        [TestMethod]
        public void ReturnTheCorrectResultsWhenACustomContextIsUsed()
        {
            var expectedResults = new StackOverflowService.Entities(new Uri(_stackoverflowServiceRoot)).Posts
                .Where(p => p.Parent == null && p.AcceptedAnswerId != null
                    && p.CreationDate > DateTime.UtcNow.Subtract(TimeSpan.FromDays(30))
                    && p.Tags.Contains("<odata>"));

            var actualResults = new FluentStack().Posts
                .Where(p => p.Parent == null && p.AcceptedAnswerId != null
                    && p.CreationDate > DateTime.UtcNow.Subtract(TimeSpan.FromDays(30))
                    && p.Tags.Contains("<odata>"));

            RunComparisonTest(expectedResults, actualResults);
        }

        #endregion

        #region Demo2

        [TestMethod]
        public void ReturnTheCorrectResultsWhenQuestionsMethodIsUsed()
        {
            var expectedResults = new StackOverflowService.Entities(new Uri(_stackoverflowServiceRoot)).Posts
                .Where(p => p.Parent == null && p.AcceptedAnswerId != null
                    && p.CreationDate > DateTime.UtcNow.Subtract(TimeSpan.FromDays(30))
                    && p.Tags.Contains("<odata>"));

            var actualResults = new FluentStack().Posts.Questions()
                .Where(p => p.AcceptedAnswerId != null
                    && p.CreationDate > DateTime.UtcNow.Subtract(TimeSpan.FromDays(30))
                    && p.Tags.Contains("<odata>"));

            RunComparisonTest(expectedResults, actualResults);
        }

        [TestMethod]
        public void ReturnTheCorrectResultsWhenQuestionsPropertyIsUsed()
        {
            var expectedResults = new StackOverflowService.Entities(new Uri(_stackoverflowServiceRoot)).Posts
                .Where(p => p.Parent == null && p.AcceptedAnswerId != null
                    && p.CreationDate > DateTime.UtcNow.Subtract(TimeSpan.FromDays(30))
                    && p.Tags.Contains("<odata>"));

            var actualResults = new FluentStack().Questions
                .Where(p => p.AcceptedAnswerId != null
                    && p.CreationDate > DateTime.UtcNow.Subtract(TimeSpan.FromDays(30))
                    && p.Tags.Contains("<odata>"));

            RunComparisonTest(expectedResults, actualResults);
        }

        [TestMethod]
        public void ReturnTheCorrectResultsWhenWithAcceptedAnswerMethodIsUsed()
        {
            var expectedResults = new StackOverflowService.Entities(new Uri(_stackoverflowServiceRoot)).Posts
                .Where(p => p.Parent == null && p.AcceptedAnswerId != null
                    && p.CreationDate > DateTime.UtcNow.Subtract(TimeSpan.FromDays(30))
                    && p.Tags.Contains("<odata>"));

            var actualResults = new FluentStack().Questions.WithAcceptedAnswer()
                .Where(p => p.CreationDate > DateTime.UtcNow.Subtract(TimeSpan.FromDays(30))
                    && p.Tags.Contains("<odata>"));

            RunComparisonTest(expectedResults, actualResults);
        }

        #endregion

        #region Demo3

        [TestMethod]
        public void ReturnTheCorrectResultsWhenAskedInLast30DaysExpressionIsUsed()
        {
            var expectedResults = new StackOverflowService.Entities(new Uri(_stackoverflowServiceRoot)).Posts
                .Where(p => p.Parent == null && p.AcceptedAnswerId != null
                    && p.CreationDate > DateTime.UtcNow.Subtract(TimeSpan.FromDays(30))
                    && p.Tags.Contains("<odata>"));

            var actualResults = new FluentStack().Questions.WithAcceptedAnswer()
                .Where(Asked.InLast(30.Days()))
                .Where(p => p.Tags.Contains("<odata>"));

            RunComparisonTest(expectedResults, actualResults);
        }

        [TestMethod]
        public void ReturnTheCorrectResultsWhenTaggedWithOdataMethodIsUsed()
        {
            var expectedResults = new StackOverflowService.Entities(new Uri(_stackoverflowServiceRoot)).Posts
                .Where(p => p.Parent == null && p.AcceptedAnswerId != null
                    && p.CreationDate > DateTime.UtcNow.Subtract(TimeSpan.FromDays(30))
                    && p.Tags.Contains("<odata>"));

            var actualResults = new FluentStack().Questions.WithAcceptedAnswer()
                .Where(Asked.InLast(30.Days()))
                .TaggedWith("odata");

            RunComparisonTest(expectedResults, actualResults);
        }

        #endregion

        #region Helper Methods

        private void RunComparisonTest(IEnumerable<StackOverflowService.Post> expecteds, IEnumerable<StackOverflowService.Post> actuals)
        {
            TestContext.WriteLine("Actual Count: {0}", actuals.Count());
            Assert.IsTrue(actuals.Any(), "No results returned");

            DisplayPosts(actuals);

            Assert.AreEqual(expecteds.Count(), actuals.Count(), "Incorrect number of results returned");

            foreach (var expected in expecteds)
            {
                var thisExpectedItem = expected;
                var thisActualItem = actuals.Where(t => t.ID == thisExpectedItem.ID);
                Assert.AreEqual(1, thisActualItem.Count(), "Expected 1 instance of {0} - {1}", expected.ID, expected.Title);
            }
        }

        private void DisplayPosts(IEnumerable<StackOverflowService.Post> actuals)
        {
            foreach (var actual in actuals)
            {
                TestContext.WriteLine("{0} - Created: {1}", actual.Title, actual.CreationDate);
            }
        }

        #endregion

    }
}
