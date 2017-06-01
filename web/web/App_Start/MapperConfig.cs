using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using web.Entities;

namespace web
{
    public class MapperConfig
    {
        public static IMapper Factory { get; private set; }

        public static void Register()
        {
            var option = new MapperConfiguration(config =>
            {

            });

            Factory = option.CreateMapper();
        }
    }
}