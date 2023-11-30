using System;

namespace Randolf.WordToolkit.Model
{
    public class PicStyle
    {
        // unit: actual word set size
        private float _width { get; set; } = 339.9f;
        // Unit: cm
        public float Width { 
            get
            {
                return _width;
            }
            set
            {
                _width = value / 3.53f * 100f;
            }
        }
       
        public float Height { get; set; }
    }
}