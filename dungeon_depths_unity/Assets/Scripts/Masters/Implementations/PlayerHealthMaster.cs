using Scripts;
using UnityEngine;

public class PlayerHealthMaster : IPlayerHealthMaster
{
    private static PlayerHealthMaster _instance;
    public static PlayerHealthMaster instance { get { if(_instance == null) { _instance = new PlayerHealthMaster(); } return _instance; } }
    
    public static PlayerHealthMaster init()
    {
        instance.stats_bar = Master.get_master<IStatsBar>();
        instance.player = Player.instance;
        instance.modal_master = Master.get_master<IModalMaster>();
        instance.update_all_bars();
        return instance;
    }
    
    private IStatsBar stats_bar;
    private Player player;
    private IModalMaster modal_master;

    public void update_health_bar()
    {
        stats_bar?.set_health(player.HP, player.MAX_HP);
        modal_master.get_interfaced_modal<ICombatModal>()?.update_player_bars();
    }
    public void update_mana_bar()
    {
        stats_bar?.set_mana(player.MANA, player.MAX_MANA);
        modal_master.get_interfaced_modal<ICombatModal>()?.update_player_bars();
    }
    public void update_hunger_bar()
    {
        stats_bar?.set_hunger(player.HUNGER, player.MAX_HUNGER);
        modal_master.get_interfaced_modal<ICombatModal>()?.update_player_bars();
    }

    public void update_all_bars()
    {
        update_health_bar();
        update_mana_bar();
        update_hunger_bar();

        modal_master.get_interfaced_modal<ICombatModal>()?.update_player_bars();
    }
}
