using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData data;

    private int count;
    private bool isGet;

    private void Start()
    {
        count = data.Count;
        isGet = data.IsGet;
    }

    public int Count
    {
        get { return count; }
        set { count = value; }
    }

    public bool IsGet
    {
        get { return isGet; }
        set { isGet = value; }
    }
}