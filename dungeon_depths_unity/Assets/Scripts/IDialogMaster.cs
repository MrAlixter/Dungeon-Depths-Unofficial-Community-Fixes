using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    [Serializable]
    public enum MENU { none, battle, info, pause, character, equipment, items };

    public interface IDialogMaster
    {
        void end_battle();
        void switch_dialog(MENU menu);
    }
}
