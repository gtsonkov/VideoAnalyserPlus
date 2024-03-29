﻿using SixLabors.ImageSharp;

namespace Modules.Models.ObjectDetection.Interfaces
{
    public interface IPredictor
    {
        public string? ModelPath { get;}

        public IEnumerable<DetectionArea> GetPredictions(Image frame);
    }
}