using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Object/Item Data", order = int.MaxValue)]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private int index;
    public int Index {  get { return index; } }

    [SerializeField]
    private int count = 0;
    public int Count { get { return count; } set { count = value; } }

    [SerializeField]
    private bool isGet = false;
    public bool IsGet { get { return isGet; } set { isGet = value; } }
}
