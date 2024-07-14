﻿using System;
using System.Collections.Generic;

namespace MornLib.Pools
{
    public sealed class MornObjectPool<T>
    {
        private readonly Func<T> _onGenerate;
        private readonly Action<T> _onRent;
        private readonly Action<T> _onReturn;
        private readonly Queue<T> _poolStack = new();

        public MornObjectPool(Func<T> onGenerate, Action<T> onRent, Action<T> onReturn, int startCount)
        {
            if (startCount < 0) throw new ArgumentOutOfRangeException();

            _onGenerate = onGenerate;
            _onRent = onRent;
            _onReturn = onReturn;
            for (var i = 0; i < startCount; i++)
            {
                var generated = onGenerate();
                onReturn(generated);
                _poolStack.Enqueue(generated);
            }
        }

        public T Rent()
        {
            if (_poolStack.TryDequeue(out var result) == false) result = _onGenerate();

            _onRent(result);
            return result;
        }

        public void Return(T pushObject)
        {
            _onReturn(pushObject);
            _poolStack.Enqueue(pushObject);
        }
    }
}