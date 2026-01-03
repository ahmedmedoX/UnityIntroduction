using UnityEngine;

public class Slime_Enemy_Script : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
            Debug.Log("Enemy Hit");
        }
    }
}