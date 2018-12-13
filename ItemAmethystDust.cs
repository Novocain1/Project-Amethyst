using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.MathTools;

namespace ProjectAmethyst
{
    class ItemAmethystDust : Item
    {
        IPlayer player;
        public override void OnHeldInteractStart(IItemSlot slot, IEntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, ref EnumHandHandling handling)
        {
            BlockPos pos = blockSel.Position;
            
            AssetLocation asset = new AssetLocation("amethyst:amethyst-dust-isolated-unlit");
            if (pos != null && !api.World.BlockAccessor.GetBlock(pos + new BlockPos(0, 1, 0)).WildCardMatch(new AssetLocation("amethyst:amethyst-dust*")) && !api.World.BlockAccessor.GetBlock(pos).WildCardMatch(new AssetLocation("amethyst:amethyst-dust*")))
            {
                api.World.BlockAccessor.SetBlock(api.World.BlockAccessor.GetBlock(asset).BlockId, pos + new BlockPos(0,1,0));
                slot.TakeOut(1);
                slot.MarkDirty();
                api.World.PlaySoundAt(api.World.BlockAccessor.GetBlock(asset).Sounds.Place, pos.X, pos.Y, pos.Z);
                return;
            }
            return;
        }
    }
}
