using System.Collections;
using UnityEngine;

public abstract class ItemBase : ManagerBase, IUsed
{
    public void Used()
    {
        FindManager();
        StartCoroutine(ItemUsed());
    }
    public abstract IEnumerator ItemUsed();
}
