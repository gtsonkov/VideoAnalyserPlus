using Modules.Interfaces;

namespace Modules.Models
{
    public class Label : ILabel
    {
        public Label(string name, string color)
        {
            this.Name = name;
            this.Color = color;
        }

        public Label(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public string? Color { get; set; }
    }
}