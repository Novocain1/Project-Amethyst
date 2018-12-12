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
        public override void OnHeldInteractStart(IItemSlot slot, IEntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, ref EnumHandHandling handling)
        {
            BlockPos pos = blockSel.Position;
            AssetLocation asset = new AssetLocation("amethyst:amethyst-dust-isolated-unlit");
            if (pos != null)
            {
                api.World.BlockAccessor.SetBlock(api.World.BlockAccessor.GetBlock(asset).BlockId, pos + new BlockPos(0,1,0));
                slot.TakeOut(1);
                slot.MarkDirty();
                return;
            }
            return;
        }
    }
}
