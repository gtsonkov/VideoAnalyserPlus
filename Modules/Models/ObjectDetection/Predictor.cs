
namespace Modules.Models.ObjectDetection
{
    public class Predictor : PredictorBase
    {
        public Predictor(string path, string[] labels) 
            : base(path, labels)
        {

        }

        public override IEnumerable<DetectionArea> GetPredictions()
        {
            throw new NotImplementedException();
        }
    }
}