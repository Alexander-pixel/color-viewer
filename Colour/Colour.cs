using System;
using System.Windows.Media;

namespace ColourModel
{
    public class Colour
    {
        private int _alpha;
        private int _green;
        private int _red;
        private int _blue;

        public int Alpha 
        {
            get => _alpha;
            set => _alpha = value;
        }

        public int Green
        {
            get => _green;
            set => _green = value;
        }

        public int Red
        {
            get => _red;
            set => _red = value;
        }

        public int Blue
        {
            get => _blue;
            set => _blue = value;
        }

        public SolidColorBrush Brush
        {
            get => new SolidColorBrush(Color.FromArgb((byte)_alpha, (byte)_red, (byte)_green, (byte)_blue));
        }
    }
}
