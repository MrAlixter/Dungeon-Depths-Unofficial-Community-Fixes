public interface IEquipmentModal
{
    void equip_armor(int armor_id);
    void equip_weapon(int item_id);
    void equip_accessory(int item_id);
    void equip_armor(Armor armor);
    void equip_weapon(Item item);
    void equip_accessory(Item item);
}
