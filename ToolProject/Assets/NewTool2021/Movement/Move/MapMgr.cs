using System;
using Pathfinding;
using TrueSync;
namespace Movement
{
    public class MapMgr
    {
        public static MapMgr Inst { get; } = new MapMgr();

        public JPSFinding jPSFinding { get; private set; }

        private float multTileSize;
        public const int tileSize = 24;
        public const int halfSize = 12;
        public const int halfSizeSQ = 144;

        private int tileWidth = 0;
        private int tileHight = 0;

        public int mapWidth { get; private set; } = 0;
        public int mapHight { get; private set; } = 0;
        private byte[,] blockData;

        public const byte TYPE_BLOCK = 1;
        public const byte TYPE_NOBLOCK = 0;
        public bool IsCollisionBlock(TSVector2 pos)
        {
            var cell = PosToCell(pos);
            return false;
        }

        public JPoint PosToCell(TSVector2 pos)
        {
            return new JPoint((int)(pos.x * multTileSize), (int)(pos.y * multTileSize));
        }

        public TSVector2 PosToCenter(TSVector2 pos)
        {

            return new TSVector2(((int)(pos.x * multTileSize) * tileSize + halfSize),((int)(pos.y * multTileSize) * tileSize + halfSize));
        }
    }
}