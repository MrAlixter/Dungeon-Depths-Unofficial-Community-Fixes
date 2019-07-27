using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICombatantMaster
{
    void attack();
    void end_turn();
    void run();
    void wait();
}

public interface ICombatant
{
    void do_turn();
    void attack();
    void take_damage(int dmg);
}
