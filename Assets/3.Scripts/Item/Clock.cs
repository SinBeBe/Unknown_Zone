using System.Collections;
using UnityEngine;

public class Clock : MonoBehaviour, IUsed
{
    public void Used()
    {
        StartCoroutine(ItemUsed());
    }

    public IEnumerator ItemUsed()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(10f);
        Time.timeScale = 1f;
    }
}