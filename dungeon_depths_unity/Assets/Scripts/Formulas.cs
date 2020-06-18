using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public static class Formulas
    {
        public static int calc_damage(int atk, int def)
        {
            if (atk <= 0) { return 1; }
            if (def <= 0) { return atk; }
            return (atk * atk) / (atk + def);
        }
    }
}