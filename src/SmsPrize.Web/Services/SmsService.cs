﻿using Microsoft.Framework.ConfigurationModel;
using SmsPrize.Web.Models;
using System;

namespace SmsPrize.Web.Services
{
    public class SmsService
    {
        private static Random Random { get; } = new Random();

        private IConfiguration Configuration { get; set; }

        public SmsService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public CubeConfig RandomCube()
        {
            var cube = new CubeConfig
            {
                Scale = Configuration.Get<double>("Scale")
            };

            for (var i = 0; i < 12; i++)
                cube.Planes.Add(RandomCubePlane());

            return cube;
        }

        private CubeConfig.CubePlaneConfig RandomCubePlane()
        {
            var plane = new CubeConfig.CubePlaneConfig
            {
                Text = Random.Next(1, 99).ToString(),
                FontSize = Random.Next(50, 150).ToString()+"pt",
                TextColor = "#" + 
                    Random.Next(1, 255).ToString("X2") + 
                    Random.Next(1, 255).ToString("X2") + 
                    Random.Next(1, 255).ToString("X2")
            };

            return plane;
        }
    }
}
