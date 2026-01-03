using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") && !collision.CompareTag("Magnetic Field"))
            Destroy(this.gameObject);
    }
}