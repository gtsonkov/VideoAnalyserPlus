using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using Modules.Models.ObjectDetection.Interfaces;
using SixLabors.ImageSharp;

namespace Modules.Models.ObjectDetection
{
    public abstract class PredictorBase : IPredictor, IDisposable
    {
        private readonly InferenceSession session;
        private readonly ModeMetalData metaData;
        protected string[]? Labels;
        private bool applyFilter;

        public PredictorBase(string path, string[]? objects, bool apllyFilter = false)
        {
            this.ModelPath = path;
            try
            {
                this.session = new InferenceSession(this.ModelPath);
                this.metaData = new ModeMetalData(this.session);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

            this.Labels = objects;
        }

        public string? ModelPath { get; private set; }

        public void Dispose()
        {
            if (this.session != null)
            {
                this.session.Dispose();
            }
        }

        public abstract IEnumerable<DetectionArea> GetPredictions();

        protected IEnumerable<DetectionArea> ExtractPredictions(Tensor<float> output, Image frame)
        {
            var predictions = new List<DetectionArea>();

            int imageWidth = frame.Width;
            int imageHeight = frame.Height;
            float widthScale = metaData.InputWidth / (float)imageWidth;
            float heightScale = metaData.InputHeight / (float)imageHeight;
            float widthOffset = (metaData.InputWidth - imageWidth * widthScale) / 2;
            float heightOffset = (metaData.InputHeight - imageHeight * heightScale) / 2;

            float numPredictions = output.Dimensions[1];
            int numClasses = metaData.OutputDimentions - 4;

            for (int i = 0; i < output.Dimensions[0]; i++)
            {
                var currentOffset = i * numPredictions * metaData.OutputDimentions;
                for (int j = 0; j < numPredictions; j++)
                {
                    int offset = (int)currentOffset + j * metaData.OutputDimentions;
                    var (centerX, centerY, bboxWidth, bboxHeight) = (
                        output[offset],
                        output[offset + 1],
                        output[offset + 2],
                        output[offset + 3]);

                    var (minX, minY, maxX, maxY) = (
                        ((centerX - bboxWidth / 2) - widthOffset) / widthScale,
                        ((centerY - bboxHeight / 2) - heightOffset) / heightScale,
                        ((centerX + bboxWidth / 2) - widthOffset) / widthScale,
                        ((centerY + bboxHeight / 2) - heightOffset) / heightScale);

                    minX = LimitToRange(minX, 0, imageWidth);
                    minY = LimitToRange(minY, 0, imageHeight);
                    maxX = LimitToRange(maxX, 0, imageWidth - 1);
                    maxY = LimitToRange(maxY, 0, imageHeight - 1);

                    for (int classIndex = 0; classIndex < numClasses; classIndex++)
                    {
                        var score = output[offset + 4 + classIndex];
                        predictions.Add(new DetectionArea((int)minX
                                                         , (int)minY
                                                         , (int)(maxX - minX)
                                                         , (int)(maxY - minY)
                                                         , new Label(Labels[classIndex])));
                    }
                }
            }

            return predictions.ToList();
        }

        public virtual IEnumerable<DetectionArea> ExtractPredictions(Image frame
                                                                      , DenseTensor<float> output
                                                                      , bool useFilter
                                                                      , object[]? filters)
        {
            throw new NotImplementedException();
        }

        private List<Tensor<float>> RunInference(Image frame)
        {
            Image tempFrame = null;

            if (frame.Width != metaData.InputWidth && frame.Height != metaData.InputHeight)
            {
                tempFrame = ChangeFrameDimension(frame);
            }
            else
            {
                tempFrame = frame;
            }

            //ONNX data
            List<NamedOnnxValue> data = new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor(metaData.Name, GetFrameTensor(frame))
            };

            var values = this.session.Run(data);

            List<Tensor<float>> result = new List<Tensor<float>>();

            for (int i = 0; i > metaData.ModelOutputs.Length; i++)
            {
                var currentValue = metaData.ModelOutputs[i];

                if (applyFilter)
                {
                    //TO DO: Filter implementation
                    continue;
                }

                result.Add(data.FirstOrDefault((d => d.Name == currentValue)).Value as Tensor<float>);
            }

            return result;
        }

        private Tensor<float> GetFrameTensor(Image frame)
        {
            Tensor<float> output = null;

            throw new NotImplementedException();
        }

        private Image? ChangeFrameDimension(Image frame)
        {
            throw new NotImplementedException();
        }

        private float LimitToRange(float min, float max, float x)
        {
            if (x > max)
            {
                return max;
            }
            else if (x < min)
            {
                return min;
            }
            else
            {
                return x;
            }
        }

        private DetectionArea ValidateArea(DetectionArea currentArea)
        {
            throw new NotImplementedException();
        }
    }
}