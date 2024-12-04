using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public PlayerData playerData;

    [SerializeField]
    private List<GameObject> candleLight = new List<GameObject>();

    public List<GameObject> items = new List<GameObject>();

    public bool isUsedItem = false;

    public bool isFindTalisman;
    public bool isFindSoul;

    public bool isPlayerHide;

    public float playerSpeed;
    public float damagePercent;

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
        else if(isFindTalisman || isFindSoul)
        {
            NormalEnding();
        }
        else
        {
            HappyEnding();
        }
    }

    private void BadEnding()
    {

    }

    private void NormalEnding()
    {

    }

    private void HappyEnding()
    {

    }
}
