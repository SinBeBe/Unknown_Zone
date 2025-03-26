using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : ManagerBase
{
    private void Start()
    {
        FindManager();
    }

    public void OnClickButton(string name)
    {
        if (name == "Start")
        {
            SceneManager.LoadScene(1);
        }
        else if (name == "Option")
        {

        }
        else if (name == "Exit")
        {
            Application.Quit();
        }
    }
}
