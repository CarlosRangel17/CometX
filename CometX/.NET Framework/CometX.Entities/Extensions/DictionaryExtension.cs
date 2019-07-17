using System;
using System.Linq;
using System.Collections.Generic;

namespace CometX.Entities.Extensions
{
    public static class DictionaryExtension
    {
        public static void AddRange<T>(this ICollection<T> target, IEnumerable<T> source)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (source == null) throw new ArgumentNullException(nameof(source));
            foreach (var element in source) target.Add(element);
        }

        public static Dictionary<T, string> GetEnumDictionary<T>()
        {
            var returnDictionary = Enum.GetValues(typeof(T))
                .Cast<T>().ToDictionary(at => at, at => ((Enum)Enum.Parse(typeof(T), at.ToString())).ToDescription());
            return returnDictionary;
        }

        public static Dictionary<string, string> GetEnumStringKeyDictionary<T>()
        {
            var returnDictionary = Enum.GetValues(typeof(T)).Cast<T>().ToDictionary(at => at.ToString(), at => ((Enum)Enum.Parse(typeof(T), at.ToString())).ToDescription());
            return returnDictionary;
        }
    }
}
