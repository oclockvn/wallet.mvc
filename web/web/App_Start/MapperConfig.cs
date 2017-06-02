using AutoMapper;
using System;
using web.Entities;
using web.ViewModels;

namespace web
{
    public class MapperConfig
    {
        public static IMapper Factory { get; private set; }

        public static void Register()
        {
            var option = new MapperConfiguration(config =>
            {
                config.CreateMap<ItemCreateViewModel, Item>()
                    .AfterMap((vm, m) =>
                    {
                        m.Time = DateTime.Now;
                        m.Done = false;
                        m.Checked = false;
                        m.Active = true;
                    });

                config.CreateMap<Item, ItemIndexViewModel>();
            });

            Factory = option.CreateMapper();
        }
    }
}