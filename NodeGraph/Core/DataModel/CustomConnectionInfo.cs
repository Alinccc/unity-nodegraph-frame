﻿using System;

namespace NodeGraph.DataModel
{
    public struct CustomConnectionInfo
    {
        public CustomConnection connection;
        public Type type;

        public CustomConnectionInfo(Type t, CustomConnection n)
        {
            connection = n;
            type = t;
        }

        public Connection CreateInstance()
        {
            if(type == null || string.IsNullOrEmpty(type.FullName))
            {
                return new Connection();
            }
            else
            {
                object o = type.Assembly.CreateInstance(type.FullName);
                return (Connection)o;
            }
        }
    }
}