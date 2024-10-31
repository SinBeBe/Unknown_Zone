using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    private List<GameObject> candleLight = new List<GameObject>();

    private int indexer = -1;

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
        indexer += 1;
        candleLight[indexer].SetActive(true);
    }
}
