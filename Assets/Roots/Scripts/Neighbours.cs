using System;
using UnityEngine;

namespace Roots
{
    public static class Neighbours
    {
        public static KeyCode[] For(KeyCode kc)
        {
            switch (kc)
            {
                case KeyCode.Alpha1: return new[] { KeyCode.Alpha2, KeyCode.Q };
                case KeyCode.Alpha2: return new[] { KeyCode.Alpha1, KeyCode.Alpha3, KeyCode.Q, KeyCode.W };
                case KeyCode.Alpha3: return new[] { KeyCode.Alpha2, KeyCode.Alpha4, KeyCode.W, KeyCode.E };
                case KeyCode.Alpha4: return new[] { KeyCode.Alpha3, KeyCode.Alpha5, KeyCode.E, KeyCode.R };
                case KeyCode.Alpha5: return new[] { KeyCode.Alpha4, KeyCode.Alpha6, KeyCode.R, KeyCode.T };
                case KeyCode.Alpha6: return new[] { KeyCode.Alpha5, KeyCode.Alpha7, KeyCode.T, KeyCode.Y };
                case KeyCode.Alpha7: return new[] { KeyCode.Alpha6, KeyCode.Alpha8, KeyCode.Y, KeyCode.U };
                case KeyCode.Alpha8: return new[] { KeyCode.Alpha7, KeyCode.Alpha9, KeyCode.U, KeyCode.I };
                case KeyCode.Alpha9: return new[] { KeyCode.Alpha8, KeyCode.Alpha0, KeyCode.I, KeyCode.O };
                case KeyCode.Alpha0: return new[] { KeyCode.Alpha9, KeyCode.Alpha8, KeyCode.O, KeyCode.P };
                case KeyCode.Q: return new[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.W, KeyCode.A };
                case KeyCode.W:
                    return new[] { KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Q, KeyCode.E, KeyCode.A, KeyCode.S };
                case KeyCode.E:
                    return new[] { KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.W, KeyCode.R, KeyCode.S, KeyCode.D };
                case KeyCode.R:
                    return new[] { KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.E, KeyCode.T, KeyCode.D, KeyCode.F };
                case KeyCode.T:
                    return new[] { KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.R, KeyCode.Y, KeyCode.F, KeyCode.G };
                case KeyCode.Y:
                    return new[] { KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.T, KeyCode.U, KeyCode.G, KeyCode.H };
                case KeyCode.U:
                    return new[] { KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Y, KeyCode.I, KeyCode.H, KeyCode.J };
                case KeyCode.I:
                    return new[] { KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.U, KeyCode.O, KeyCode.J, KeyCode.K };
                case KeyCode.O:
                    return new[] { KeyCode.Alpha9, KeyCode.Alpha0, KeyCode.I, KeyCode.P, KeyCode.K, KeyCode.L };
                case KeyCode.P: return new[] { KeyCode.Alpha0, KeyCode.O, KeyCode.L };
                case KeyCode.A: return new[] { KeyCode.Q, KeyCode.W, KeyCode.S, KeyCode.Z };
                case KeyCode.S:
                    return new[] { KeyCode.W, KeyCode.E, KeyCode.A, KeyCode.D, KeyCode.Z, KeyCode.X };
                case KeyCode.D:
                    return new[] { KeyCode.E, KeyCode.R, KeyCode.S, KeyCode.F, KeyCode.X, KeyCode.C };
                case KeyCode.F:
                    return new[] { KeyCode.R, KeyCode.T, KeyCode.D, KeyCode.G, KeyCode.C, KeyCode.V };
                case KeyCode.G:
                    return new[] { KeyCode.T, KeyCode.Y, KeyCode.F, KeyCode.H, KeyCode.V, KeyCode.B };
                case KeyCode.H:
                    return new[] { KeyCode.Y, KeyCode.U, KeyCode.G, KeyCode.J, KeyCode.B, KeyCode.N };
                case KeyCode.J:
                    return new[] { KeyCode.U, KeyCode.I, KeyCode.H, KeyCode.K, KeyCode.N, KeyCode.M };
                case KeyCode.K: return new[] { KeyCode.I, KeyCode.O, KeyCode.J, KeyCode.L, KeyCode.M };
                case KeyCode.L: return new[] { KeyCode.O, KeyCode.P, KeyCode.K };
                case KeyCode.Z: return new[] { KeyCode.A, KeyCode.S, KeyCode.X };
                case KeyCode.X: return new[] { KeyCode.S, KeyCode.D, KeyCode.Z, KeyCode.C };
                case KeyCode.C: return new[] { KeyCode.D, KeyCode.F, KeyCode.X, KeyCode.V };
                case KeyCode.V: return new[] { KeyCode.F, KeyCode.G, KeyCode.C, KeyCode.B };
                case KeyCode.B: return new[] { KeyCode.G, KeyCode.H, KeyCode.V, KeyCode.N };
                case KeyCode.N: return new[] { KeyCode.H, KeyCode.J, KeyCode.B, KeyCode.M };
                case KeyCode.M: return new[] { KeyCode.J, KeyCode.K, KeyCode.N };
            }

            return Array.Empty<KeyCode>();
        }
    }
}