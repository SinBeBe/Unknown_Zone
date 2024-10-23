using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject CameraPos;

    void Update()
    {
        Camera.main.transform.position = CameraPos.transform.position;
    }
}
