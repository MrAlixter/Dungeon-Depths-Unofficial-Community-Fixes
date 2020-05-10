using Assets.Scripts;
using Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public sealed class Player : MonoBehaviour, ICombatant, IPlayable, IEquipmentMaster
{
    private static Player _instance;
    public static Player instance { get { if(_instance != null) { return _instance; } else { _instance = new Player(); return _instance; } } }

    public Player()
    {
        if (_instance != null && _instance != this) { Destroy(this.gameObject); }
        else { _instance = this; }
    }

    public static Player init()
    {
        return instance;
    }

    private Master master;
    private ICombatantMaster combatantMaster;
    private ITurnMaster turnMaster;
    private IProfilePictureMaster profilePictureMaster;
    public Controller controller;
    public Inventory inventory;

    public float MAX_SPEED;
    //Since Unity's built in numbers are floats, I won't get the precision I want
    //So I manually track it as well
    public Vector2Int position;

    public string player_name = "Alex the Tester";

    [SerializeField]
    public Color hair_color;
    [SerializeField]
    public Color skin_color;
    

    #region Stats
    //Instead of using the ones defined in Combatant, 
    // I have to define here because C# doesn't support multiple inheritance

    //These are the base (real) stats
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

    [SerializeField]
    internal int _breast_size;
    public int breast_size
    {
        get { return _breast_size; }
        private set { _breast_size = value; }
    }
    #endregion

    public List<Spell> spells { get; private set; }
    public List<Special> specials { get; private set; }

    private int xDir;
    private int yDir;
    private float xLeft;
    private float yLeft;

    public bool canMove; //Public for the debug text
    

    public void Awake()
    //public void Start ()
	{
        position = new Vector2Int((int)Mathf.Round(transform.position.x), (int)Mathf.Round(transform.position.y));
        xDir = 0;
	    yDir = 0;
        canMove = true;

	    master = Master.instance;
        turnMaster = TurnMaster.instance;
        profilePictureMaster = ProfilePicture.instance;

        master.entityMap[position.x, position.y] = this.gameObject;

        controller = Controller.instance;

        inventory = Inventory.instance;
        
        MAX_HP = 100;
        HP = MAX_HP;
        ATK = 15;
        DEF = 15;
        MAX_MANA = 10;
        MANA = MAX_MANA;
        MAX_HUNGER = 100;
        HUNGER = 0;
        WIL = 10;
        SPD = 15;

        breast_size = 1;

        spells = new List<Spell>();
        spells.Add(new Fireball());
        spells.Add(new Heal());
        spells.Add(new IcicleSpear());

        specials = new List<Special>();
        specials.Add(new BerserkerRage());

        equipped_armor_id = GoldArmor.instance.id;

        change_skin_color(SkinGradient.instance.colors[0]);

        change_hair_color(Color.white);

        profilePictureMaster.regenerate_profile_picture();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove && ModalMaster.instance.current_mode == MODE.movement) //TODO
        {
            xDir = 0;
            yDir = 0;
            if (controller.moveU.down) { yDir = 1; }
            else if (controller.moveR.down) { xDir = 1; }
            else if (controller.moveD.down) { yDir = -1; }
            else if (controller.moveL.down) { xDir = -1; }

            //Only move if the player isn't already
            if(xDir != 0 || yDir != 0)
            {
                int newX = position.x + xDir;
                int newY = position.y + yDir;
                if(master.freeSpot(newX, newY))
                {
                    master.entityMap[position.x, position.y] = null;
                    master.entityMap[newX, newY] = this.gameObject;
                    xLeft = xDir;
                    yLeft = yDir;
                    position.x += (int)xLeft; //xLeft and yLeft SHOULD ALWAYS BE WHOLE AT THIS POINT
                    position.y += (int)yLeft;
                    moveTowards();
                    canMove = false;
                    
                    if(!master.random_encounter())
                    {
                        turnMaster.next();
                    }
                }
                else
                {
                    turnMaster.next();
                }
            }
        }
        else if(xLeft != 0 || yLeft != 0)
        {
            moveTowards();
        }
        else
        {
            canMove = true;
        }
    }

    void moveTowards()
    {
        float xMove = Mathf.Min(MAX_SPEED * Time.deltaTime, Mathf.Abs(xLeft)) * Mathf.Sign(xLeft);
        float yMove = Mathf.Min(MAX_SPEED * Time.deltaTime, Mathf.Abs(yLeft)) * Mathf.Sign(yLeft);
        xLeft -= xMove;
        yLeft -= yMove;
        if(xLeft == 0 && yLeft == 0)
        {
            transform.position = new Vector3(position.x, position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x + xMove, transform.position.y + yMove);
        }
    }

    #region Combat
    public void take_damage(int dmg) { HP -= dmg; }

    public void die()
    {
        //TODO Player death
        if (combatantMaster != null) //In combat
        {

        }
        else
        {

        }
    }

    public void heal(int amt)
    {
        HP += amt;
        if(HP > MAX_HP) { HP = MAX_HP; }
        ////////////master.update_health_bar(); //TODO
    }

    public void decrease_mana(int cost)
    {
        MANA -= cost;
        ////////////master.update_mana_bar(); //TODO
    }

    public void add_hunger(int hunger)
    {
        HUNGER += hunger;
        //////////////master.update_hunger_bar(); //TODO
    }

    public List<Spell> getSpells() { return spells; }

    public List<Special> getSpecials() { return specials; }
    #endregion

    public void setPosition(Vector2Int p)
    {
        position = p;
        gameObject.transform.position = new Vector3(p.x, p.y, 0);
    }

    public void equip_armor(int id)
    {
        if(inventory.get_armor_by_id(id).supports_size(breast_size))
        {
            equipped_armor_id = id;
        }
        profilePictureMaster.update_armor();
    }

    public void change_breast_size(int change)
    {
        breast_size += change;
        if(breast_size < -1) { breast_size = -1; }
        if (breast_size > 7) { breast_size = 7; }
        profilePictureMaster.update_body();
        profilePictureMaster.update_armor();
    }

    public void change_skin_color(Color color)
    {
        skin_color = color;
        profilePictureMaster.update_skin_color();
    }

    public void change_hair_color(Color color)
    {
        hair_color = color;
        profilePictureMaster.update_hair_color();
    }
}