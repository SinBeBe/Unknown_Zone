using System.Collections;

public abstract class ItemBase : ManagerBase, IUsed
{
    public void Used()
    {
        FindManager();
        StartCoroutine(ItemUsed());
        gameObject.SetActive(false);
        Destroy(this.gameObject, 15f);
        gi.isUsedItem = false;
    }
    public abstract IEnumerator ItemUsed();
}
