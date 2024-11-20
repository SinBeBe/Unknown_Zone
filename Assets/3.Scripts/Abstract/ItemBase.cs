using System.Collections;
using UnityEngine;

public abstract class ItemBase : ManagerBase, IUsed
{
    public void Used()
    {
        FindManager();
        StartCoroutine(ItemUsed());
        Destroy(this.gameObject);
        gi.isUsedItem = false;
    }
    public abstract IEnumerator ItemUsed();
}
