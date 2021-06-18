﻿namespace ZFramework
{
    public class NetKcpComponent: Entity
    {
        public AService Service;
        
        public IMessageDispatcher MessageDispatcher { get; set; }
    }
}