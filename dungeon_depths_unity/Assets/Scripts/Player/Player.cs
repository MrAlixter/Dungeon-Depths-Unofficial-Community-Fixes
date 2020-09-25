using Assets.Scripts;
using Scripts;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

[Serializable]
[Savable]
//Make an IPlayer class and add player to Master.masters
public sealed class Player : MonoBehaviour, ICombatant, IPlayable, IEquipmentMaster
{
    public static Player instance { get; private set; }
    public static PlayerInput player_input { get; private set; }
    public static EventSystem event_system { get; private set; }
    public static InputSystemUIInputModule ui_input { get; private set; }
    public static UserInput input { get; private set; }

    public enum SEX { MALE, FEMALE }

    private Master master;
    //private ICombatantMaster combatantMaster; //TODO
    private ITurnMaster turn_master;
    private IProfilePictureMaster profile_picture_master;
    private Inventory inventory;
    private IModalMaster modal_master;
    private ICameraMaster camera_master;
    private IPlayerHealthMaster player_health_master;

    [Savable]
    public float MAX_SPEED;
    //Since Unity's built in numbers are floats, I won't get the precision I want
    //So I manually track it as well
    [Savable]
    public Vector2Int position;

    [Savable]
    public string player_name = "Alex the Tester";

    [Savable]
    [SerializeField]
    public SerializableColor hair_color;
    [Savable]
    [SerializeField]
    public SerializableColor skin_color;

    [Savable]
    public SEX sex { get; set; }

    #region Stats
    //Instead of using the ones defined in Combatant, 
    // I have to define here because C# doesn't support multiple inheritance

    //These are the base (real) stats
    [Savable]
    private int _HP { get; set; }
    [Savable]
    private int _MAX_HP { get; set; }
    [Savable]
    private int _MANA { get; set; }
    [Savable]
    private int _MAX_MANA { get; set; }
    [Savable]
    private int _HUNGER { get; set; }
    [Savable]
    private int _MAX_HUNGER { get; set; }
    [Savable]
    private int _ATK { get; set; }
    [Savable]
    private int _DEF { get; set; }
    [Savable]
    private int _WIL { get; set; }
    [Savable]
    private int _SPD { get; set; }

    [Savable]
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
    
    [Savable]
    internal int _breast_size;
    [Savable]
    public int breast_size
    {
        get { return _breast_size; }
        private set { _breast_size = value; }
    }
    #endregion

    [Savable]
    public List<Spell> spells { get; set; }
    [Savable]
    public List<Special> specials { get; set; }


    private int xDir;
    private int yDir;
    private float xLeft;
    private float yLeft;

    public float VIEW_MAX = 3;

    
    public void load()
    {
        Savable.load(this);
        finish_loading(true);
    }
    public void finish_loading(bool loading = false)
    {
        //Use set data to reset things
        if(loading)
        {
            transform.position = new Vector3(position.x, position.y);
            change_skin_color(skin_color);
            change_skin_color(hair_color);
            inventory.load();
        }
        else
        {
            position = new Vector2Int((int)Mathf.Round(transform.position.x), (int)Mathf.Round(transform.position.y));
            change_skin_color(SkinGradient.colors[0]);
            change_hair_color(Color.white);
            inventory.load_default_values();
        }

        profile_picture_master.regenerate_profile_picture();
    }

    void Awake()
    {
        instance = this;
        player_input = GetComponent<PlayerInput>();
        event_system = GetComponent<EventSystem>();
        ui_input = GetComponent<InputSystemUIInputModule>();
        input = new UserInput();

        //Pre-loading preparations including default values
        xDir = 0;
        yDir = 0;
        //can_move = true;

        _MAX_HP = 100;
        _HP = _MAX_HP;
        _ATK = 15;
        _DEF = 15;
        _MAX_MANA = 10;
        _MANA = _MAX_MANA;
        _MAX_HUNGER = 100;
        _HUNGER = 0;
        _WIL = 10;
        _SPD = 15;

        breast_size = 1;


        spells = new List<Spell>();
        spells.Add(new Fireball());
        spells.Add(new Heal());
        spells.Add(new IcicleSpear());

        specials = new List<Special>();
        specials.Add(new BerserkerRage());

        equipped_armor_id = GoldArmor.instance.id;
    }
    void Start()
    {
        master = Master.instance;
        turn_master = Master.get_master<ITurnMaster>();
        profile_picture_master = Master.get_master<IProfilePictureMaster>();
        modal_master = Master.get_master<IModalMaster>();
        camera_master = Master.get_master<ICameraMaster>();

        inventory = Inventory.instance;

        input.Player.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }

    public void Move(Vector2 direction)
    {
        xDir = (int)direction.normalized.x;
        yDir = (int)direction.normalized.y;
        int newX = position.x + xDir;
        int newY = position.y + yDir;
        if(master.freeSpot(newX, newY))
        {
            xLeft = xDir;
            yLeft = yDir;
            position.x += (int)xLeft; //xLeft and yLeft SHOULD ALWAYS BE WHOLE AT THIS POINT
            position.y += (int)yLeft;
            master.clearFogAroundSpot(position, VIEW_MAX);
            if(xLeft != 0)
            {
            Tweener.TweenInTime(transform, "position.x", position.x, 0.1f);
            }
            if(yLeft != 0)
            {
            Tweener.TweenInTime(transform, "position.y", position.y, 0.1f);
            }
            camera_master.move_to_position(position);
            //can_move = false;

            if(!master.random_encounter())
            {
                turn_master.next();
            }
        }
        else
        {
            turn_master.next();
        }
    }
    
    #region Combat
    public void take_damage(int dmg) { HP -= dmg; }

    public void die()
    {
        //TODO Player death
        //if (combatantMaster != null) //In combat
        //{

        //}
        //else
        //{

        //}
    }

    public void heal(int amt)
    {
        HP += amt;
        if(HP > MAX_HP) { HP = MAX_HP; }
        player_health_master.update_health_bar();
    }
    public void decrease_mana(int cost)
    {
        MANA -= cost;
        player_health_master.update_mana_bar();
    }
    public void add_hunger(int hunger)
    {
        HUNGER += hunger;
        player_health_master.update_hunger_bar();
    }

    public List<Spell> getSpells() { return spells; }
    public List<Special> getSpecials() { return specials; }
    #endregion

    public void set_position(Vector2Int p)
    {
        position = p;
        gameObject.transform.position = new Vector3(p.x, p.y, 0);
    }

    public void equip_armor(int id)
    {
        equip_armor(id, false);
    }

    public void equip_armor(int id, bool unequip_if_same)
    {
        if(equipped_armor_id == id)
        {
            equipped_armor_id = -1;
        }
        else if(inventory.get_armor_by_id(id).supports_size(breast_size))
        {
            equipped_armor_id = id;
        }
        profile_picture_master.update_armor();
        if(modal_master.is_modal_open(MODAL.EQUIPMENT))
        {
            ((IEquipmentModal)modal_master.get_instance(MODAL.EQUIPMENT)).equip_armor(id);
        }
    }

    public void change_breast_size(int change)
    {
        breast_size += change;
        if(breast_size < -1) { breast_size = -1; }
        if (breast_size > 7) { breast_size = 7; }
        profile_picture_master.update_body();
        profile_picture_master.update_armor();
    }

    public void change_skin_color(Color color)
    {
        skin_color = color;
        profile_picture_master.update_skin_color();
    }

    public void change_hair_color(Color color)
    {
        hair_color = color;
        profile_picture_master.update_hair_color();
    }
}