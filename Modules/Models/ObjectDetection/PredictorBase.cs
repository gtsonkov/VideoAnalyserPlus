using Microsoft.ML.OnnxRuntime;
using Modules.Models.ObjectDetection.Interfaces;
using SixLabors.ImageSharp;
using YoloDotNet.Models;

namespace Modules.Models.ObjectDetection
{
    public abstract class PredictorBase : IPredictor, IDisposable
    {
        private readonly InferenceSession session;

        public PredictorBase(string path)
        {
            this.ModelPath = path;
            this.session = new InferenceSession(this.ModelPath);

            
        }

        public string? ModelPath { get; private set; }
        public OnnxModel CurrentModel { get; protected set; }

        public void Dispose()
        {
            if (this.session != null)
            {
                this.session.Dispose();
            }
        }

        public IEnumerable<DetectionArea> GetObjects(Image frame)
        {
            throw new NotImplementedException();
        }
    }
}