using System.Collections;
using UnityEngine;

public class Clock : ItemBase
{
    public override IEnumerator ItemUsed()
    {
        //�ͽŸ� �������̰� �ϴ� ����
        yield return new WaitForSecondsRealtime(10f);
        //�ٽ� �ͽ� �����̰� �ϴ� ����
    }
}
