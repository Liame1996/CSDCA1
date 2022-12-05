using Microsoft.VisualStudio.TestTools.UnitTesting;

using BPCalculator;

namespace CA1CSDUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Category_returns_Low()
        {
            BloodPressure bloodPressure = new BloodPressure
            {
                Systolic = 80,
                Diastolic = 40
            };
            Assert.AreEqual(bloodPressure.Category, (BPCategory.Low));
        }

        [TestMethod]
        public void Test_Category_returns_Ideal()
        {
            BloodPressure bloodPressure = new BloodPressure
            {
                Systolic = 100,
                Diastolic = 70
            };
            Assert.AreEqual(bloodPressure.Category, (BPCategory.Ideal));
        }

        [TestMethod]
        public void Test_Category_returns_PreHigh()
        {
            BloodPressure bloodPressure = new BloodPressure
            {
                Systolic = 130,
                Diastolic = 85
            };
            Assert.AreEqual(bloodPressure.Category, (BPCategory.PreHigh));
        }

        [TestMethod]
        public void Test_Category_returns_High()
        {
            BloodPressure bloodPressure = new BloodPressure
            {
                Systolic = 170,
                Diastolic = 95
            };
            Assert.AreEqual(bloodPressure.Category, (BPCategory.High));
        }
    }
}
