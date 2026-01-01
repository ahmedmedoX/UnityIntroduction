using UnityEngine;
using UnityEngine.UIElements;

public class Camera_Movement_Script : MonoBehaviour
{
    public Transform Player_Transform;
    public Vector3 Offset = new(1, 0.5f, -10);
    void LateUpdate()
    {
        this.transform.position = Player_Transform.position + Offset;
    }
}