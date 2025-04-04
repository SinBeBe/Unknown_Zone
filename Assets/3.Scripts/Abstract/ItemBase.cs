using System.Collections;

public abstract class ItemBase : ManagerBase, IUsed
{
    public void Used()
    {
        FindManager();
        StartCoroutine(ItemUsed());
        gameObject.SetActive(false);
        gi.isUsedItem = false;
    }
    public abstract IEnumerator ItemUsed();
}
