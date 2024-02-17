using System.Drawing;

namespace Modules.Interfaces
{
    public interface IStreamable
    {
        public void DisplayFrame (Bitmap frame, List<IDetectionArea>[] detectedAreas);
    }
}