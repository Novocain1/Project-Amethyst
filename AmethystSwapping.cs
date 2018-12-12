using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;

namespace ProjectAmethyst
{
    class AmethystSwapping : BlockBehavior
    {
        private IPlayer player;
        public AmethystSwapping(Block block) : base(block)
        {
        }

        public override void OnNeighourBlockChange(IWorldAccessor world, BlockPos pos, BlockPos neibpos, ref EnumHandling handling)
        {
            base.OnNeighourBlockChange(world, pos, neibpos, ref handling);
            if (world.BlockAccessor.GetBlock(new BlockPos(pos.X, pos.Y-1, pos.Z)).Id == 0)
            {
                world.BlockAccessor.BreakBlock(pos, player);
                return;
            }
            BlockPos offset = new BlockPos(1, 2, 1);
            Block block = world.BlockAccessor.GetBlock(pos);
            string src = block.Code.ToString();
            AssetLocation src1 = new AssetLocation(src.Replace("-unlit", "-lit"));
            AssetLocation src0 = new AssetLocation(src.Replace("-lit", "-unlit"));

            if (world.BlockAccessor.GetBlock(neibpos).FirstCodePart() == "amethyst" && world.BlockAccessor.GetBlock(neibpos).LastCodePart() == "lit" && neibpos != pos)
            {
                world.BlockAccessor.SetBlock(world.GetBlock(src1).BlockId, pos);
                return;
            }
            world.BlockAccessor.SetBlock(world.GetBlock(src0).BlockId, pos);
        }
    }
}
