namespace Lab5
{
    using Microsoft.ML.Data;

    public class InsuranceData
    {
        [LoadColumn(0)] public float Age;
        [LoadColumn(1)] public string? Sex;
        [LoadColumn(2)] public float Bmi;
        [LoadColumn(3)] public float Children;
        [LoadColumn(4)] public string? Smoker;
        [LoadColumn(5)] public string? Region;
        [LoadColumn(6)] public float Charges;
    }

    public class InsurancePrediction
    {
        [ColumnName("Score")]
        public float Charges;
    }
}
