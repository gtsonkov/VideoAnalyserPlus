namespace Modules.Models.ObjectDetection
{
    public class PredictorV8 : PredictorBase
    {
        public PredictorV8(string path, string[] labels) 
            : base(path, labels)
        {

        }

        public override IEnumerable<DetectionArea> GetPredictions()
        {
            throw new NotImplementedException();
        }
    }
}