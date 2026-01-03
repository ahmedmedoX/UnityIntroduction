using UnityEngine;
public class Score_Script : MonoBehaviour
{
    int Score = 0;
    int Health = 100;
    Rigidbody2D Player_RigidBody;
    //SpriteRenderer Player_Sprite;
    private void Awake()
    {
        Player_RigidBody = this.GetComponent<Rigidbody2D>();
        //Player_Sprite = this.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Score++;
            Debug.Log(Score);
            collision.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            if (collision.transform.position.x - this.transform.position.x > 0)
            {
                Player_RigidBody.AddForce(new Vector2(1.0f, 1.0f), ForceMode2D.Impulse);
            }
            else
            {
                Player_RigidBody.AddForce(new Vector2(-1.0f, 1.0f), ForceMode2D.Impulse);
            }
            Health -= 10;
            if (Health > 0)
                Debug.Log($"Player Hit, Health = {Health}");
            else
            {
                gameObject.SetActive(false);
                Debug.Log("Player Dead");
            }
        }
    }
}