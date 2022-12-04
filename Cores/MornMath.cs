﻿using System;
using UnityEngine;

namespace MornLib.Cores
{
    public static class MornMath
    {
        public static T MaxBy<T>(T a, T b, Func<T, int> func)
        {
            return func(a) > func(b) ? a : b;
        }

        public static T MinBy<T>(T a, T b, Func<T, int> func)
        {
            return func(a) < func(b) ? a : b;
        }

        public static float LerpRadian(float a, float b, float t)
        {
            return Mathf.LerpAngle(a * Mathf.Rad2Deg, b * Mathf.Rad2Deg, t) * Mathf.Deg2Rad;
        }

        public static bool IsNearZero(float a)
        {
            return Mathf.Abs(a) <= 0.0001f;
        }

        public static float ClampMinus1Plus1(float value)
        {
            return Mathf.Clamp(value, -1, 1);
        }

        public static int ClampMinus1Plus1(int value)
        {
            return Mathf.Clamp(value, -1, 1);
        }
    }
}
