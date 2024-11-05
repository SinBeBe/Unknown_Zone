using UnityEngine;
using UnityEngine.InputSystem;

public class UseItem : MonoBehaviour
{
    private int indexer = 0;
    
    public void OnSelectItemInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 scrollValue = context.ReadValue<Vector2>();
            int scrollDirection = scrollValue.y > 0 ? 1 : (scrollValue.y < 0 ? -1 : 0);
            Debug.Log(scrollDirection);

            if (scrollDirection != 0)
            {
                SelectItem(scrollDirection);
            }
        }
    }
    public void OnUseItemInput(InputAction.CallbackContext context)
    {

    }

    private void SelectItem(int direction)
    {
        ResetSelectItem();

        indexer = (indexer + direction + UIManager.instance.selectItem.Count) % UIManager.instance.selectItem.Count;

        UIManager.instance.selectItem[indexer].gameObject.SetActive(true);
    }

    private void ResetSelectItem()
    {
        foreach (var item in UIManager.instance.selectItem)
        {
            item.gameObject.SetActive(false);
        }
    }
}
