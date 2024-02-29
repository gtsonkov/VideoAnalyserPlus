using Microsoft.ML.OnnxRuntime;
using Newtonsoft.Json;

namespace Modules.Models.ObjectDetection
{
    public class ModeMetaData
    {
        public ModeMetaData(InferenceSession session)
        {
            this.Name = session.InputMetadata.Keys.FirstOrDefault();
            this.InputWidth = session.InputMetadata[this.Name].Dimensions[3];
            this.InputHeight = session.InputMetadata[this.Name].Dimensions[2];
            this.ModelOutputs = session.OutputMetadata.Keys.ToArray();
            this.OutputDimentions = session.OutputMetadata[ModelOutputs[0]].Dimensions[1];
            this.Labels = GetLabelsData(session.ModelMetadata.CustomMetadataMap["Names"]);
        }

        public string[]? ModelOutputs { get;}

        public string? Name { get; }

        public int OutputDimentions {  get;}

        public int InputWidth { get; }

        public int InputHeight { get; }

        internal List<OnnxLabel> Labels { get; set; }

        private List<OnnxLabel> GetLabelsData (string input)
        {
            var onnxLabels = JsonConvert.DeserializeObject<Dictionary<int,string>>(input);

            List<OnnxLabel> result = new List<OnnxLabel>(onnxLabels.Count);

            foreach (var label in onnxLabels)
            {
                OnnxLabel currentLabel = new OnnxLabel(label.Value, label.Key);
                result.Add(currentLabel);
            }

            return result;
        }
    }
}