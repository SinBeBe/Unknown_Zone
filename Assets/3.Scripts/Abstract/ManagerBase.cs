using UnityEngine;

public abstract class ManagerBase : MonoBehaviour
{
    protected GameManager gi;
    protected UIManager ui;

    protected void Awake()
    {
        gi = GameManager.instance;
        ui = UIManager.instance;
    }
}
