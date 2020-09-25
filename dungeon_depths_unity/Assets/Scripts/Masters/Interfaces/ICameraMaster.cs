using UnityEngine;

public interface ICameraMaster
{
    GameObject get_world_camera();
    GameObject get_ui_camera();
    void attach();
    void move_to_position(Vector2 pos);
}
