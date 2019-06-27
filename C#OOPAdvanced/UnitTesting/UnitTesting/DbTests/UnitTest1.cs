using NUnit.Framework;
using UnitTesting;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void EmptyCtorShouldInitData()
        {
            Database db = new Database();
        }
    }
}