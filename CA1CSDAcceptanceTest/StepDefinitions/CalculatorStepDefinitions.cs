using BPCalculator;

namespace CA1CSDAcceptanceTest.StepDefinitions
{
    [Binding]
    public sealed class BPCalculatorStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        BloodPressure bloodPressure = new BloodPressure();
        String? BPCategory;

        [Given("Systolic is (.*)")]
        public void SetSystolic(int Systolic)
        {
            bloodPressure.Systolic = Systolic;

        }

        [Given("Diastolic is (.*)")]
        public void SetDiastolic(int Diastolic)
        {
            bloodPressure.Diastolic = Diastolic;
        }

        [When("the numbers are calculated")]
        public void SetBPCategory()
        {
            BPCategory = bloodPressure.Category.ToString();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(string result)
        {
            BPCategory.Should().Be(result);
        }
    }
}