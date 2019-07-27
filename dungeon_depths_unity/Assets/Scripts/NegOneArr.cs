using System.Collections;
using System.Collections.Generic;

//A specially made array to handle -1s
public class NegOneArr<T> : IEnumerable<T>
{
    private int size;
    private T[] data;

    public NegOneArr(int size)
    {
        this.size = size;
        data = new T[size];
    }

    public T this[int ind]
    {
        get
        {
            return data[ind + 1];
        }
        set
        {
            data[ind + 1] = value;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < size; i++)
        {
            yield return data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
