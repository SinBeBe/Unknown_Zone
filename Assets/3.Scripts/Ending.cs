using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ending : ManagerBase
{
    private bool isWaitingForInput = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            StartCoroutine(HandleEnding());
        }
    }

    private IEnumerator HandleEnding()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        ui.ImageOnOff(ui.askImage, true);

        isWaitingForInput = true;
        while (isWaitingForInput)
        {
            yield return null;
        }
    }

    public void OnConfirmExit()
    {
        isWaitingForInput = false;
        gi.GameClear();
    }

    public void OnCancelExit()
    {
        isWaitingForInput = false;

        ui.ImageOnOff(ui.askImage, false);

        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
