using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Player : MonoBehaviour, ICombatant
{
    private static Player _instance;
    public static Player instance { get { return _instance != null ? _instance : new Player(); } }

    public Player()
    {
        if (_instance != null && _instance != this) { Destroy(this.gameObject); }
        else { _instance = this; }
    }

    private ICombatantMaster combatantMaster;
    private Master master;
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

    static Player()
    {
        
    }

    #region Stats
    [SerializeField]
    internal int _HP;
    public int HP
    {
        get { return _HP; }
        private set { _HP = value; }
    }

    [SerializeField]
    internal int _MAX_HP;
    public int MAX_HP
    {
        get { return _MAX_HP; }
        private set { _MAX_HP = value; }
    }

    [SerializeField]
    internal int _MANA;
    public int MANA
    {
        get { return _MANA; }
        private set { _MANA = value; }
    }

    [SerializeField]
    internal int _MAX_MANA;
    public int MAX_MANA
    {
        get { return _MAX_MANA; }
        private set { _MAX_MANA = value; }
    }

    [SerializeField]
    internal int _HUNGER;
    public int HUNGER
    {
        get { return _HUNGER; }
        private set { _HUNGER = value; }
    }

    [SerializeField]
    internal int _MAX_HUNGER;
    public int MAX_HUNGER
    {
        get { return _MAX_HUNGER; }
        private set { _MAX_HUNGER = value; }
    }

    [SerializeField]
    internal int _ATK;
    public int ATK
    {
        get { return _ATK + equipped_armor.attack_boost; }
        private set { _ATK = value; }
    }

    [SerializeField]
    internal int _DEF;
    public int DEF
    {
        get { return _DEF + equipped_armor.defense_boost; }
        private set { _DEF = value; }
    }

    [SerializeField]
    internal int _WIL;
    public int WIL
    {
        get { return _WIL; }
        private set { _WIL = value; }
    }

    [SerializeField]
    internal int _SPD;
    public int SPD
    {
        get { return _SPD; }
        private set { _SPD = value; }
    }

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

    #region Equipment
    public int equipped_armor_id { get; private set; }
    public Armor equipped_armor { get { return inventory.get_armor_by_id(equipped_armor_id); } }
    #endregion

    private int xDir;
    private int yDir;
    private float xLeft;
    private float yLeft;

    public bool canMove; //Public for the debug text
    
    // Use this for initialization
    void Start ()
	{
        position = new Vector2Int((int)Mathf.Round(transform.position.x), (int)Mathf.Round(transform.position.y));
        xDir = 0;
	    yDir = 0;
        canMove = true;

	    master = Master.instance;
        combatantMaster = master;

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

        breast_size = 1;

        spells = new List<Spell>();
        spells.Add(new Fireball());
        spells.Add(new Heal());
        spells.Add(new IcicleSpear());

        specials = new List<Special>();
        specials.Add(new BerserkerRage());

        equipped_armor_id = GoldArmor.instance.id;

        change_skin_color(SkinGradient.instance.colors[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove && master.current_mode == Mode.movement)
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
                if(master.staticMap[newX, newY] == null && master.entityMap[newX, newY] == null)
                {
                    master.entityMap[position.x, position.y] = null;
                    master.entityMap[newX, newY] = this.gameObject;
                    xLeft = xDir;
                    yLeft = yDir;
                    position.x += (int)xLeft; //xLeft and yLeft SHOULD ALWAYS BE WHOLE AT THIS POINT
                    position.y += (int)yLeft;
                    moveTowards();
                    canMove = false;

                    master.random_encounter();
                }

                master.next_turn();
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
    public void attack()
    {
        combatantMaster.attack();
        combatantMaster.end_turn();
    }

    public void take_damage(int dmg)
    {
        HP -= dmg;
    }

    public void do_turn()
    {
        throw new NotImplementedException();
    }

    public void run()
    {
        combatantMaster.run();
    }

    public void wait()
    {
        combatantMaster.wait();
    }

    public void heal(int amt)
    {
        HP += amt;
        if(HP > MAX_HP) { HP = MAX_HP; }
        master.update_health_bar();
    }

    public void decrease_mana(int cost)
    {
        MANA -= cost;
    }

    public void add_hunger(int hunger)
    {
        HUNGER += hunger;
    }
    #endregion

    public void equip_armor(int id)
    {
        if(inventory.get_armor_by_id(id).supports_size(breast_size))
        {
            equipped_armor_id = id;
        }
    }

    public void change_breast_size(int change)
    {
        breast_size += change;
        if(breast_size < -1) { breast_size = -1; }
        if (breast_size > 7) { breast_size = 7; }
        master.update_body();
        master.update_armor();
    }

    public void change_skin_color(Color color)
    {
        skin_color = color;
        master.update_skin_color();
    }

    public void change_hair_color(Color color)
    {
        hair_color = color;
        master.update_hair_color();
    }
}