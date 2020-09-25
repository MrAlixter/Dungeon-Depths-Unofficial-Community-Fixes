using Scripts;
using UnityEngine;

public class MessageMaster : ScriptableObject, IMessageMaster
{
    private static MessageMaster _instance;
    public static MessageMaster instance { get { if(_instance == null) { _instance = CreateInstance<MessageMaster>(); } return _instance; } }

    private static ICombatMaster combat_master;
    private static IModalMaster modal_master;
    
    public void Start()
    {
        combat_master = Master.get_master<ICombatMaster>();
        modal_master = Master.get_master<IModalMaster>();
    }

    public void display_message(string message)
    {
        if(modal_master.is_in_combat)
        {
            modal_master.get_interfaced_modal<ICombatModal>()?.display_message(message);
        }
        else
        {
            modal_master.try_switch_message_modal(message, false);
        }
    }

    public void set_message(string message)
    {
        if(modal_master.is_in_combat)
        {
            modal_master.get_interfaced_modal<ICombatModal>()?.set_message(message);
        }
        else
        {
            modal_master.try_switch_message_modal(message, true);
        }
    }
}
