using System.Collections;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour, IUsed
{
    public void Used()
    {
        StartCoroutine(ItemUsed());
    }
    public abstract IEnumerator ItemUsed();
}
