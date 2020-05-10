using System;
using UnityEngine;

[Serializable]
public class MoveMap<T>
{
    public int width { get; private set; }
    public int height { get; private set; }

    public T[,] map;

    public MoveMap(int w, int h)
    {
        width = w;
        height = h;
        map = new T[w, h];
    }

    public T this[int x, int y]
    {
        get { return map[x, y]; }
        set { map[x, y] = value; }
    }

    public T this[Vector2Int pos]
    {
        get { return this[pos.x, pos.y]; }
        set { this[pos.x, pos.y] = value; }
    }

    public int getWidth() { return width; }

    public int getHeight() { return height; }
}