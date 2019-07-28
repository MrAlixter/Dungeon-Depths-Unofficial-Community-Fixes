using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[ExecuteInEditMode]
public class UIRectangle : UIShape
{
    [SerializeField]
    Texture m_Texture;

    public bool MatchRectTransform = false;

#if UNITY_EDITOR
    [ConditionalHide("MatchRectTransform", Inverted = true)]
#endif
    [SerializeField]
    protected float _width;
    public float width
    {
        get { return _width; }
        set
        {
            _width = value;
        }
    }

#if UNITY_EDITOR
    [ConditionalHide("MatchRectTransform", Inverted = true)]
#endif
    [SerializeField]
    protected float _height;
    public float height
    {
        get { return _height; }
        set
        {
            _height = value;
        }
    }

    public override Vector2 size
    {
        get { return new Vector2(_width, _height); }
        set
        {
            _width = value.x;
            _height = value.y;
        }
    }

    [SerializeField]
    protected bool _fill = true;
    public override bool fill { get { return _fill; } set { _fill = value; } }

#if UNITY_EDITOR
    [ConditionalHide("_fill", Inverted = true)]
#endif
    [SerializeField]
    protected int _thickness = 5;
    public override int thickness { get { return _thickness; } set { _thickness = value; } }

    public override Texture mainTexture
    {
        get
        {
            return m_Texture == null ? s_WhiteTexture : m_Texture;
        }
    }

    public override Texture texture
    {
        get { return m_Texture; }

        set
        {
            if (m_Texture == value)
                return;
            m_Texture = value;
            SetVerticesDirty();
            SetMaterialDirty();
        }
    }

    protected RectTransform rt { get { return rectTransform; } }
    public override float rotation
    {
        get { return rt.rotation.z; }
        set { rt.eulerAngles = new Vector3(rt.eulerAngles.x, rt.eulerAngles.y, value); }
    }

    public override Vector2 center
    {
        get { return rt.anchoredPosition; }
        set { rt.anchoredPosition = value; }
    }

    public override bool visible
    {
        get { return enabled; }
        set { enabled = value; }
    }

    public enum h_align { Middle, Left, Right };
    public h_align horizontal_align;
    public enum v_align { Middle, Top, Bottom };
    public v_align vertical_align;


    int pointCount;
    UIVertex[] uiVertices;
    Vector2[] uvs;
    Vector2[] pos;
    Dictionary<string, Vector2> points;

    protected override void Start()
    {
        if(fill) { pointCount = 4; }
        else
        {
            pointCount = 24;
            points = new Dictionary<string, Vector2>();
        }

        uiVertices = new UIVertex[pointCount];
        pos = new Vector2[pointCount];
        uvs = new Vector2[pointCount];

        for(int i = 0; i < pointCount; i+=4)
        {
            uvs[i] = new Vector2(0, 1);
            uvs[i+1] = new Vector2(1, 1);
            uvs[i+2] = new Vector2(1, 0);
            uvs[i+3] = new Vector2(0, 0);
        }
    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        
        /////////////////////////////////
        //I'd like to not have these here, but it doesn't work well with changing it in the editor if I don't 
        //If I don't have this block here, I have to rebuild the game for some changes to take effect
        if (fill) { pointCount = 4; }
        else
        {
            pointCount = 24;
            points = new Dictionary<string, Vector2>();
        }

        uiVertices = new UIVertex[pointCount];
        pos = new Vector2[pointCount];
        uvs = new Vector2[pointCount];

        for (int i = 0; i < pointCount; i += 4)
        {
            uvs[i] = new Vector2(0, 1);
            uvs[i + 1] = new Vector2(1, 1);
            uvs[i + 2] = new Vector2(1, 0);
            uvs[i + 3] = new Vector2(0, 0);
        }
        ////////////////////////////////
        

        vh.Clear();
        
        if(MatchRectTransform)
        {
            width = rt.rect.width;
            height = rt.rect.height;
        }

        float l = 0;
        float r = 0;
        float t = 0;
        float b = 0;

        if (horizontal_align == h_align.Middle)
        {
            l = -width / 2;
            r = width / 2;
        }
        else if (horizontal_align == h_align.Left)
        {
            l = 0;
            r = width;
        }
        else if (horizontal_align == h_align.Right)
        {
            l = -width;
            r = 0;
        }

        if (vertical_align == v_align.Middle)
        {
            t = height / 2;
            b = -height / 2;
        }
        else if (vertical_align == v_align.Top)
        {
            t = -height;
            b = 0;
        }
        else if (vertical_align == v_align.Bottom)
        {
            t = 0;
            b = height;
        }

        if (fill)
        {
            pos[0] = new Vector2(l, t);
            pos[1] = new Vector2(r, t);
            pos[2] = new Vector2(r, b);
            pos[3] = new Vector2(l, b);

            for (int i = 0; i < pointCount; i++)
            {
                uiVertices[i].color = color;
                uiVertices[i].position = pos[i];
                uiVertices[i].uv0 = uvs[i];
            }

            vh.AddUIVertexQuad(uiVertices);
        }
        else
        {
            points["tlo"] = new Vector2(l, t);
            points["tro"] = new Vector2(r, t);
            points["bro"] = new Vector2(r, b);
            points["blo"] = new Vector2(l, b);

            points["tli"] = new Vector2(points["tlo"].x + thickness, points["tlo"].y - thickness);
            points["tri"] = new Vector2(points["tro"].x - thickness, points["tro"].y - thickness);
            points["bri"] = new Vector2(points["bro"].x - thickness, points["bro"].y + thickness);
            points["bli"] = new Vector2(points["blo"].x + thickness, points["blo"].y + thickness);

            
            //Top tri 1
            pos[0] = points["tlo"];
            pos[1] = points["tli"];
            pos[2] = points["tri"];

            //Top tri 2
            pos[3] = points["tlo"];
            pos[4] = points["tro"];
            pos[5] = points["tri"];

            //Right tri 1
            pos[6] = points["tro"];
            pos[7] = points["tri"];
            pos[8] = points["bri"];

            //Right tri 2
            pos[9] = points["tro"];
            pos[10] = points["bri"];
            pos[11] = points["bro"];

            //Bottom tri 1
            pos[12] = points["blo"];
            pos[13] = points["bli"];
            pos[14] = points["bri"];

            //Bottom tri 2
            pos[15] = points["bri"];
            pos[16] = points["blo"];
            pos[17] = points["bro"];

            //Left tri 1
            pos[18] = points["blo"];
            pos[19] = points["bli"];
            pos[20] = points["tli"];

            //Left tri 2
            pos[21] = points["blo"];
            pos[22] = points["tlo"];
            pos[23] = points["tli"];


            for (int i = 0; i < pointCount; i++)
            {
                uiVertices[i].color = color;
                uiVertices[i].position = pos[i];
                uiVertices[i].uv0 = uvs[i];
            }

            for (int i = 0; i < pointCount; i++)
            {
                vh.AddVert(uiVertices[i]);
            }
            
            for(int i = 0; i < pointCount; i+= 3)
            {
                vh.AddTriangle(i, i+1, i+2);
            }
        }
    }
}
