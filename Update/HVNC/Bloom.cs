using System.Drawing;

namespace BirdBrainmofo.HVNC
{
    public class BloomBrain
    {
        public string _Name;

        private Color _Value;

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        public Color Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
            }
        }

        public BloomBrain()
        {
        }

        public BloomBrain(string name, Color value)
        {
            _Name = name;
            _Value = value;
        }
    }
}
