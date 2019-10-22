using System;
using System.IO;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace CompanyNews.UITests
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void FirstScreenLoadsProperly()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Cafeteria is now open!"));
            app.Screenshot("News Items screen.");

            Assert.IsTrue(results.Any());
        }

        [Test]
        public void TappingItemGoesToDetailsPage()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Cafeteria is now open!"));
            app.Screenshot("News Items screen.");

            Assert.AreEqual(1, results.Length, "Expect only one element");

            // Tap on the news item
            app.Tap(c => c.Marked("Cafeteria is now open!"));

            Thread.Sleep(1000);

            app.Screenshot("Cafeteria details screen.");
        }
    }
}
