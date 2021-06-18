using System;
using UnityEngine;
using System.Collections.Generic;
using FairyGUI;
namespace ZFramework
{
    public class UITimer : Singleton<UITimer> , UpdateInterface
    {
        public const int InvalidId = -1;
        private class UITimerNode
        {
            public int id { get; private set; } = 0;

            public Action<float> action { get; private set; }

            public float time { get; set; } = 0;

            public float start { get; set; } = 0;

            public float tick { get; private set; } = 0;

            public int count { get; set; } = 0;

            public bool playing = true;
            /// <summary>
            /// 是否受赞同控制
            /// </summary>
            public bool ignorePause = false;

            public UITimerNode(int _id,Action<float> _action,float _tick,int _count = 0,bool _ignorePause =false)
            {
                id = _id;
                action = _action;
                tick = _tick;
                time = Time.unscaledTime + tick;
                start = Time.unscaledTime;
                count = _count;
                ignorePause = _ignorePause;
            }
        }
        private static int UpdateIndex = 0;
        private Dictionary<int, UITimerNode> updateNodes = new Dictionary<int, UITimerNode>();
        private Dictionary<Action<float>, int> updateActions = new Dictionary<Action<float>, int>();
        private Dictionary<int, UITimerNode> addNodeDict = new Dictionary<int, UITimerNode>();
        private List<int> removeList = new List<int>();

        public bool allPause { get; set; } = false;

        public int UITimerUpdate(GObject target,Action<float> func,float tick = 0,int count =0,bool ignorePause = false)
        {
            //tick <= 0默认为update 1次
            if (tick <= 0)
                tick = 1.0f / Application.targetFrameRate;
            if (!updateActions.ContainsKey(func))
            {
                int id = ++UpdateIndex;
                addNodeDict.Add(id, new UITimerNode(id, func, tick, count, ignorePause));
                if(target != null)
                {
                    target.onDispose.Add(() => {
                        StopUITimer(id);
                    });
                }
                return id;
            }
            else
            {
                return updateActions[func];
            }
        }


        public void Pause(int id)
        {
            if (id == InvalidId) return;
            if (updateNodes.ContainsKey(id))
                updateNodes[id].playing = false;
        }

        public void Resume(int id)
        {
            if (id == InvalidId) return;
            if (updateNodes.ContainsKey(id))
                updateNodes[id].playing = true;
        }

        public int UITimerOnce(GObject target,Action<float>func,float tick = 0,bool ignorePause = false)
        {
            return UITimerUpdate(target, func, tick, 1, ignorePause);
        }


        public int StopUITimer(int id)
        {
            if (id == InvalidId) return InvalidId;
            if (addNodeDict.ContainsKey(id))
            {
                addNodeDict.Remove(id);
            }
            if (updateNodes.ContainsKey(id))
            {
                removeList.Add(id);
                if (updateActions.ContainsKey(updateNodes[id].action))
                    updateActions.Remove(updateNodes[id].action);
            }

            return InvalidId;
        }

        float time, deltaTime;
        UITimerNode tempNode;

        public void Update()
        {
            time = Time.unscaledTime;
            deltaTime = Time.unscaledDeltaTime;
            var pair = addNodeDict.GetEnumerator();
            while (pair.MoveNext())
            {
                tempNode = pair.Current.Value;
                updateActions[tempNode.action] = tempNode.id;
                updateNodes[tempNode.id] = tempNode;
            }
            addNodeDict.Clear();

            ClearRemoveAction();
            var pair2 = updateNodes.GetEnumerator();
            while (pair2.MoveNext())
            {
                tempNode = pair2.Current.Value;
                if (allPause && !tempNode.ignorePause)
                    continue;
                if (tempNode.playing)
                {
                    if (tempNode.time <= time)
                    {
                        tempNode.action(time - tempNode.start);
                        tempNode.time += tempNode.tick;

                        if (tempNode.count > 0)
                        {
                            if (tempNode.count == 1)
                                removeList.Add(tempNode.id);
                            else
                                tempNode.count -= 1;
                        }
                    }
                }
                else
                    tempNode.time += deltaTime;
            }
            ClearRemoveAction();
        }

        private void ClearRemoveAction()
        {
            for (int i = 0; i < removeList.Count; i++)
            {
                var id = removeList[i];
                if (updateNodes.ContainsKey(id))
                {
                    updateActions.Remove(updateNodes[id].action);
                    updateNodes.Remove(id);
                }
            }
            removeList.Clear();
        }
    }
}