using Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickAdder_EquipmentButton : MonoBehaviour
{
    void Awake()
    {
        //Since I can't get Unity to let me do this via the editor, 
        //I'm being forced to make skeleton classes to initialize the OnClick
        //of these buttons to be able to have them use ModalMaster.switch_modal()
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => 
            ModalMaster.instance.switch_modal(MODAL.equipment));
    }
}
