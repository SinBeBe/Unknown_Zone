using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    private List<GameObject> candleLight = new List<GameObject>();

    public List<GameObject> items = new List<GameObject>();

    public bool isUsedItem = false;

    public float playerSpeed = 7f;
    public float damagePercent = 100f;

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

    public void OnCandle()
    {
        candleIndexer += 1;
        candleLight[candleIndexer].SetActive(true);
    }
}
