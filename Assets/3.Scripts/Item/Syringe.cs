using System.Collections;
using UnityEngine;

public class Syringe : MonoBehaviour, IUsed
{
    public void Used()
    {
        StartCoroutine(ItemUsed());
    }
    public IEnumerator ItemUsed()
    {
        yield return null;
    }
   
}
