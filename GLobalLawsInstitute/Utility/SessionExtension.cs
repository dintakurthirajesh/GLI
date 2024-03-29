﻿
using MySqlX.XDevAPI;
using Newtonsoft.Json;

namespace Global.Utility
{
    public static class SessionExtension
    {
        public static void SetObjectAsJson<T>(this Session session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this Session session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) :
                                  JsonConvert.DeserializeObject<T>(value);
        }
    }
}
