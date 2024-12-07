using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    public List<Image> selectItem = new List<Image>();
    public List<Text> selectText = new List<Text>();

    public int selectItemIndex = 0;
    public int selectIndex = 0;

    public Text soulText;
    public Image interactImage;
    public Image hideImage;

    public Image askImage;

    private int soulCount = 0;

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

    public void SoulIncrease()
    {
        soulText.text = (soulCount + 1).ToString();
        if (soulCount == 5)
        {
            GameManager.instance.isFindSoul = true;
        }
    }

    public void ItemCount(int index, int count)
    {
        selectText[index].text = count.ToString();
    }

    public bool IsAskExit()
    {
        ImageOnOff(askImage, true);
        return true;
    }
}
