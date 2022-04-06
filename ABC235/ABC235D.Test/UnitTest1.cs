using System;
using System.IO;
using NUnit.Framework;

namespace ABC235D.Test
{
    public class TestClass : TestBase
    {
        [Test]
        [TestCase("1")]
        [TestCase("2")]
        [TestCase("3")]
        [TestCase("4")]
        [TestCase("5")]
        public void Test1(string path)
        {
            var input = File.ReadAllText($@"Resources\Cases\{path}\input.txt");
            var expected = File.ReadAllText($@"Resources\Cases\{path}\expected.txt");

            Test(input, expected, () => { ABC235D.Program.Main(new String[] { }); });
        }

        [Test]
        public void Test2()
        {
            var reverseRotatable = Program.reverseRotatable(2013);
            Console.WriteLine(reverseRotatable);
            var headToSuffix = ABC235D.Program.getHeadToSuffix(2013);
            Console.WriteLine(headToSuffix);
        }
    }
}