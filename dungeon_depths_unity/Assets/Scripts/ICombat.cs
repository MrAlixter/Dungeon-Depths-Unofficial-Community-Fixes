using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//FOR BattleMenuV2 menu handling
public interface IBattleInputHandler
{
    void onBattleInputAttack(ICombatant target);
    void onBattleInputAbility(ICombatant target, Ability ability);
    bool onBattleInputRun();
    void onBattleInputWait();
}

//FOR BattleMenu 
public interface ICombatantMaster
{
    List<ICombatant> getEnemies(ICombatant forWhom);
    List<ICombatant> getAllies(ICombatant forWhom);
    void attack(ICombatant from, ICombatant to);
    void end_turn(ICombatant forWhom);
    bool run(ICombatant forWhom);
    void wait(ICombatant who);
    void die(ICombatant dead);
}

public interface ICombatant
{
    void take_damage(int dmg);
    void die();

    [SerializeField]
    string name { get; set; }

    [SerializeField]
    int HP { get; set; }
    [SerializeField]
    int MAX_HP { get; set; }
    [SerializeField]
    int MANA { get; set; }
    [SerializeField]
    int MAX_MANA { get; set; }
    [SerializeField]
    int HUNGER { get; set; }
    [SerializeField]
    int MAX_HUNGER { get; set; }
    [SerializeField]
    int ATK { get; set; }
    [SerializeField]
    int DEF { get; set; }
    [SerializeField]
    int WIL { get; set; }
    [SerializeField]
    int SPD { get; set; }
}

public interface IPlayable
{
    List<Spell> getSpells();
    List<Special> getSpecials();

    [SerializeField]
    int equipped_armor_id { get; set; }
    [SerializeField]
    Armor equipped_armor { get; }
}

public abstract class Combatant : ICombatant, IPlayable
{
    public string name { get; set; }

    public int _HP { get; set; }
    public int _MAX_HP { get; set; }
    public int _MANA { get; set; }
    public int _MAX_MANA { get; set; }
    public int _HUNGER { get; set; }
    public int _MAX_HUNGER { get; set; }
    public int _ATK { get; set; }
    public int _DEF { get; set; }
    public int _WIL { get; set; }
    public int _SPD { get; set; }

    public int equipped_armor_id { get; set; }
    public Armor equipped_armor { get { return Inventory.instance.get_armor_by_id(equipped_armor_id); } }

    public int HP { get { return _HP; } set { _HP = value; } }
    public int MAX_HP { get { return _MAX_HP + (equipped_armor == null ? 0 : equipped_armor.health_boost); } set { _MAX_HP = value; } }
    public int MANA { get { return _MANA; } set { _MANA = value; } }
    public int MAX_MANA { get { return _MAX_MANA + (equipped_armor == null ? 0 : equipped_armor.mana_boost); } set { _MAX_MANA = value; } }
    public int HUNGER { get { return _HUNGER; } set { _HUNGER = value; } }
    public int MAX_HUNGER { get { return _MAX_HUNGER; } set { _MAX_HUNGER = value; } }
    public int ATK { get { return _ATK + (equipped_armor == null ? 0 : equipped_armor.attack_boost); } set { _ATK = value; } }
    public int DEF { get { return _DEF + (equipped_armor == null ? 0 : equipped_armor.defense_boost); } set { _DEF = value; } }
    public int WIL { get { return _WIL + (equipped_armor == null ? 0 : equipped_armor.will_boost); } set { _WIL = value; } }
    public int SPD { get { return _SPD + (equipped_armor == null ? 0 : equipped_armor.speed_boost); } set { _SPD = value; } }
    
    public abstract void do_turn();
    public abstract void die();

    public void take_damage(int dmg)
    {
        HP -= dmg;
        if(HP <= 0) { die(); }
    }

    public List<Spell> getSpells()
    {
        return new List<Spell>();
    }

    public List<Special> getSpecials()
    {
        return new List<Special>();
    }
}