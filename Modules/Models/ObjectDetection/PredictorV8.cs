namespace Modules.Models.ObjectDetection
{
    public class PredictorV8 : PredictorBase
    {
        public PredictorV8(string path, string[]? objects, bool filter = false) 
            : base(path, filter, objects)
        {

        }

        public override IEnumerable<DetectionArea> GetPredictions()
        {
            throw new NotImplementedException();
        }
    }
}