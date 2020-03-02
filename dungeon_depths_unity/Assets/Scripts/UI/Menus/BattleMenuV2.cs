using Assets.Scripts;
using Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BattleMenuV2 : Menu, HoverMenu.HoverMenuChoiceHandler
{
    private static BattleMenuV2 _instance;
    public static BattleMenuV2 instance { get { return _instance != null ? _instance : new BattleMenuV2(); } }

    //Since Awake() is only called when the object is active, but the menus
    //are inactive at the start, I need to use their constructor instead
    public BattleMenuV2()
    {
        if (_instance != null && _instance != this) { Destroy(this.gameObject); }
        else { _instance = this; }
    }

    [SerializeField]
    private IBattleInputHandler battleInputHandler;
    [SerializeField]
    private IPlayerHealthMaster playerHealthMaster;
    
    [SerializeField]
    private GameObject ally_entity_panel;
    [SerializeField]
    private GameObject enemy_entity_panel;
    [SerializeField]
    private GameObject dropdown_choice;

    private List<ICombatant> allies;
    private List<ICombatant> enemies;
    private Transform ally_container;
    private Transform enemy_container;

    [SerializeField]
    private ICombatant awaiting_input_from;

    private bool selecting_target;
    private bool attacked;
    private Ability used_ability;

    #region Buttons
    private Transform attack_btn_transform;
    private Button attack_btn;
    private Transform magic_dropdown_transform;
    private Button magic_btn;
    private HoverMenu magic_hover_menu;
    private Transform special_dropdown_transform;
    private Button special_btn;
    private HoverMenu special_hover_menu;
    private Transform use_item_btn_transform;
    private Button use_item_btn;
    private Transform wait_btn_transform;
    private Button wait_btn;
    private Transform run_btn_transform;
    private Button run_btn;
    #endregion

    private InputField battle_information_text;
    private Scrollbar battle_information_scrollbar;

    private List<CombatantPanel> combatantPanels;

    [SerializeField]
    private Selectable default_selectable;

    protected override void SetDefault()
    {
        if (selecting_target)
        {
            if(attacked)
            {
                //Attacking defaults to enemy
                CustomEventSystem.instance.SetResetSelection(getCombatantPanel(false, 0).selectable);
            }
            else if(used_ability != null)
            {
                //Ability default depends on ability
                if(used_ability.default_target == Ability.TARGET_TYPE.ENEMY)
                {
                    CustomEventSystem.instance.SetResetSelection(getCombatantPanel(false, 0).selectable);
                }
                else if(used_ability.default_target == Ability.TARGET_TYPE.SELF)
                {
                    CustomEventSystem.instance.SetResetSelection(getCombatantPanel(awaiting_input_from).selectable);
                }
                else if(used_ability.default_target == Ability.TARGET_TYPE.ALLY)
                {
                    CustomEventSystem.instance.SetResetSelection(getCombatantPanel(true, 0).selectable);
                }
            }
            //CustomEventSystem.instance.SetResetSelection(enemy_container.GetChild(0).GetComponent<Selectable>());
        }
        else if(awaiting_input_from != null)
        {
            CustomEventSystem.instance.SetResetSelection(default_selectable);
        }
        else
        {
            CustomEventSystem.instance.SetResetSelection(DummyButton.instance.selectable);
        }
    }

    public void init(IBattleInputHandler bih, IPlayerHealthMaster phm, List<ICombatant> allies, List<ICombatant> enemies)
    {
        battleInputHandler = bih;
        playerHealthMaster = phm;

        if(panel == null)
        {
            base.Awake();
        }
        ally_container = panel.Find("Ally Container");
        enemy_container = panel.Find("Enemy Container");

        Transform btnRoot = panel.Find("Buttons");
        attack_btn_transform = btnRoot.Find("Attack Button");
        attack_btn = attack_btn_transform.GetComponent<Button>();
        magic_dropdown_transform = btnRoot.Find("Magic Dropdown");
        magic_btn = magic_dropdown_transform.GetComponent<Button>();
        magic_hover_menu = magic_dropdown_transform.GetComponent<HoverMenu>();
        special_dropdown_transform = btnRoot.Find("Special Dropdown");
        special_btn = special_dropdown_transform.GetComponent<Button>();
        special_hover_menu = special_dropdown_transform.GetComponent<HoverMenu>();
        use_item_btn_transform = btnRoot.Find("Use Item Button");
        use_item_btn = use_item_btn_transform.GetComponent<Button>();
        wait_btn_transform = btnRoot.Find("Wait Button");
        wait_btn = wait_btn_transform.GetComponent<Button>();
        run_btn_transform = btnRoot.Find("Run Button");
        run_btn = run_btn_transform.GetComponent<Button>();

        GameObject battle_info_text_container = panel.Find("Text Area").Find("TextContainer").gameObject;
        battle_information_text = battle_info_text_container.transform.Find("InputField").GetComponent<InputField>();
        battle_information_scrollbar = battle_info_text_container.transform.Find("Scrollbar").GetComponent<Scrollbar>();

        attack_btn.onClick.AddListener(delegate { onAttackButtonClicked(); });
        run_btn.onClick.AddListener(delegate { onRunButtonClicked(); });
        wait_btn.onClick.AddListener(delegate { onWaitButtonClicked(); });

        default_selectable = attack_btn.GetComponent<Selectable>();

        purge();
        combatantPanels = new List<CombatantPanel>();
        loadAlliesAndEnemies(allies, enemies);

        selecting_target = false;
    }

    public void loadAlliesAndEnemies(List<ICombatant> allies, List<ICombatant> enemies)
    {
        this.allies = allies;
        foreach (ICombatant combatant in allies)
        {
            GameObject go = Instantiate(ally_entity_panel, ally_container);
            CombatantPanel cp = go.GetComponent<CombatantPanel>();
            go.GetComponent<Button>().onClick.AddListener(() => { onCombatantClicked(combatant); });
            cp.init(combatant);
            combatantPanels.Add(cp);
        }

        this.enemies = enemies;
        foreach (ICombatant combatant in enemies)
        {
            GameObject go = Instantiate(enemy_entity_panel, enemy_container);
            CombatantPanel cp = go.GetComponent<CombatantPanel>();
            go.GetComponent<Button>().onClick.AddListener(() => { onCombatantClicked(combatant); });
            cp.init(combatant);
            combatantPanels.Add(cp);
        }

        setDefaultCombatantNavTargets();
    }
    
    #region ATB
    public void updateATBs(Dictionary<ICombatant, float> amounts)
    {
        foreach(KeyValuePair<ICombatant, float> pair in amounts)
        {
            foreach(CombatantPanel panel in combatantPanels)
            {
                if(pair.Key.Equals(panel.combatant))
                {
                    panel.setATBAmount(pair.Value);
                    break;
                }
            }
        }
    }
    
    public void update_single_ATB(ICombatant combatant, float amount)
    {
        getCombatantPanel(combatant).setATBAmount(amount);
    }
    #endregion

    public void set_combatant_turn(ICombatant current_turn_combatant)
    {
        set_acting(current_turn_combatant);

        awaiting_input_from = current_turn_combatant;
        //This will update the default which will trigger the selecting
        SetDefault();
        
        if(awaiting_input_from != null)
        {
            setCombatantsNavTargets(true);
            
            magic_hover_menu.init(this, dropdown_choice, ((IPlayable)current_turn_combatant).getSpells().ToArray(), true);
            special_hover_menu.init(this, dropdown_choice, ((IPlayable)current_turn_combatant).getSpecials().ToArray(), true);
        }
        else
        {
            setCombatantsNavTargets(false);

            magic_hover_menu.set_can_open(false);
            special_hover_menu.set_can_open(false);
        }
    }

    public void update_combatant(ICombatant to_update)
    {
        CombatantPanel panel = getCombatantPanel(to_update);
        if (panel != null) { panel.update_stat_bars(); }
        if(to_update is Player)
        {
            playerHealthMaster.update_all_bars();
        }
        //If panel == null, it's probably because the combatant died
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

    #region Clicked
    private void onAttackButtonClicked()
    {
        if(awaiting_input_from != null)
        {
            attacked = true;
            used_ability = null;

            selecting_target = true;

            setCombatantsNavTargets(false);

            SetDefault();
        }
        else
        {
            CustomEventSystem.instance.SelectDefault();
        }
    }

    public void onHoverMenuChoiceClicked(Ability choice)
    {
        if (awaiting_input_from != null)
        {
            attacked = false;
            used_ability = choice;

            selecting_target = true;

            if (choice.possible_targets == Ability.TARGET_TYPE.SELF)
            {
                //Can only target self
                onCombatantClicked(awaiting_input_from);
            }
            else
            {
                setCombatantsNavTargets(choice.possible_targets);

                //Selects based on ability default_choice
                SetDefault();
            }
        }
        else
        {
            CustomEventSystem.instance.SelectDefault();
        }
    }

    public void onRunButtonClicked()
    {
        if(awaiting_input_from != null)
        {
            bool success = battleInputHandler.onBattleInputRun();
            if(success) { return; } //Battle has ended, don't bother with anything else

        }
    }

    private void onCombatantClicked(ICombatant clicked_combatant)
    {
        if (awaiting_input_from != null && selecting_target)
        {
            selecting_target = false;

            if(attacked) { battleInputHandler.onBattleInputAttack(clicked_combatant); }
            else if(used_ability != null) { battleInputHandler.onBattleInputAbility(clicked_combatant, used_ability); }

            setCombatantsNavTargets(true);
            
            SetDefault();
        }
        else
        {
            CustomEventSystem.instance.SelectDefault();
        }
    }

    private void onWaitButtonClicked()
    {
        battleInputHandler.onBattleInputWait();
    }
    #endregion

    #region Nav
    private void setDefaultCombatantNavTargets()
    {
        Selectable atk_btn_selectable = attack_btn.GetComponent<Selectable>();
        Navigation temp;
        Selectable previous = null;
        foreach (ICombatant combatant in allies)
        {
            CombatantPanel cp = getCombatantPanel(combatant);

            Selectable thisSelectable = cp.selectable;
            temp = cp.navigation;
            temp.selectOnRight = atk_btn_selectable;
            cp.navigation = temp;

            if (previous != null)
            {
                temp.selectOnUp = previous;
                cp.navigation = temp;

                temp = previous.navigation;
                temp.selectOnDown = thisSelectable;
                previous.navigation = temp;
            }

            previous = thisSelectable;
        }

        //Set navigation for left-most buttons to go to lowest (and thus closest) ally
        if (ally_container.childCount > 0)
        {
            Selectable last = ally_container.GetChild(ally_container.childCount - 1).GetComponent<Selectable>();

            temp = attack_btn.navigation;
            temp.selectOnLeft = last;
            attack_btn.navigation = temp;

            temp = use_item_btn.navigation;
            temp.selectOnLeft = last;
            use_item_btn.navigation = temp;
        }


        Selectable special_btn_selectable = special_btn.GetComponent<Selectable>();
        previous = null;
        foreach (ICombatant combatant in enemies)
        {
            CombatantPanel cp = getCombatantPanel(combatant);

            Selectable thisSelectable = cp.selectable;
            temp = cp.navigation;
            temp.selectOnLeft = special_btn_selectable;
            cp.navigation = temp;
            
            if (previous != null)
            {
                temp.selectOnUp = previous;
                cp.navigation = temp;

                temp = previous.navigation;
                temp.selectOnDown = thisSelectable;
                previous.navigation = temp;
            }

            cp.update_stat_bars();

            previous = thisSelectable;
        }

        //Set navigation for right-most buttons to go to lowest (and thus closest) enemy
        if (enemy_container.childCount > 0)
        {
            Selectable last = enemy_container.GetChild(enemy_container.childCount - 1).GetComponent<Selectable>();

            temp = special_btn.navigation;
            temp.selectOnRight = last;
            special_btn.navigation = temp;

            temp = run_btn.navigation;
            temp.selectOnRight = last;
            run_btn.navigation = temp;
        }
    }
    
    private void setCombatantsNavTargets(Ability.TARGET_TYPE possible)
    {
        if(possible == Ability.TARGET_TYPE.ALL)
        {
            //All, so just go with default
            setCombatantsNavTargets(true);
        }
        else if(possible == Ability.TARGET_TYPE.SELF)
        {
            getCombatantPanel(awaiting_input_from).selectable.Select();
            Debug.LogError("setCombatantsNavTargets() for type SELF, which should be handled in onHoverMenuChoiceClicked");
        }
        else if(possible == Ability.TARGET_TYPE.ALLY)
        {
            foreach(ICombatant ally in allies)
            {
                CombatantPanel cp = getCombatantPanel(ally);
                Navigation nav = cp.navigation;
                nav.selectOnRight = null;
                cp.navigation = nav;
            }
        }
        else if (possible == Ability.TARGET_TYPE.ENEMY)
        {
            foreach (ICombatant enemy in enemies)
            {
                CombatantPanel cp = getCombatantPanel(enemy);
                Navigation nav = cp.navigation;
                nav.selectOnLeft = null;
                cp.navigation = nav;
            }
        }
    }

    private void setCombatantsNavTargets(bool to_buttons)
    {
        Selectable allyTarget = null;
        Selectable enemyTarget = null;

        if (to_buttons)
        {
            allyTarget = attack_btn.GetComponent<Selectable>();
            enemyTarget = special_btn.GetComponent<Selectable>();
        }

        Button btn;
        Navigation temp;
        for(int i = 0; i < ally_container.childCount; i++)
        {
            btn = ally_container.GetChild(i).GetComponent<Button>();
            temp = btn.navigation;
            if (to_buttons) { temp.selectOnRight = allyTarget; }
            else
            {
                Selectable paired = enemy_container.GetChild(getPairedIndex(i, ally_container.childCount, enemy_container.childCount)).GetComponent<Selectable>();
                temp.selectOnRight = paired;
            }
            btn.navigation = temp;
        }
        
        for(int i = 0; i < enemy_container.childCount; i++)
        {
            btn = enemy_container.GetChild(i).GetComponent<Button>();
            temp = btn.navigation;
            if (to_buttons) { temp.selectOnLeft = enemyTarget; }
            else
            {
                Selectable paired = ally_container.GetChild(getPairedIndex(i, enemy_container.childCount, ally_container.childCount)).GetComponent<Selectable>();
                temp.selectOnLeft = paired;
            }
            btn.navigation = temp;
        }
    }
    #endregion

    public void remove_combatant(ICombatant combatant)
    {
        CombatantPanel panel = getCombatantPanel(combatant);
        combatantPanels.Remove(panel);

        if(is_ally_to_player(combatant))
        {
            //No need to remove. BattleMaster should handle this, 
            //as the list is passed by reference and it should have already removed the ally from its list
            //allies.Remove(combatant); 
            if (attack_btn.navigation.selectOnLeft == panel.selectable || 
                use_item_btn.navigation.selectOnLeft == panel.selectable)
            {
                if (allies.Count > 0)
                {
                    ICombatant newLast = allies[allies.Count - 1];
                    CombatantPanel newLastPanel = getCombatantPanel(newLast);

                    Navigation temp;

                    temp = attack_btn.navigation;
                    temp.selectOnLeft = newLastPanel.selectable;
                    attack_btn.navigation = temp;

                    temp = use_item_btn.navigation;
                    temp.selectOnLeft = newLastPanel.selectable;
                    use_item_btn.navigation = temp;
                }
            }
        }
        else
        {
            //No need to remove. BattleMaster should handle this, 
            //as the list is passed by reference and it should have already removed the enemy from its list
            //enemies.Remove(combatant); 
            if (special_btn.navigation.selectOnRight == panel.selectable ||
                run_btn.navigation.selectOnRight == panel.selectable)
            {
                if(enemies.Count > 0)
                {
                    ICombatant newLast = enemies[enemies.Count - 1];
                    CombatantPanel newLastPanel = getCombatantPanel(newLast);

                    Navigation temp;

                    temp = special_btn.navigation;
                    temp.selectOnRight = newLastPanel.selectable;
                    special_btn.navigation = temp;

                    temp = run_btn.navigation;
                    temp.selectOnRight = newLastPanel.selectable;
                    run_btn.navigation = temp;
                }
            }
        }

        Destroy(panel.gameObject);
        //foreach(Transform t in enemy_container.transform) //Iterates through children
        //{
        //    CombatantPanel cp = t.GetComponent<CombatantPanel>();
        //    if(cp != null && cp.myCombatant.Equals(combatant))
        //    {
        //        Destroy(t.gameObject);
        //        break;
        //    }
        //}
    }
    
    public void set_acting(ICombatant active)
    {
        if(awaiting_input_from != null)
        {
            getCombatantPanel(awaiting_input_from).set_acting(false);
        }
        if (active != null)
        {
            getCombatantPanel(active).set_acting(true);
        }
    }

    #region Util
    public bool is_ally_to_player(ICombatant combatant)
    {
        if (allies.Contains(combatant)) { return true; }
        if (enemies.Contains(combatant)) { return false; }
        return false;
    }

    private CombatantPanel getCombatantPanel(ICombatant combatant)
    {
        CombatantPanel ret = combatantPanels.Find(cp => cp.combatant.Equals(combatant));
        return ret;
    }

    private CombatantPanel getCombatantPanel(bool ally, int index)
    {
        if(ally)
        {
            return ally_container.GetChild(index).GetComponent<CombatantPanel>();
        }
        else
        {
            return enemy_container.GetChild(index).GetComponent<CombatantPanel>();
        }
    }

    private void purge()
    {
        purge_combatants();
        set_battle_information("");
    }

    private void purge_combatants()
    {
        allies = null;
        enemies = null;
        foreach(Transform t in ally_container)
        {
            Destroy(t.gameObject);
        }
        foreach (Transform t in enemy_container)
        {
            Destroy(t.gameObject);
        }
    }

    private int getPairedIndex(int index, int thisCount, int pairCount)
    {
        //float position;
        //float inc;
        //float fix;
        //if(thisCount == 1) { inc = 0f; fix = 0.5f; }
        //else if(thisCount == 2) { inc = 0.25f; fix = 0.25f; }
        //else if(thisCount == 3) { inc = 0.33f; fix = 0f; }
        //else if(thisCount == 4) { inc = 0.25f; fix = 0f; }
        
        if (pairCount == 1) { return 0; }

        if (thisCount == 1)
        {
            if (pairCount <= 2) { return 0; }
            else { return 1; }
        }
        else if (thisCount == 2)
        {
            if (index == 0)
            {
                if (pairCount <= 3) { return 0; }
                else { return 1; }
            }
            else
            {
                if (pairCount <= 2) { return 1; }
                else { return 2; }
            }
        }
        else if (thisCount == 3)
        {
            if (index == 0) { return 0; }
            else if (index == 1)
            {
                if (pairCount <= 2) { return 0; }
                else { return 1; }
            }
            else
            {
                if (pairCount <= 2) { return 1; }
                else { return 2; }
            }
        }
        else// if (thisCount == 4)
        {
            if (index == 0 || pairCount == 0) { return 0; }
            else if (index == 1)
            {
                if(pairCount <= 3) { return 0; }
                else { return 1; }
            }
            else if (index == 2)
            {
                if(pairCount == 1) { return 0; }
                else if(pairCount == 2) { return 1; }
                else if(pairCount == 3) { return 1; }
                else { return 2; }
            }
            else
            {
                return pairCount - 1;
            }
        }
    }
    #endregion
}