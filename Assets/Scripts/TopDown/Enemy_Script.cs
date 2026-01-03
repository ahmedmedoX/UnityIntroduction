using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
<<<<<<< HEAD
    GameObject Enemy_Explosion;
    Rigidbody2D Enemy_Rb;
    Animator Enemy_Animator;
    Animator Enemy_Shadow_Animator;
    Animator Enemy_Explosion_Animator;
    Vector3 Start_Position;
    bool Died = false;
    void Awake()
    {
        Enemy_Rb = this.GetComponent<Rigidbody2D>();
        Enemy_Explosion = this.transform.GetChild(2).gameObject;
        Enemy_Animator = this.transform.GetChild(0).gameObject.GetComponent<Animator>();
        Enemy_Shadow_Animator = this.transform.GetChild(1).gameObject.GetComponent<Animator>();
        Enemy_Explosion_Animator = Enemy_Explosion.GetComponent<Animator>();
        Start_Position = transform.position;
        Enemy_Rb.linearVelocity = new Vector3(0.0f, 0.5f, 0.0f);
=======
    void Start()
    {
        
>>>>>>> parent of 3a0b5ee (Day5 Light Baking)
    }
    void Update()
    {
        if (!Died)
        {
            if (transform.position.y >= Start_Position.y + 2.0f &&
                transform.position.x == Start_Position.x)
            {
                transform.position = Start_Position + new Vector3(0.0f, 2.0f, 0.0f);
                Enemy_Rb.linearVelocity = new Vector3(-0.5f, 0.0f, 0.0f);
                Enemy_Animator.SetInteger("Direction", 4);
                Enemy_Shadow_Animator.SetTrigger("Reset_Animation");
            }
            if (transform.position.x == Start_Position.x - 2.0f &&
                transform.position.y <= Start_Position.y)
            {
                transform.position = Start_Position + new Vector3(-2.0f, 0.0f, 0.0f);
                Enemy_Rb.linearVelocity = new Vector3(0.5f, 0.0f, 0.0f);
                Enemy_Animator.SetInteger("Direction", 2);
                Enemy_Shadow_Animator.SetTrigger("Reset_Animation");
            }
            if (transform.position.x <= Start_Position.x - 2.0f &&
                transform.position.y == Start_Position.y + 2.0f)
            {
                transform.position = Start_Position + new Vector3(-2.0f, 2.0f, 0.0f);
                Enemy_Rb.linearVelocity = new Vector3(0.0f, -0.5f, 0.0f);
                Enemy_Animator.SetInteger("Direction", 3);
                Enemy_Shadow_Animator.SetTrigger("Reset_Animation");
            }
            if (transform.position.x >= Start_Position.x &&
                transform.position.y == Start_Position.y)
            {
                transform.position = Start_Position + new Vector3(0.0f, 0.0f, 0.0f);
                Enemy_Rb.linearVelocity = new Vector3(0.0f, 0.5f, 0.0f);
                Enemy_Animator.SetInteger("Direction", 1);
                Enemy_Shadow_Animator.SetTrigger("Reset_Animation");
            }
        }
        else
        {
            Enemy_Rb.linearVelocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
<<<<<<< HEAD
            Died = true;
            Enemy_Animator.SetTrigger("Death");
            Enemy_Shadow_Animator.SetTrigger("Death");
            Enemy_Explosion.SetActive(true);
            Enemy_Explosion_Animator.SetTrigger("Explode");
            Debug.Log("Enemy Hit");
=======
            Debug.Log("Enemy Hit");
            Destroy(transform.parent.gameObject);
>>>>>>> parent of 3a0b5ee (Day5 Light Baking)
        }
    }
}