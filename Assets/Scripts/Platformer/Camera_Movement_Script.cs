using UnityEngine;

public class Camera_Movement_Script : MonoBehaviour
{
    public Transform Player_Transform;
    public Vector3 Offset = new Vector3(1, 0.5f, -10);
    void LateUpdate()
    {
        this.transform.position = Player_Transform.position + Offset;
    }
}