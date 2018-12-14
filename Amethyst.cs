using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace ProjectAmethyst
{
    public class ProjectAmethyst : ModSystem
    {
        public override void Start(ICoreAPI api)
        {
            base.Start(api);
            api.RegisterBlockEntityClass("PoweredBlock", typeof (PoweredBlock));
            api.RegisterItemClass("ItemAmethystDust", typeof(ItemAmethystDust));
        }
    }
}