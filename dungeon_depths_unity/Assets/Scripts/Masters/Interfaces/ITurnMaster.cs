public interface ITurnMaster
{
    int turn_number { get; }
    //bool player_turn { get; }
    //bool in_battle { get; set; }

    bool next();
}
