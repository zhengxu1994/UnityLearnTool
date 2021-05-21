using System;
using UnityEngine;
using System.Collections.Generic;
namespace ZFramework
{
    public enum UpdateLogic
    {
        Timer,
        UI,
        Scene,
    }

    public interface UpdateInterface
    {
        void Update();
    }


    public class GameMain : MonSingleton<GameMain>
    {
        public Dictionary<UpdateLogic,UpdateInterface> updateDic;

        public bool pause = false;

        private void Awake()
        {
            updateDic = new Dictionary<UpdateLogic, UpdateInterface>();
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            if(!pause)
            {
                foreach (var action in updateDic)
                {
                    action.Value.Update();
                }
            }
        }

        public void RegistUpdateAction(UpdateInterface action, UpdateLogic logicType)
        {
            if (updateDic.ContainsKey(logicType)) return;
            updateDic.Add(logicType,action);
        }

        public void RemoveUpdateAction(UpdateLogic logicType)
        {
            if (!updateDic.ContainsKey(logicType)) return;
            updateDic.Remove(logicType);
        }
    }
}
