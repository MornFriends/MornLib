﻿using System;
using System.Collections.Generic;
using MornLib.Cores;
using MornLib.Pools;
using MornSingleton;
using UnityEngine;

namespace MornLib.Debugs
{
    public class MornDebugLog : MornSingleton<MornDebugLog>
    {
        private readonly Dictionary<string, MyStruct> _debugDictionary = new();

        public void AddDebug(string logType, object message)
        {
            var data = new MyStruct { Time = Time.time, Message = message };
            if (_debugDictionary.ContainsKey(logType))
                _debugDictionary[logType] = data;
            else
                _debugDictionary.Add(logType, data);
        }

        public string GetLog()
        {
            var sb = MornSharedObjectPool<MornStringBuilder>.Rent();
            sb.Init('\n');
            foreach (var pair in _debugDictionary)
                sb.Append($"{pair.Key,20} | {pair.Value.Message} | {pair.Value.Time,20}");

            var result = sb.Get();
            MornSharedObjectPool<MornStringBuilder>.Return(sb);
            return result;
        }

        protected override void Instanced()
        {
        }

        [Serializable]
        private struct MyStruct
        {
            public float Time;
            public object Message;
        }
    }
}