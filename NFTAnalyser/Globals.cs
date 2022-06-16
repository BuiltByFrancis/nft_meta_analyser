using System;
using System.Collections.Generic;

namespace NFTAnalyser
{
    public static class Globals
    {
        private static readonly Dictionary<Type, object> ioc = new();

        public static T Get<T>()
        {
            Type t = typeof(T);
            return ioc.ContainsKey(t) ? (T)ioc[t] : throw new ArgumentException("We aint got no " + t);
        }

        public static void Store<T>(T instance)
        {
            ioc[typeof(T)] = instance ?? throw new ArgumentNullException(nameof(instance));
        }
    }
}
