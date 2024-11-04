using System.Collections;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public void Used()
    {
        StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(10f);
        Time.timeScale = 1f;
    }
}
