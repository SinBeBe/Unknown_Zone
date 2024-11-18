using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData data;

    private void Start()
    {
        data.Count = 0;
        data.IsGet = false;
    }

    public int Count
    {
        get { return data.Count; }
        set { data.Count = value; }
    }

    public bool IsGet
    {
        get { return data.IsGet; }
        set { data.IsGet = value; }
    }
}