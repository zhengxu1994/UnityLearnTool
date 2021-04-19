using System;
using System.Collections.Generic;
using TrueSync;

namespace Movement
{
    public class MoveMgr
    {
        public static MoveMgr Inst { get; } = new MoveMgr();

        public static int rvoTick { get; set; } = 1;

        static bool _enable = false;

        public static bool enable
        {
            get => _enable;
            set
            {
                if(_enable != value)
                {
                    _enable = value;
                    if(_enable)
                    {
                        //设置rvo update时间 1秒钟30次
                        RVO.Simulator.Instance.setTimeStep(1f / 30f);
                        // 设置新的寻路对象 默认值
                        RVO.Simulator.Instance.setAgentDefaults(300, 10, 2, 5f, 50f, 50f, new TSVector2(0, 0));
                        // 创建阻挡点信息
                        RVO.Simulator.Instance.processObstacles();
                    }
                    else
                    {
                        //清除rvo寻路信息
                        RVO.Simulator.Instance.Clear();
                    }
                }
            }
        }

        //private Dictionary<int,>

        private byte[,] moveBlock;
        private float multSize;

        public const int logicSize = 24;
        public const int halfSize = 12;
        public const int searchRadius = 20;

        public int logicWidth { get; private set; }
        public int logicHeight { get; private set; }

        public const int InvalidUid = int.MinValue;
        public static readonly TSVector2 InvalidPos = new TSVector2(-1, -1);

        private List<int> searchUids = new List<int>();

        private MoveMgr()
        {
        }

        //public List<int> GetUnitsInCell(TSVector2 pos,int camp = -1,int skipUid =InvalidUid,UnitFlag flag = UnitFlag.None)
        //{
        //    //var cell = PosToCell(pos);
        //    return GetUnitsInCell(cell.x, cell.y, camp, skipUid, flag);
        //}

        //internal List<int> GetUnitsInCell(int x,int y,int camp =-1,int skipUid= InvalidUid,UnitFlag flag = UnitFlag.None)
        //{
        //    searchUids.Clear();

        //}
    }
}
