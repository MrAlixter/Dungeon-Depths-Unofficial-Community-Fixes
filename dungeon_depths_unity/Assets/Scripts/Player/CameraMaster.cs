using Scripts;
using UnityEngine;

public class CameraMaster : MonoBehaviour, ICameraMaster
{
    public static CameraMaster instance { get; private set; }

    private static IModalMaster modal_master;
    private static float FOLLOW_TIME = 0.15f;

    private bool attached;
    private Transform attachment;
    private GameObject world_camera;
    private GameObject ui_camera;
    private float camera_height = 20f;
    
	void Awake ()
    {
        instance = this;
        attached = false;
	}

    private void Start()
    {
        modal_master = Master.get_master<IModalMaster>();
        attachment = Player.instance.transform;

        world_camera = GameObject.Find("World Camera");
        ui_camera = GameObject.Find("UI Camera");


        attach();


        Player.input.Player.Zoom.performed += ctx => zoom(ctx.ReadValue<float>());
        //Player.input.Player.Zoom.canceled += ctx => zoom(0);
        Player.input.Player.Look.performed += ctx => pan(ctx.ReadValue<Vector2>());
    }

    public void zoom(float amount)
    {
        if(modal_master.is_in_movement && amount != 0)
        {
            float zoom = amount;
            zoom = -1 * Mathf.Sign(zoom) * Mathf.Clamp(Mathf.Abs(zoom / 100), 1, float.MaxValue);
            camera_height += zoom;
            if(camera_height <= 0)
            {
                camera_height = 1;
            }
            world_camera.transform.position = new Vector3(world_camera.transform.position.x, world_camera.transform.position.y, -camera_height);
        }
    }
    public void pan(Vector2 amt)
    {
        attached = false;
        Vector3 pos = world_camera.transform.position;
        float sensitivity = 0.01f * (-1 * pos.z);
        float amountX = amt.x;
        float amountY = amt.y;
        pos = new Vector3(pos.x + amountX, pos.y + amountY, pos.z);
        world_camera.transform.position = pos;
    }

    public GameObject get_world_camera() { return world_camera; }
    public GameObject get_ui_camera() { return ui_camera; }
    public void attach()
    {
        world_camera.transform.position = new Vector3(attachment.position.x, attachment.position.y, -camera_height);
        attached = true;
    }
    public void move_to_position(Vector2 pos)
    {
        if(!attached)
        {
            attach();
        }
        if(pos.x != world_camera.transform.position.x)
        {
            Tweener.TweenInTime(world_camera.transform, "position.x", pos.x, FOLLOW_TIME);
        }
        if(pos.y != world_camera.transform.position.y)
        {
            Tweener.TweenInTime(world_camera.transform, "position.y", pos.y, FOLLOW_TIME);
        }
    }
}
