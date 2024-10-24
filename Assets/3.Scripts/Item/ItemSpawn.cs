using System.Linq;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    private GameObject[] gameObjects;
    public int num;

    private void Start()
    {
        gameObjects = new GameObject[gameObject.transform.childCount];

        for(int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i] = gameObject.transform.GetChild(i).gameObject;
        }

        // UnityEngine.RandomÀ» »ç¿ëÇÏ¿© ·£´ýÇÑ ÀÎµ¦½º »ý¼º
        int[] randomNumbers = Enumerable.Range(0, gameObjects.Length)
                                        .OrderBy(_ => Random.value) // ·£´ý °ªÀ¸·Î ¼¯±â
                                        .Take(num)
                                        .ToArray();

        GameObject[] excludeGameObjects = gameObjects.Where((gameObject, index) =>
        !randomNumbers.Contains(index)
        ).ToArray();

        foreach(GameObject gameObject in excludeGameObjects)
        {
            Destroy(gameObject);
        }
    }
}
