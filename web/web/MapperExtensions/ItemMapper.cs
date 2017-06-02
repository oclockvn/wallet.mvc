using web.Entities;
using web.ViewModels;

namespace web.MapperExtensions
{
    public static class ItemMapper
    {
        public static Item ToItem(this ItemCreateViewModel viewmodel)
        {
            if (viewmodel == null)
                return null;

            return MapperConfig.Factory.Map<ItemCreateViewModel, Item>(viewmodel);
        }
    }
}