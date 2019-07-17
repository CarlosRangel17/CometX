using System;
using System.Linq;
using System.Collections.Generic;
using CometX.Entities.GenericEntity;

namespace CometX.Entities.Extensions
{
    public static class LexiconExtension
    {
        public static T GetValueByKey<T>(this List<Lexicon> list, string key) where T : new()
        {
            var value = list.First(x => x.Key.Equals(key)).Value;
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public static string GetStringValueByKey(this List<Lexicon> list, string key)
        {
            var value = list.First(x => x.Key.Equals(key)).Value;
            return value.ToString();
        }
    }
}
