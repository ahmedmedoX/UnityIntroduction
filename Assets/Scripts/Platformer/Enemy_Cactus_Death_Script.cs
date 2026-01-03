using UnityEngine;
public class Enemy_Cactus_Death_Script : MonoBehaviour
{
    void Destroy_Object()
    {
        Destroy(transform.parent.gameObject);
    }
}