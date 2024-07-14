﻿using System;
using System.Collections.Generic;
using MornEnum;

namespace MornLib.Extensions
{
    public static class MornDictionaryEx
    {
        public static void Init<TEnum, T>(ref Dictionary<TEnum, T> dictionary, T value) where TEnum : Enum
        {
            if (dictionary == null) dictionary = new Dictionary<TEnum, T>();

            foreach (var type in MornEnumUtil<TEnum>.Values)
                if (dictionary.ContainsKey(type) == false)
                    dictionary.Add(type, value);
        }
    }
}