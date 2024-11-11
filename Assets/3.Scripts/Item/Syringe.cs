using System.Collections;
using UnityEngine;

public class Syringe : ItemBase
{
    public override IEnumerator ItemUsed()
    {
        //플레이어 속도 증가, 데미지 절반 감소
        yield return new WaitForSeconds(15f);
        gi.isUsedItem = false;
    }
}
