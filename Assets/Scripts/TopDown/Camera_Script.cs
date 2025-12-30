using UnityEngine;
public class Camera_Script : MonoBehaviour
{
    public Transform Player_Transform;
    public Vector3 Offset = new Vector3(0, 0, -10);
    void LateUpdate()
    {
        this.transform.position = Player_Transform.position + Offset;
    }
}