using System;
using UnityEngine;
using FairyGUI;
namespace ZFramework
{
    internal class RedDotNode
    {
        public string Name { get; private set; }

        public string DotStr { get; private set; }

        private bool block { get; set; } = false;

        public bool dotValue { get; protected set; } = false;

        private RedDotNode parent = null;

        private DictBox<GObject, Action<RedDotNode>> objCallbacks;

        private DictBox<string, RedDotNode> children;

        public bool IsLeaf => children is null;

        public int ChildCount => IsLeaf ? 0 : children.Count;

        public int ChildRedCount
        {
            get
            {
                int count = 0;
                children.BoxEach((k, v) => {
                    if (v.dotValue) count++;
                });
                return count;
            }
        }

        public RedDotNode(string name,string dotStr)
        {
            Name = name;
            DotStr = DotStr;
            if (DotStr.Equals("")) children = new DictBox<string, RedDotNode>();
        }

        public void SetDotValue(bool value)
        {
            if (block) return;
            if (!IsLeaf)
            {
                Debug.LogError("can not set parent node value");
                return;
            }
            if (dotValue != value)
            {
                dotValue = value;
                NotifyChange();
                NotifyParent();
            }
        }

        public void SetBlock(bool block)
        {
            this.block = block;
        }

        public void AddSubNode(RedDotNode node)
        {
            if(children == null)
            {
                children = new DictBox<string, RedDotNode>();
            }
            if (!children.ContainKey(node.Name))
            {
                children.Add(node.Name, node);
                node.parent = this;
            }
        }

        public bool Contains(string key)
        {
            return !IsLeaf ? children.ContainKey(key) : false;
        }

        public RedDotNode GetSubNode(string key)
        {
            return !IsLeaf ? children[key] : null;
        }

        private void CheckParentValue()
        {
            if (block) return;
            if (!IsLeaf)
            {
                bool newValue = false;
                var pair = children.Pairs();
                while (pair.MoveNext())
                {
                    if (pair.Current.Value.dotValue)
                    {
                        newValue = true;
                        break;
                    }
                }
                if (dotValue != newValue)
                {
                    dotValue = newValue;
                    NotifyChange();
                    NotifyParent();
                }
            }
        }

        public void NotifyChange()
        {
            if (block) return;
            objCallbacks?.BoxEach((obj, action) =>
            {
                action?.Invoke(this);
            });
        }

        public void NotifyParent()
        {
            if (parent != null && parent.dotValue != dotValue)
                parent.CheckParentValue();
        }

        public void AddListener(GObject obj,Action<RedDotNode> action)
        {
            if (objCallbacks == null) objCallbacks = new DictBox<GObject, Action<RedDotNode>>();
            if (objCallbacks.ContainKey(obj)) return;
            objCallbacks[obj] = action;
            action?.Invoke(this);
        }

        public void RemoveListener(GObject obj)
        {
            objCallbacks?.Remove(obj);
        }

        public ListBox<string> GetLeafDotStrs()
        {
            ListBox<string> dotStrs = new ListBox<string>();
            WalkLeaf((node) => { dotStrs.Add(node.DotStr); });
            return dotStrs;
        }

        private void WalkLeaf(Action<RedDotNode> walkAction)
        {
            if (IsLeaf)
                walkAction?.Invoke(this);
            else
            {
                var pair = children.Pairs();
                while (pair.MoveNext())
                {
                    if (pair.Current.Value.IsLeaf)
                    {
                        walkAction?.Invoke(pair.Current.Value);
                    }
                    else
                        pair.Current.Value.WalkLeaf(walkAction);
                }
            }
        }

        private void WalkNode(Action<RedDotNode> walkAction)
        {
            if (IsLeaf)
                walkAction?.Invoke(this);
            else
            {
                var pair = children.Pairs();
                while (pair.MoveNext())
                {
                    if (pair.Current.Value.IsLeaf)
                        walkAction?.Invoke(pair.Current.Value);
                    else
                        pair.Current.Value.WalkLeaf(walkAction);
                }
                walkAction?.Invoke(this);
            }
        }

        public virtual void CheckDotValue()
        {
            if (!IsLeaf)
            {
                bool newValue = false;
                var pair = children.Pairs();
                while (pair.MoveNext())
                {
                    pair.Current.Value.CheckDotValue();
                    if (pair.Current.Value.dotValue)
                        newValue = false;
                }
                if (dotValue != newValue)
                {
                    dotValue = newValue;
                    NotifyChange();
                }
            }
        }

        public void ClearInfo()
        {
            bool changed = false;
            WalkNode((r) => {
                if (r.dotValue)
                {
                    changed = true;
                    r.dotValue = false;
                    r.NotifyChange();
                }
            });
            if (changed)
                NotifyParent();
        }
    }
}