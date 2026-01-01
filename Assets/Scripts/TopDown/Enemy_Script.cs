using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    Animator Enemy_Animator;
    void Awake()
    {
        Enemy_Animator = this.GetComponent<Animator>();
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Enemy_Animator.SetTrigger("Death");
            Debug.Log("Enemy Hit");
            //Destroy(transform.parent.gameObject);
        }
    }
}