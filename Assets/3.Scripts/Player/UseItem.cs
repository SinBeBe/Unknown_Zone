using UnityEngine;
using UnityEngine.InputSystem;

public class UseItem : MonoBehaviour
{
    private int indexer = -1;
    
    public void OnSelectItemInput(InputAction.CallbackContext context)
    {
        Vector2 scrollValue = context.ReadValue<Vector2>();
        Debug.Log(scrollValue.y);

        if(scrollValue.y > 0)
        {
            SelectNextItem();
        }
        else if(scrollValue.y < 0)
        {
            SelectPreviousItem();
        }
    }
    public void OnUseItemInput(InputAction.CallbackContext context)
    {

    }

    private void SelectNextItem()
    {
        ResetSelectItem();

        indexer = (indexer + 1) % UIManager.instance.selectItem.Count;

        UIManager.instance.selectItem[indexer].gameObject.SetActive(true);
    }

    private void SelectPreviousItem()
    {
        ResetSelectItem();

        indexer = (indexer - 1 + UIManager.instance.selectItem.Count) % UIManager.instance.selectItem.Count;

        UIManager.instance.selectItem[indexer].gameObject.SetActive(true);
    }

    private void ResetSelectItem()
    {
        for(int i = 0; i < UIManager.instance.selectItem.Count; i++)
        {
            UIManager.instance.selectItem[i].gameObject.SetActive(false);
        }
    }
}
