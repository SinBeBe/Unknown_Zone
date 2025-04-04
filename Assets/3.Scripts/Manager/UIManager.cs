using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    public List<Image> selectItem = new List<Image>();
    public List<Text> selectText = new List<Text>();

    public int selectItemIndex = 0;
    public int selectIndex = 0;

    public Text playerHpText;
    public Image playerStamina;

    public Text soulText;
    public Image interactImage;
    public Image hideImage;

    public Image gameOverImage;
    public Text gameOverText;
    private string[] gameOverTextList = { 
        "Dead.",
        "Try Again.",
        "Dot'n give up.",
        "Next.",
        "HaHaHa",
        "Smile",
        "End?",
        "No help.",
        "SOS",
        "See you later",
        "I'll wait",
        "Did it hurt?"
    };

    public Image askImage;

    private int soulCount = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void PlayerHpTextUpdate(float hp)
    {
        playerHpText.text = "HP " + hp;
    }

    public void PlayerStaminaUpdate(bool isRun)
    {
        playerStamina.fillAmount = GameManager.instance.PlayerStamina(isRun);
    }

    public void ImageOnOff(Image image, bool isState)
    {
        image.gameObject.SetActive(isState);
    }

    public void SoulIncrease()
    {
        soulText.text = (++soulCount).ToString();
        if (soulCount == 5)
        {
            GameManager.instance.isFindSoul = true;
        }
    }

    public void ItemCount(int index, int count)
    {
        selectText[index].text = count.ToString();
    }

    public IEnumerator GameOver()
    {
        Time.timeScale = 0f;
        gameOverText.text = gameOverTextList[Random.Range(0, gameOverTextList.Length)];
        ImageOnOff(gameOverImage, true);
        yield return new WaitForSecondsRealtime(5f);
        SceneManager.LoadScene("MainScene");
    }
}
