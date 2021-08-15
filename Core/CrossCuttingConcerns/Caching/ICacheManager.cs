using System;

namespace Core.CrossCuttingConcerns.Caching
{
    interface ICacheManager
    {
        void Add(string key, object value, int duration);
        void Remove(string key);
        void RemoveByPattern(string pattern);
        T Get<T>(string key);
        bool IsAdd(string key);

    }
}
