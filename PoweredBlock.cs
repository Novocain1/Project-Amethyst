﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;

namespace ProjectAmethyst
{
    class PoweredBlock : BlockEntity
    {
        public long listenerId;
        private HashSet<BlockPos> positions = new HashSet<BlockPos>();

        public override void Initialize(ICoreAPI api)
        {
            base.Initialize(api);
            listenerId = RegisterGameTickListener(Check, 100);
        }

        private void Check(float dt)
        {
            positions.Clear();
            BlockPos offset = new BlockPos(1, 2, 1);
            Block block = api.World.BlockAccessor.GetBlock(pos);
            string src = block.Code.ToString();
            AssetLocation src1 = new AssetLocation(src.Replace("-unlit", "-lit"));
            AssetLocation src0 = new AssetLocation(src.Replace("-lit", "-unlit"));

            for (int x = pos.X - offset.X; x <= pos.X + offset.X; x++)
            {
                for (int y = pos.Y - offset.Y; y <= pos.Y + offset.Y; y++)
                {
                    for (int z = pos.Z - offset.Z; z <= pos.Z + offset.Z; z++)
                    {
                        BlockPos cBP = new BlockPos(x, y, z);
                        if (api.World.BlockAccessor.GetBlock(cBP).FirstCodePart() == "amethyst" && cBP != pos)
                        {
                            positions.Add(cBP);
                        }
                    }
                }
            }

            foreach (var val in positions)
            {
                if (api.World.BlockAccessor.GetBlock(val).LastCodePart() == "lit")
                {
                    api.World.BlockAccessor.SetBlock(api.World.GetBlock(src1).BlockId, pos);
                    return;
                }
            }

            api.World.BlockAccessor.SetBlock(api.World.GetBlock(src0).BlockId, pos);
            return;
        }

        public override void OnBlockUnloaded()
        {
            base.OnBlockUnloaded();
            api.World.UnregisterGameTickListener(listenerId);
        }
    }
}
