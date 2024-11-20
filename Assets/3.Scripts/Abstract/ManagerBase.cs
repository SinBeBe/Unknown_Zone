using UnityEngine;

public abstract class ManagerBase : MonoBehaviour
{
    protected GameManager gi;
    protected UIManager ui;
    protected AudioManager ai;

    protected void Awake()
    {
        FindManager();
    }

    protected void FindManager()
    {
        gi = GameManager.instance;
        ui = UIManager.instance;
        ai = AudioManager.instance;
    }
}
