using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BattleMenu : Menu
{
    private static BattleMenu _instance;
    public static BattleMenu instance { get { return _instance != null ? _instance : new BattleMenu(); } }
    
    //Since Awake() is only called when the object is active, but the menus
    //are inactive at the start, I need to use their constructor instead
    public BattleMenu()
    {
        if (_instance != null && _instance != this) { Destroy(this.gameObject); }
        else { _instance = this; }
    }

    private static Player player;
    private static NPC target;

    private Transform main;

    private UnityEngine.UI.Text enemy_name_text;
    private StatBar enemy_health_bar;
    private UnityEngine.UI.Text player_name_text;
    private StatBar player_health_bar;

    private UnityEngine.UI.Text turn_text;

    private UnityEngine.UI.InputField battle_information_text;
    private UnityEngine.UI.Scrollbar battle_information_scrollbar;

    private UnityEngine.UI.Button attack_button;
    private UnityEngine.UI.Button run_button;
    private UnityEngine.UI.Button wait_button;
    private HoverMenu magic_dropdown;
    private HoverMenu special_dropdown;

    private UnityEngine.UI.Text player_stat_text;
    private UnityEngine.UI.Text enemy_stat_text;

    public new void Awake()
    {
        base.Awake();

        player = Player.instance;

        main = panel.Find("MainBody");
        GameObject enemy_info = main.Find("Enemy Info").gameObject;
        enemy_name_text = enemy_info.transform.Find("Enemy Name").GetComponent<UnityEngine.UI.Text>();
        enemy_health_bar = enemy_info.transform.Find("Panel").GetComponent<StatBar>();
        enemy_health_bar.Awake();

        GameObject player_info = main.Find("Player Info").gameObject;
        player_name_text = player_info.transform.Find("Player Name").GetComponent<UnityEngine.UI.Text>();
        player_health_bar = player_info.transform.Find("Panel").GetComponent<StatBar>();
        player_health_bar.Awake();

        turn_text = main.Find("Turn Text").GetComponent<UnityEngine.UI.Text>();

        GameObject battle_info_text_container = main.Find("Text Area").Find("TextContainer").gameObject;
        battle_information_text = battle_info_text_container.transform.Find("InputField").GetComponent<InputField>();
        battle_information_scrollbar = battle_info_text_container.transform.Find("Scrollbar").GetComponent<Scrollbar>();

        Transform buttons = main.transform.Find("Buttons");
        attack_button = buttons.Find("Attack Button").gameObject.GetComponent<Button>();
        run_button = buttons.Find("Run Button").gameObject.GetComponent<Button>();
        wait_button = buttons.Find("Wait Button").gameObject.GetComponent<Button>();
        magic_dropdown = buttons.Find("Magic Dropdown").gameObject.GetComponent<HoverMenu>();
        special_dropdown = buttons.Find("Special Dropdown").gameObject.GetComponent<HoverMenu>();

        //magic_dropdown.choices = player.spells.ToArray();
        //special_dropdown.choices = player.specials.ToArray();

        GameObject playerStats = panel.transform.Find("Player Stats").gameObject;
        player_stat_text = playerStats.transform.Find("Stat Text").GetComponent<UnityEngine.UI.Text>();
        GameObject enemyStats = panel.transform.Find("Enemy Stats").gameObject;
        enemy_stat_text = enemyStats.transform.Find("Stat Text").GetComponent<UnityEngine.UI.Text>();
        update_player_stats();
    }

    protected override void SetDefault()
    {
        CustomEventSystem.instance.SetResetSelection(attack_button.GetComponent<Selectable>());
    }

    public override void open()
    {
        base.open();
        CustomEventSystem.instance.SetResetSelection(attack_button.GetComponent<Selectable>());
        attack_button.Select();
    }

    public void set_target(NPC t)
    {
        target = t;
        //Ability.set_target(t);
        update_enemy_stats();
    }

    public void update_turn(int turn)
    {
        turn_text.text = "Turn: " + turn.ToString();
    }

    public void update_player_health(decimal current, decimal max)
    {
        player_health_bar.set_health(current, max);
    }

    public void update_enemy_health(decimal current, decimal max)
    {
        enemy_health_bar.set_health(current, max);
    }

    public void set_player_name_text(string name)
    {
        player_name_text.text = name;
    }

    public void set_enemy_name_text(string name)
    {
        enemy_name_text.text = name;
    }

    public void set_battle_information(string text)
    {
        battle_information_text.text = text;
        battle_information_text.GetComponent<SizeUpdate>().update_size();
        battle_information_scrollbar.value = 1; //Set scrollbar to top
    }

    public void add_battle_information(string text)
    {
        set_battle_information(battle_information_text.text + "\n" + text);
    }

    public void update_stats()
    {
        update_player_stats();
        update_enemy_stats();
    }

    public void update_player_stats()
    {
        string s = "";
        s += $"HP\n{player.HP}/{player.MAX_HP}\n";
        s += "\n";
        s += $"MANA\n{player.MANA}/{player.MAX_MANA}\n";
        s += "\n";
        s += $"HUNGER\n{player.HUNGER}/{player.MAX_HUNGER}\n";
        s += "\n";
        s += $"ATK\n{player.ATK}\n";
        s += "\n";
        s += $"DEF\n{player.DEF}\n";
        s += "\n";
        s += $"WIL\n{player.WIL}\n";
        s += "\n";
        s += $"SPD\n{player.SPD}";
        player_stat_text.text = s;
    }

    public void update_enemy_stats()
    {
        string s = "";
        s += $"HP\n{target.HP}/{target.MAX_HP}\n";
        s += "\n";
        s += $"\n\n";
        s += "\n";
        s += $"\n\n";
        s += "\n";
        s += $"ATK\n{target.ATK}\n";
        s += "\n";
        s += $"DEF\n{target.DEF}\n";
        s += "\n";
        s += $"\n\n";
        s += "\n";
        s += $"SPD\n{target.SPD}";
        enemy_stat_text.text = s;
    }

    public override void close()
    {
        deselect_dropdown_items();

        base.close();
    }

    private void deselect_dropdown_items()
    {
        Navigation nav;

        nav = magic_dropdown.navigation;
        nav.mode = Navigation.Mode.None;
        magic_dropdown.navigation = nav;
        nav.mode = Navigation.Mode.Explicit;
        magic_dropdown.navigation = nav;

        nav = special_dropdown.navigation;
        nav.mode = Navigation.Mode.None;
        special_dropdown.navigation = nav;
        nav.mode = Navigation.Mode.Explicit;
        special_dropdown.navigation = nav;
    }
}