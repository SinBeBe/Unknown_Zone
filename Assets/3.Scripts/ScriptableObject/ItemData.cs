using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Object/Item Data", order = int.MaxValue)]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private int index;
    public int Index {  get { return index; } }

    public int count;
    public bool isGet;
}
