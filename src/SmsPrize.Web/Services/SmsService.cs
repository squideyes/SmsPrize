using Microsoft.Framework.ConfigurationModel;
using SmsPrize.Web.Models;
using System;

namespace SmsPrize.Web.Services
{
    public class SmsService
    {
        private static Random R { get; set; } = new Random();
        private IConfiguration Configuration { get; set; }

        public SmsService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public CubeConfig RandomCube()
        {
            var size = R.Next(200, 400);

            var cube = new CubeConfig
            {
                Width = size,
                Height = size,
            };

            for (var i = 0; i < 12; i++)
            {
                cube.Planes.Add(RandomCubePlane());
            }

            return cube;
        }

        private CubeConfig.CubePlaneConfig RandomCubePlane()
        {
            var plane = new CubeConfig.CubePlaneConfig
            {
                Text = R.Next(1, 99).ToString(),
                FontSize = R.Next(50, 150).ToString()+"pt",
                TextColor = "#" + R.Next(1, 255).ToString("X2") + R.Next(1, 255).ToString("X2") + R.Next(1, 255).ToString("X2")
            };
            return plane;
        }
    }
}
