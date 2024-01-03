using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using Modules.Models.ObjectDetection.Interfaces;
using SixLabors.ImageSharp;

namespace Modules.Models.ObjectDetection
{
    public abstract class PredictorBase : IPredictor, IDisposable
    {
        private readonly InferenceSession session;
        private readonly ModeMetaData metaData;
        private List<OnnxLabel> labels;
        private bool applyFilter;
        private bool disposed;

        public PredictorBase(string path, string[]? objects, bool applyFilter = false)
        {
            this.ModelPath = path;
            try
            {
                this.session = new InferenceSession(this.ModelPath);
                this.metaData = new ModeMetaData(this.session);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

            this.labels = metaData.Labels;
        }

        public string? ModelPath { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose (bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    session?.Dispose();
                }

                disposed = true;
            }
        }

        public abstract IEnumerable<DetectionArea> GetPredictions(Image frame);

        protected virtual IEnumerable<DetectionArea> ExtractPredictions(List<Tensor<float>> output, Image frame)
        {
            var predictions = new List<DetectionArea>();

            var currentValue = output[0];

            int imageWidth = frame.Width;
            int imageHeight = frame.Height;
            float widthScale = metaData.InputWidth / (float)imageWidth;
            float heightScale = metaData.InputHeight / (float)imageHeight;
            float widthOffset = (metaData.InputWidth - imageWidth * widthScale) / 2;
            float heightOffset = (metaData.InputHeight - imageHeight * heightScale) / 2;

            float numPredictions = currentValue.Dimensions[1];
            int numClasses = metaData.OutputDimentions - 4;

            for (int i = 0; i < currentValue.Dimensions[0]; i++)
            {
                var currentOffset = i * numPredictions * metaData.OutputDimentions;
                for (int j = 0; j < numPredictions; j++)
                {
                    int offset = (int)currentOffset + j * metaData.OutputDimentions;
                    var (centerX, centerY, bboxWidth, bboxHeight) = (
                        currentValue[offset],
                        currentValue[offset + 1],
                        currentValue[offset + 2],
                        currentValue[offset + 3]);

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
                        var currentLabel = new Label(labels[classIndex].Name);
                        predictions.Add(new DetectionArea((int)minX
                                                         , (int)minY
                                                         , (int)(maxX - minX)
                                                         , (int)(maxY - minY)
                                                         , currentLabel));
                    }
                }
            }

            return predictions.ToList();
        }

        protected virtual IEnumerable<DetectionArea> ExtractPredictions(Image frame
                                                                      , DenseTensor<float> output
                                                                      , bool useFilter
                                                                      , object[]? filters)
        {
            throw new NotImplementedException();
        }

        protected List<Tensor<float>> RunInference(Image frame)
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