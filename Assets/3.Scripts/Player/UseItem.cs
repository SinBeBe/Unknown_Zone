using UnityEngine;
using UnityEngine.InputSystem;

public class UseItem : MonoBehaviour
{
    private int indexer = -1;
    
    public void OnSelectItemInput(InputAction.CallbackContext context)
    {
        Vector2 scrollValue = context.ReadValue<Vector2>();

        if(scrollValue.y > 0)
        {
            ResetSelectItem();
            if(indexer < UIManager.instance.selectItem.Count - 1)
            {
                indexer += 1;
            }
            else
            {
                indexer = 0;
            }
            UIManager.instance.selectItem[indexer].gameObject.SetActive(true);
        }
        else
        {
            ResetSelectItem();

        }
    }
    public void OnUseItemInput(InputAction.CallbackContext context)
    {

    }

    private void ResetSelectItem()
    {
        for(int i = 0; i < UIManager.instance.selectItem.Count; i++)
        {
            UIManager.instance.selectItem[i].gameObject.SetActive(false);
        }
    }
}
