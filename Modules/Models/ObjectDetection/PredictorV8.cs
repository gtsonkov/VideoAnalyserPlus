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
    }
}