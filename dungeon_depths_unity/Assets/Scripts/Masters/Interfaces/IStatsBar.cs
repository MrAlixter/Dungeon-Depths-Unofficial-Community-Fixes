public interface IStatsBar
{
    void set_health(decimal current, decimal max);
    void set_mana(decimal current, decimal max);
    void set_hunger(decimal current, decimal max);
}
