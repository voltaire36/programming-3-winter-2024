using Microsoft.ML;
using Microsoft.ML.Data;
using System;



namespace Q2
{
    class Program
    {
        static void Main(string[] args)
        {
            var mlContext = new MLContext(seed: 0);

            // Load data
            var dataView = mlContext.Data.LoadFromTextFile<Student>(
                @"C:\3 Centennial College\4th Semester\Programming 3\Lab5\Q2\Data\Student.csv",
                hasHeader: true,
                separatorChar: ',');

            // Define learning pipeline
            var pipeline = mlContext.Transforms.Conversion.MapValueToKey(inputColumnName: nameof(Student.UNS), outputColumnName: "Label")
                .Append(mlContext.Transforms.Concatenate("Features", nameof(Student.STG), nameof(Student.SCG), nameof(Student.STR), nameof(Student.LPR), nameof(Student.PEG)))
                .Append(mlContext.Clustering.Trainers.KMeans(featureColumnName: "Features", numberOfClusters: 4));

            // Train model
            var model = pipeline.Fit(dataView);

            Console.WriteLine("Model training complete.");

            // Test with a single prediction 
            var predictionFunction = mlContext.Model.CreatePredictionEngine<Student, ClusterPrediction>(model);
            var prediction = predictionFunction.Predict(
                new Student
                {
                    STG = 0.2f,
                    SCG = 0.14f,
                    STR = 0.35f,
                    LPR = 0.72f,
                    PEG = 0.25f
                });

            Console.WriteLine($"Predicted cluster: {prediction.PredictedClusterId}");
            Console.WriteLine($"Distances: {string.Join(", ", prediction.Distances)}");
        }
    }
}

