using System;
using TrueSync;
namespace Movement
{
    public class Calculater
    {
        private static int[] tmpArr = { 2, 1, 0, 7, 6, 5, 4, 3, 2 };


        public static int GetDirByVector(TSVector2 vector)
        {
            return tmpArr[(int)Math.Floor((Math.Atan2((float)vector.y, (float)vector.x) + Math.PI) / (Math.PI * 0.25f) + 0.5f)];
        }

        public static int GetDirByPos(TSVector2 start,TSVector2 tarPos)
        {
            float x = (float)tarPos.x - (float)start.x;
            float y = (float)tarPos.y - (float)start.y;
            return tmpArr[(int)Math.Floor((Math.Atan2(y, x) + Math.PI) / (Math.PI * 0.25f) + 0.5f)];
        }

        public static TSVector2[] GetPathByBezier(TSVector2 start,TSVector2 control,TSVector2 end,int pointNum)
        {
            TSVector2[] path = new TSVector2[pointNum];
            for (int i = 0; i < pointNum; i++)
            {
                var t = (i + 1) / (FP)pointNum;
                path[i] = GetBezierPoint(t, start, control, end);
            }
            return path;
        }

        public static TSVector2 GetBezierPoint(FP t,TSVector2 start,TSVector2 control,TSVector2 end)
        {
            return (1 - t) * (1 - t) * start + 2 * t * (1 - t) * control + t * t * end;
        }
    }
}