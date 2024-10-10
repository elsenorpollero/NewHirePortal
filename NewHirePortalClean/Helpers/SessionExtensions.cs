﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace NewHirePortalClean.Helpers
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            var stringValue = JsonConvert.SerializeObject(value);
            session.SetString(key, stringValue);
        }

        public static T Get<T>(this ISession session, string key)
        {
            var stringValue = session.GetString(key);
            return stringValue == null ? default : JsonConvert.DeserializeObject<T>(stringValue);
        }
    }
}
