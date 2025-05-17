using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonManager : ManagerBase
{
    [SerializeField]
    private GameObject optionPanel;

    private void Start()
    {
        FindManager();
    }

    public void OnClickButton(string name)
    {
        Debug.Log(name);
        if (name == "Start")
        {
            SceneManager.LoadScene(1);
        }
        else if (name == "Option")
        {
            
        }
        else if (name == "Quit")
        {
            Application.Quit();
        }
        else if (name == "Continue")
        {
            Time.timeScale = 1f;
        }
        else if(name == "Exit")
        {
            SceneManager.LoadScene(0);
        }
    }
}
