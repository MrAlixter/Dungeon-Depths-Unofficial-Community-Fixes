using Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthMaster : IPlayerHealthMaster
{
    private static PlayerHealthMaster _instance;
    public static PlayerHealthMaster instance { get { if(_instance != null) { return _instance; } else { _instance = new PlayerHealthMaster(); return _instance; } } }

    public static PlayerHealthMaster init(IModalMaster modalMaster, StatBar stats_bar, Player player)
    {
        instance.stats_bar = stats_bar;
        instance.player = player;
        instance.modal_master = modalMaster;
        instance.update_all_bars();
        return instance;
    }

    [SerializeField]
    private StatBar stats_bar;
    [SerializeField]
    private Player player;
    [SerializeField]
    private IModalMaster modal_master;

    public void update_health_bar()
    {
        stats_bar.Awake();
        stats_bar.set_health(player.HP, player.MAX_HP);

        if(modal_master.is_in_combat)
        {
            modal_master.update_battle_bars();
        }
    }

    public void update_mana_bar()
    {
        stats_bar.Awake();
        stats_bar.set_mana(player.MANA, player.MAX_MANA);

        if(modal_master.is_in_combat)
        {
            modal_master.update_battle_bars();
        }
    }

    public void update_hunger_bar()
    {
        stats_bar.Awake();
        stats_bar.set_hunger(player.HUNGER, player.MAX_HUNGER);

        if(modal_master.is_in_combat)
        {
            modal_master.update_battle_bars();
        }
    }

    public void update_all_bars()
    {
        update_health_bar();
        update_mana_bar();
        update_hunger_bar();
        

        if(modal_master.is_in_combat)
        {
            modal_master.update_battle_bars();
            //battle_menu.update_enemy_health(enemy.HP, enemy.MAX_HP); //TODO?
        }
    }
}
