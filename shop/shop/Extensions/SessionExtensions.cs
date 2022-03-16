using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop.Extensions
{
    public static class SessionExtensions
    {
        public static void SetJson<T>(this ISession session,string key, T instance)
        {
            var serialized = JsonConvert.SerializeObject(instance);
            session.SetString(key, serialized);
        }

        //public static string NextWord(this Random random, params string[] words)
        //{
        //    return words[random.Next(0, words.Length)];
        //}

        public static T GetJson<T>(this ISession session,string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);
            
        } 
    }
}
