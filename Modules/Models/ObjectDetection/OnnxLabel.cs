namespace Modules.Models.ObjectDetection
{
    internal class OnnxLabel
    {
        public OnnxLabel()
        {
            
        }

        public OnnxLabel(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }

        public int Id { get; set; }

        public string? Name { get; set; }
    }
}