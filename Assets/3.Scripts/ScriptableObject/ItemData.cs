using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Object/Item Data", order = int.MaxValue)]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private int count;
    public int Count {  get { return count; } set { count = value; } }

    [SerializeField]
    private bool isGet;
    public bool IsGet { get { return isGet; } set { isGet = value; } }
}
