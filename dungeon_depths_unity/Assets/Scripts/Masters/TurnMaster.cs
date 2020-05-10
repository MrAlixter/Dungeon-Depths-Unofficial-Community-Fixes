using UnityEngine;

public class TurnMaster : ITurnMaster
{
    private static TurnMaster _instance;
    public static TurnMaster instance { get { if(_instance != null) { return _instance; } else { _instance = new TurnMaster(); return _instance; } } }

    public static TurnMaster init(int turn_count)//, bool player_turn, bool in_combat = false)
    {
        instance.turn_number = turn_count;
        //instance.player_turn = player_turn;


        return instance;
    }

    [SerializeField]
    public int turn_number { get; private set; }
    //[SerializeField]
    //public bool player_turn { get; private set; }
    //private bool _in_battle { get; set; }
    //[SerializeField]
    //public bool in_battle
    //{
    //    get { return _in_battle; }
    //    set
    //    {
    //        if(_in_battle)
    //        {
    //            if(!value)
    //            {
    //                player_turn = true;
    //            }
    //            _in_battle = value;
    //        }
    //    }
    //}

    public bool next()
    {
        //if(in_battle)
        //{
        //    player_turn = !player_turn;
        //}
        //else { player_turn = true; }

        //if(player_turn) { turn_count++; }
        //Debug.Log(player_turn);
        turn_number++;
        //return player_turn;
        return true;
    }
}
