using System.Collections;

public abstract class ItemBase : ManagerBase, IUsed
{
    public void Used()
    {
        FindManager();
        gi.isUsedItem = true;
        StartCoroutine(ItemUsed());
    }
    public abstract IEnumerator ItemUsed();
}
