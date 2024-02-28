using Microsoft.ML.OnnxRuntime.Tensors;
using SixLabors.ImageSharp;

namespace Modules.Models.ObjectDetection
{
    public class PredictorV8 : PredictorBase
    {
        public PredictorV8(string path, string[]? objects, bool filter) 
            : base(path, objects, filter)
        {

        }

        public override IEnumerable<DetectionArea> GetPredictions(Image frame)
        {
            var inferens = RunInference(frame);
            return ExtractPredictions(inferens, frame).ToList();
        }

        protected override IEnumerable<DetectionArea> ExtractPredictions(Image frame, DenseTensor<float> output, bool useFilter, object[]? filters)
        {
            return base.ExtractPredictions(frame, output, useFilter, filters);
        }
    }
}