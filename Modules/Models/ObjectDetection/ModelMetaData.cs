using Microsoft.ML.OnnxRuntime;

namespace Modules.Models.ObjectDetection
{
    public class ModeMetalData
    {
        public ModeMetalData(InferenceSession session)
        {
            this.Name = session.InputMetadata.Keys.FirstOrDefault();
            this.InputWidth = session.InputMetadata[this.Name].Dimensions[3];
            this.InputHeight = session.InputMetadata[this.Name].Dimensions[2];
            this.ModelOutputs = session.OutputMetadata.Keys.ToArray();
            this.OutputDimentions = session.OutputMetadata[ModelOutputs[0]].Dimensions[1];
        }

        public string[]? ModelOutputs { get;}

        public string? Name { get; }

        public int OutputDimentions {  get;}

        public int InputWidth { get; }

        public int InputHeight { get; }
    }
}