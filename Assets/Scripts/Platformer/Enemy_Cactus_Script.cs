using UnityEngine;

public class Enemy_Cactus_Script : MonoBehaviour
{
    Animator Child_Animator;
    SpriteRenderer Sprite;
    Rigidbody2D Enemy_Rb;
    bool Died = false;
    Vector3 Start_Position;
    void Awake()
    {
        Start_Position = this.transform.position;
        Child_Animator = this.transform.GetChild(0).GetComponent<Animator>();
        Sprite = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        Enemy_Rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!Died)
        {
            if (transform.position.x >= Start_Position.x)
            {
                transform.position = Start_Position;
                Enemy_Rb.linearVelocity = new Vector3(-2.0f, 0.0f, 0.0f);
                Sprite.flipX = false;
            }
            if (transform.position.x <= Start_Position.x - 14.0f)
            {
                transform.position = Start_Position + new Vector3(-14.0f, 0.0f, 0.0f);
                Enemy_Rb.linearVelocity = new Vector3(2.0f, 0.0f, 0.0f);
                Sprite.flipX = true;
            }
        }
        else
        {
            Enemy_Rb.linearVelocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Died = true;
            Debug.Log("Enemy Hit");
            Child_Animator.SetTrigger("Death");
        }
    }
}