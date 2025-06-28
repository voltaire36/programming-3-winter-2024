using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;
using Lab5;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            var mlContext = new MLContext();

            var dataView = mlContext.Data.LoadFromTextFile<InsuranceData>(@"C:\3 Centennial College\4th Semester\Programming 3\Lab5\Lab5\Data\insurance.csv", hasHeader: true, separatorChar: ',');

            var pipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: "Charges")
                .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "SexEncoded", inputColumnName: "Sex"))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "SmokerEncoded", inputColumnName: "Smoker"))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "RegionEncoded", inputColumnName: "Region"))
                .Append(mlContext.Transforms.Concatenate("Features", "Age", "SexEncoded", "Bmi", "Children", "SmokerEncoded", "RegionEncoded"))
                .Append(mlContext.Regression.Trainers.FastTree());

            var dataSplit = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
            var trainingData = dataSplit.TrainSet;
            var testData = dataSplit.TestSet;

            Console.WriteLine("Training the model...");
            var model = pipeline.Fit(trainingData);

            var predictions = model.Transform(testData);
            var metrics = mlContext.Regression.Evaluate(predictions);
            Console.WriteLine($"R^2: {metrics.RSquared:0.##}");
            Console.WriteLine($"RMSE: {metrics.RootMeanSquaredError:0.##}");

            var predictionFunction = mlContext.Model.CreatePredictionEngine<InsuranceData, InsurancePrediction>(model);
            var sampleData = new InsuranceData
            {
                Age = 29,
                Sex = "female",
                Bmi = 29.0f,
                Children = 2,
                Smoker = "no",
                Region = "northwest"
            };
            var prediction = predictionFunction.Predict(sampleData);
            Console.WriteLine($"Predicted charges: {prediction.Charges}");
        }

    }
}
