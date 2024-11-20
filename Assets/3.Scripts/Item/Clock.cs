using System.Collections;
using UnityEngine;

public class Clock : ItemBase
{
    public override IEnumerator ItemUsed()
    {
        //귀신만 못움직이게 하는 로직
        yield return new WaitForSecondsRealtime(10f);
        //다시 귀신 움직이게 하는 로직
    }
}
