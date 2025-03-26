using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : ManagerBase
{
    private void Start()
    {
        FindManager();
    }

    public void OnButtonClick(Button button)
    {
        if (button == Button.Start)
        {
            SceneManager.LoadScene(1);
        }
        else if (button == Button.Option)
        {
            //ui.
        }
        else if (button == Button.Exit)
        {
            Application.Quit();
        }
    }
}
