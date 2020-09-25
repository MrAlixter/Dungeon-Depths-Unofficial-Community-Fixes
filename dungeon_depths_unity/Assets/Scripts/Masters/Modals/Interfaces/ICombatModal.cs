using Scripts;
using System.Collections.Generic;

public interface ICombatModal
{
    void init(List<IPlayable> allies, List<ICombatant> enemies);
    void update_player_bars();
    void display_message(string message);
    void set_message(string message);
    void set_turn_text(string turn_text);
    void set_turn_percent(float percent);
    void set_combatant_turn(ICombatant current_combat);
    void updateATBs(Dictionary<ICombatant, float> ATB_amounts);
    void update_combatant_bars(ICombatant to_update);
    void update_single_ATB(ICombatant combatant, float amount);
    void remove_combatant(ICombatant combatant);
}
