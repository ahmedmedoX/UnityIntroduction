using UnityEngine;
public class Player_Script : MonoBehaviour
{
    Rigidbody2D Player_RigidBody;
    Animator Player_Animator;
    float Player_Speed = 5.0f;
    bool isMoving = false;
    internal bool isAttacking = false;
    internal int Direction = 0;
    int Health = 100;
    int Score = 0;
    void Start()
    {
        Player_RigidBody = this.GetComponent<Rigidbody2D>();
        Player_Animator = this.GetComponent<Animator>();
        Direction = 4;
        Player_Animator.SetInteger("Direction", Direction);
    }
    void StopAttack()
    {
        Player_Animator.ResetTrigger("Attack");
        Player_Animator.SetTrigger("StopAttack");
        isAttacking = false;
    }
    void Update()
    {
        isMoving = false;
        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            isAttacking = true;
            Player_Animator.ResetTrigger("StopAttack");
            Player_Animator.SetTrigger("Attack");
        }
        if (!isAttacking)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !isMoving)
            {
                if (Player_RigidBody.linearVelocity.magnitude > 2.0f)
                {
                    Player_RigidBody.AddForce(new Vector2(0.0f, Player_Speed).normalized, ForceMode2D.Force);
                }
                else
                {
                    Player_RigidBody.AddForce(new Vector2(0.0f, Player_Speed), ForceMode2D.Force);
                }
                //Player_RigidBody.position += new Vector2(0.0f, Player_Speed) * Time.deltaTime;
                Player_Animator.SetBool("isRunning", true);
                Direction = 1;
                Player_Animator.SetInteger("Direction", Direction);
                isMoving = true;
            }
            if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && !isMoving)
            {
                if (Player_RigidBody.linearVelocity.magnitude > 2.0f)
                {
                    Player_RigidBody.AddForce(new Vector2(Player_Speed, 0.0f).normalized, ForceMode2D.Force);
                }
                else
                {
                    Player_RigidBody.AddForce(new Vector2(Player_Speed, 0.0f), ForceMode2D.Force);
                }
                //Player_RigidBody.position += new Vector2(Player_Speed, 0.0f) * Time.deltaTime;
                Player_Animator.SetBool("isRunning", true);
                Direction = 2;
                Player_Animator.SetInteger("Direction", Direction);
                isMoving = true;
            }
            if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && !isMoving)
            {
                if (Player_RigidBody.linearVelocity.magnitude > 2.0f)
                {
                    Player_RigidBody.AddForce(new Vector2(0.0f, -Player_Speed).normalized, ForceMode2D.Force);
                }
                else
                {
                    Player_RigidBody.AddForce(new Vector2(0.0f, -Player_Speed), ForceMode2D.Force);
                }
                //Player_RigidBody.position += new Vector2(0.0f, -Player_Speed) * Time.deltaTime;
                Player_Animator.SetBool("isRunning", true);
                Direction = 3;
                Player_Animator.SetInteger("Direction", Direction);
                isMoving = true;
            }
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !isMoving)
            {
                if (Player_RigidBody.linearVelocity.magnitude > 2.0f)
                {
                    Player_RigidBody.AddForce(new Vector2(-Player_Speed, 0.0f).normalized, ForceMode2D.Force);
                }
                else
                {
                    Player_RigidBody.AddForce(new Vector2(-Player_Speed, 0.0f), ForceMode2D.Force);
                }
                //Player_RigidBody.position += new Vector2(-Player_Speed, 0.0f) * Time.deltaTime;
                Player_Animator.SetBool("isRunning", true);
                Direction = 4;
                Player_Animator.SetInteger("Direction", Direction);
                isMoving = true;
            }
            if (!isMoving)
            {
                Player_Animator.SetBool("isRunning", false);
            }
            else
            {
                Player_RigidBody.AddForce(-Player_RigidBody.linearVelocity, ForceMode2D.Force);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Health -= 20;
            if (Health > 0)
                Debug.Log($"Player Hit, Health = {Health}");
            else
            {
                gameObject.SetActive(false);
                Debug.Log("Player Dead");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Score++;
            Destroy(collision.gameObject);
            Debug.Log($"Score: {Score}");
        }
    }
}