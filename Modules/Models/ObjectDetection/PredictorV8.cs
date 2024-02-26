namespace Modules.Models.ObjectDetection
{
    public class PredictorV8 : PredictorBase
    {
        public PredictorV8(string path, string[]? objects, bool filter) 
            : base(path, objects, filter)
        {

        }

        public override IEnumerable<DetectionArea> GetPredictions()
        {
            throw new NotImplementedException();
        }
    }
}