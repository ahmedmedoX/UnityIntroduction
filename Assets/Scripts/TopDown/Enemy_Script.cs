using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Debug.Log("Enemy Hit");
            Destroy(transform.parent.gameObject);
        }
    }
}