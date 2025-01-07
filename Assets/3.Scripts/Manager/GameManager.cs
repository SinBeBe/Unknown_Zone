using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public PlayerData playerData;

    [SerializeField]
    private List<GameObject> candleLight = new List<GameObject>();

    public List<GameObject> items = new List<GameObject>();

    private float maxStamina = 100f;
    private float stamina = 100f;
    private float regenRate = 4f;
    private float decreaseRate = 10f;

    public float playerSpeed;
    public float damagePercent;

    public bool isUsedItem = false;

    public bool isFindTalisman;
    public bool isFindSoul;

    public bool isPlayerHide;
    public bool isExhausted = false;

    private int candleIndexer = -1;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        playerSpeed = playerData.Speed;
        damagePercent = playerData.DamagePercent;

        UIManager.instance.PlayerHpTextUpdate(playerData.HP);
    }

    public float PlayerStamina(bool isRun)
    {
        if(isRun && stamina > 0 && !isExhausted)
        {
            stamina -= decreaseRate * Time.deltaTime;

            if(stamina <= 0)
            {
                stamina = 0;
                isExhausted = true;
            }
        }
        else
        {
            if(stamina < maxStamina)
            {
                stamina += regenRate * Time.deltaTime;

                if(stamina >= 30)
                {
                    isExhausted = false;
                }
            }
        }

        stamina = Mathf.Clamp(stamina, 0f, maxStamina);

        return stamina / maxStamina;
    }

    public void OnCandle()
    {
        candleIndexer += 1;
        candleLight[candleIndexer].SetActive(true);
        if (candleIndexer == 4)
        {
            isFindTalisman = true;
        }
    }

    public void SwitchGameObject<T>(string tag, bool isStop) where T : Component
    {
        GameObject[] gameObject = GameObject.FindGameObjectsWithTag(tag);
        foreach(GameObject obj in gameObject)
        {
            T component = obj.GetComponent<T>();
            if(component is MonoBehaviour mono)
            {
                mono.enabled = isStop;
            }
        }
    }

    public void GameClear()
    {
        if(!isFindTalisman && !isFindSoul)
        {
            BadEnding();
        }
        else if(isFindTalisman && !isFindSoul)
        {
            NormalEnding(1);
        }
        else if(!isFindTalisman && isFindSoul)
        {
            NormalEnding(2);
        }
        else
        {
            HappyEnding();
        }
    }

    private void BadEnding()
    {
        Debug.Log("Bad");
    }

    private void NormalEnding(int num)
    {
        Debug.Log("Normal" + num);
    }

    private void HappyEnding()
    {
        Debug.Log("Happy");
    }
}
