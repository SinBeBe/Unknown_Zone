using System.Collections;
using UnityEngine;

public class Syringe : ItemBase
{
    public override IEnumerator ItemUsed()
    {
        //�÷��̾� �ӵ� ����, ������ ���� ����
        yield return new WaitForSeconds(15f);
        GameManager.instance.isUsedItem = false;
    }
}
