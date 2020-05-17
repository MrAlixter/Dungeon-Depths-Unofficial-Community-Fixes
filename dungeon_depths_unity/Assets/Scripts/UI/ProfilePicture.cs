using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ProfilePicture : MonoBehaviour, IProfilePictureMaster
{
    public static char sep = Path.DirectorySeparatorChar;

    public static ProfilePicture instance { get; private set; }
    
    protected static Player player;

    private RectTransform panel;

    private Image _background;
    private Image _hair_back;
    private Image _cloak_back;
    private Image _body;
    private Image _head;
    private Image _hair_middle;
    private Image _eyes;
    private Image _eyebrows;
    private Image _nose;
    private Image _mouth;
    private Image _accessory;
    private Image _clothes;
    private Image _glasses;
    private Image _ears;
    private Image _hair_front;
    private Image _cloak_front;
    private Image _hat;

    public Sprite background { get { return _background.sprite; } set { _background.sprite = value; } }
    public Sprite hair_back { get { return _hair_back.sprite; } set { _hair_back.sprite = value; } }
    public Sprite cloak_back { get { return _cloak_back.sprite; } set { _cloak_back.sprite = value; } }
    public Sprite body { get { return _body.sprite; } set { _body.sprite = value; } }
    public Sprite head { get { return _head.sprite; } set { _head.sprite = value; } }
    public Sprite hair_middle { get { return _hair_middle.sprite; } set { _hair_middle.sprite = value; } }
    public Sprite eyes { get { return _eyes.sprite; } set { _eyes.sprite = value; } }
    public Sprite eyebrows { get { return _eyebrows.sprite; } set { _eyebrows.sprite = value; } }
    public Sprite nose { get { return _nose.sprite; } set { _nose.sprite = value; } }
    public Sprite mouth { get { return _mouth.sprite; } set { _mouth.sprite = value; } }
    public Sprite accessory { get { return _accessory.sprite; } set { _accessory.sprite = value; } }
    public Sprite clothes { get { return _clothes.sprite; } set { _clothes.sprite = value; } }
    public Sprite glasses { get { return _glasses.sprite; } set { _glasses.sprite = value; } }
    public Sprite ears { get { return _ears.sprite; } set { _ears.sprite = value; } }
    public Sprite hair_front { get { return _hair_front.sprite; } set { _hair_front.sprite = value; } }
    public Sprite cloak_front { get { return _cloak_front.sprite; } set { _cloak_front.sprite = value; } }
    public Sprite hat { get { return _hat.sprite; } set { _hat.sprite = value; } }

    public Dictionary<string, Sprite> body_pictures;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        player = Player.instance;


        if(panel == null) { panel = transform.Find("Panel").GetComponent<RectTransform>(); }

        if(_background == null) { _background = panel.Find("Background").GetComponent<Image>(); }
        if(_hair_back == null) { _hair_back = panel.Find("Hair_Back").GetComponent<Image>(); }
        if(_cloak_back == null) { _cloak_back = panel.Find("Cloak_Back").GetComponent<Image>(); }
        if(_body == null) { _body = panel.Find("Body").GetComponent<Image>(); }
        if(_head == null) { _head = panel.Find("Head").GetComponent<Image>(); }
        if(_hair_middle == null) { _hair_middle = panel.Find("Hair_Middle").GetComponent<Image>(); }
        if(_eyes == null) { _eyes = panel.Find("Eyes").GetComponent<Image>(); }
        if(_eyebrows == null) { _eyebrows = panel.Find("Eyebrows").GetComponent<Image>(); }
        if(_nose == null) { _nose = panel.Find("Nose").GetComponent<Image>(); }
        if(_mouth == null) { _mouth = panel.Find("Mouth").GetComponent<Image>(); }
        if(_accessory == null) { _accessory = panel.Find("Accessory").GetComponent<Image>(); }
        if(_clothes == null) { _clothes = panel.Find("Clothes").GetComponent<Image>(); }
        if(_glasses == null) { _glasses = panel.Find("Glasses").GetComponent<Image>(); }
        if(_ears == null) { _ears = panel.Find("Ears").GetComponent<Image>(); }
        if(_hair_front == null) { _hair_front = panel.Find("Hair_Front").GetComponent<Image>(); }
        if(_cloak_front == null) { _cloak_front = panel.Find("Cloak_Front").GetComponent<Image>(); }
        if(_hat == null) { _hat = panel.Find("Hat").GetComponent<Image>(); }

        string path = "Player Images" + sep + "Body";
        if(body_pictures == null)
        {
            body_pictures = new Dictionary<string, Sprite>();
            for(int i = -1; i <= 7; i++)
            {
                body_pictures[$"{i}"] = Resources.Load<Sprite>(path + sep + i);
                body_pictures[$"{i}c"] = Resources.Load<Sprite>(path + sep + i + "c");
            }
        }
    }


    public void regenerate_profile_picture()
    {
        update_armor();
        update_skin_color();
        update_hair_color();
    }

    public void update_armor()
    {
        clothes = player.equipped_armor.variants[player.breast_size];
        update_body();
    }

    public void update_body()
    {
        string s = player.equipped_armor.compresses_breasts ? $"{player.breast_size}c" : $"{player.breast_size}";
        body = body_pictures[s];
    }

    public void update_skin_color()
    {
        set_skin_color(player.skin_color);
    }

    public void update_hair_color()
    {
        set_hair_color(player.hair_color);
    }


    protected void set_skin_color(Color goal)
    {
        _head.color = goal;
        _body.color = goal;
        _nose.color = goal;
        _ears.color = goal;

        ////Debug.Log(goal)
        ////_face.color = goal;
        ////_body.color = goal;
        
        //float g_h;
        //float g_s;
        //float g_v;
        //Color.RGBToHSV(goal, out g_h, out g_s, out g_v);
        //Debug.Log($"GOAL {g_h} {g_s} {g_v}");


        ////Color new_color = Color.HSVToRGB(0.5f + h_diff, 0.5f + s_diff, 0.5f + v_diff);
        //Color new_color = Color.HSVToRGB(g_h, g_s, g_v);
        //Debug.Log($"NEW {new_color}");

        ////_head.color = new_color;
        ////_body.color = new_color;
        ////Debug.Log($"GOAL {goal}");
        ////Debug.Log($"ORIGINAL {original}");
        ////Debug.Log($"NEW COL {new_color}");
        ////Debug.Log($"GOAL {g_h} {g_s} {g_v}");
        ////Debug.Log($"ORIGINAL {o_h} {o_s} {o_v}");
        ////Debug.Log($"NEW COL {h_diff} {s_diff} {v_diff}");
    }

    protected void set_hair_color(Color color)
    {
        _hair_back.color = color;
        _hair_middle.color = color;
        _hair_front.color = color;
    }
}
