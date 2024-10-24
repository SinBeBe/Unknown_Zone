using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    public Image interactImage;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ImageOnOff(Image image, bool isState)
    {
        image.gameObject.SetActive(isState);
    }
}
