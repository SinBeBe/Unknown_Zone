using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonManager : ManagerBase
{
    [SerializeField]
    private Image optionPanel;

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
            UIManager.instance.ImageOnOff(optionPanel, true);
            UIManager.instance.currentImage = optionPanel;
        }
        else if (name == "Quit")
        {
            Application.Quit();
        }
        else if (name == "Continue")
        {
            UIManager.instance.gameEscPanel.gameObject.SetActive(false);
            GameManager.instance.CursorModeChange(CursorLockMode.Locked, false);
            Time.timeScale = 1f;
        }
        else if(name == "Exit")
        {
            SceneManager.LoadScene(0);
        }
    }
}
