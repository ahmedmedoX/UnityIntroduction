using UnityEngine;

public class Destroy_Enemy_Script : MonoBehaviour
{
    void DestroyObject()
    {
        Destroy(transform.parent.gameObject);
    }
    void DestroyEnemy()
    {
        transform.parent.GetChild(0).gameObject.SetActive(false);
        transform.parent.GetChild(1).gameObject.SetActive(false);
    }
}