using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace ProjectAmethyst
{
    public class ProjectPurpleRock : ModSystem
    {
        public override void Start(ICoreAPI api)
        {
            base.Start(api);
            api.RegisterBlockBehaviorClass("AmethystSwapping", typeof(AmethystSwapping));
            api.RegisterItemClass("ItemAmethystDust", typeof(ItemAmethystDust));
        }
    }
}