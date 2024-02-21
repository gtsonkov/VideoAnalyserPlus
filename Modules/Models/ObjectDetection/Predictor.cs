namespace Modules.Models.ObjectDetection
{
    public class Predictor : PredictorBase
    {
        public Predictor(string path, string[] labels) 
            : base(path, labels)
        {

        }
    }
}