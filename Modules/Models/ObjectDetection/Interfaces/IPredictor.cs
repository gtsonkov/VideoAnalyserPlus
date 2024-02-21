using Microsoft.ML.OnnxRuntime.Tensors;
using SixLabors.ImageSharp;

namespace Modules.Models.ObjectDetection.Interfaces
{
    public interface IPredictor
    {
        public string? ModelPath { get;}

        public IEnumerable<DetectionArea> GetObjects(DenseTensor<float> output, Image fram);
    }
}