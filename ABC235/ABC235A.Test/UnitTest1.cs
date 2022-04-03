using System;
using System.IO;
using NUnit.Framework;

namespace ABC235A.Test
{
    public class TestClass : TestBase
    {
        [Test]
        [TestCase("1")]
        [TestCase("2")]
        public void Test1(string path)
        {
            var input = File.ReadAllText($@"Resources\Cases\{path}\input.txt");
            var expected = File.ReadAllText($@"Resources\Cases\{path}\expected.txt");

            Test(input, expected, () => { ABC235A.Program.Main(new String[] { }); });
        }
    }
}