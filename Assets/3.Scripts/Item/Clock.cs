using System.Collections;
using UnityEngine;

public class Clock : ItemBase
{
    public override IEnumerator ItemUsed()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(10f);
        Time.timeScale = 1;
    }
}
