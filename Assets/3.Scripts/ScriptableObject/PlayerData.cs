using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "Scriptable Object/Player Data", order = int.MaxValue)]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private float walkSpeed;
    public float WalkSpeed { get { return walkSpeed; } set { walkSpeed = value; } }

    [SerializeField]
    private float runSpeed;
    public float RunSpeed { get { return walkSpeed; } set { walkSpeed = value; } }

    [SerializeField]
    private float damagePercent;
    public float DamagePercent { get { return damagePercent; } set { damagePercent = value; } }
}
