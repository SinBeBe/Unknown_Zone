using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "Scriptable Object/Player Data", order = int.MaxValue)]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private float speed;
    public float Speed { get { return speed; } set { speed = value; } }

    [SerializeField]
    private float damagePercent;
    public float DamagePercent { get { return damagePercent; } set { damagePercent = value; } }
}
