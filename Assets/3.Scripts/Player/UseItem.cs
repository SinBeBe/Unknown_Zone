using UnityEngine;
using UnityEngine.InputSystem;

public class UseItem : MonoBehaviour
{
    UIManager ui;

    private void Start()
    {
        ui = UIManager.instance;
    }

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

        ui.selectIndex = (ui.selectIndex + direction + ui.selectItem.Count) % UIManager.instance.selectItem.Count;

        ui.selectItem[ui.selectIndex].gameObject.SetActive(true);
    }

    private void ResetSelectItem()
    {
        foreach (var item in ui.selectItem)
        {
            item.gameObject.SetActive(false);
        }
    }
}
