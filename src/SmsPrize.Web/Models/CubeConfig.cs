using System;
using System.Collections.Generic;

namespace SmsPrize.Web.Models
{
    public class CubeConfig
    {
        public IList<CubePlaneConfig> Planes { get; set; } = new List<CubePlaneConfig>();
        public double Scale { get; set; }

        public class CubePlaneConfig
        {
            public string Text { get; set; }
            public string FontSize { get; set; }
            public string TextColor { get; set; }
        }
    }    
}
