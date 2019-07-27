using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkinGradient : RawImage, IPointerClickHandler
{
    private static SkinGradient _instance;
    public static SkinGradient instance { get { return _instance != null ? _instance : new SkinGradient(); } }
    
    private RectTransform rt;
    public List<Color> colors;
    private Gradient skin_colors;

    public SkinGradient()
    {
        if (_instance != null && _instance != this) { Destroy(this.gameObject); }
        else { _instance = this; }

        colors = new List<Color>();
        colors.Add(c_byte(250, 235, 215));
        colors.Add(c_byte(247, 219, 195));
        colors.Add(c_byte(240, 184, 160));
        colors.Add(c_byte(210, 161, 140));
        colors.Add(c_byte(180, 138, 120));
        colors.Add(c_byte(105, 80, 70));

        float buffer = 0.05f;
        float stretch = 1-(2*buffer);

        skin_colors = new Gradient();
        GradientColorKey[] ck = new GradientColorKey[colors.Count];
        GradientAlphaKey[] ak = new GradientAlphaKey[colors.Count];
        for(int i = 0; i < colors.Count; i++)
        {
            float time = ((float)i/(colors.Count-1)) * stretch + buffer;
            GradientColorKey ck_temp = new GradientColorKey();
            ck_temp.color = colors[i];
            ck_temp.time = time;
            ck[i] = ck_temp;
            GradientAlphaKey ak_temp = new GradientAlphaKey();
            ak_temp.alpha = 1.0f;
            ak_temp.time = time;
            ak[i] = ak_temp;
        }
        skin_colors.alphaKeys = ak;
        skin_colors.colorKeys = ck;
    }

    //Mostly to be used for the implicit conversion of int to byte and Color32 to Color
    private Color c_byte(byte r, byte g, byte b)
    {
        return new Color32(r, g, b, 255);
    }

    public Color Evaluate(float time)
    {
        return skin_colors.Evaluate(time);
    }

    public Texture2D GetTexture(int width)
    {
        Texture2D texture = new Texture2D(width, 1);
        Color[] colors = new Color[width];
        for(int i = 0; i < width; i++)
        {
            colors[i] = Evaluate((float)i/(width-1));
        }
        texture.SetPixels(colors);
        texture.Apply();
        return texture;
    }

    protected override void Awake()
    {
        rt = gameObject.GetComponent<RectTransform>();
        Texture2D t2d = GetTexture((int)rt.rect.width);
        texture = t2d;
        
        //sprite = Sprite.Create(t2d, new Rect(0, 0, t2d.width, t2d.height), rt.pivot);
        //SpriteDrawMode
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 local;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, eventData.pressPosition, eventData.pressEventCamera, out local))
        {
            Color click_color = Evaluate(local.x / rt.rect.width); //Get color at that vertical slice;
            Player.instance.change_skin_color(click_color);
        }
    }
}
