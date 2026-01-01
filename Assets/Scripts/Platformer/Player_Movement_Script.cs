using UnityEngine;
public class Player_Movement_Script : MonoBehaviour
{
    Rigidbody2D Player_RigidBody;
    Animator Player_Animator;
    SpriteRenderer Player_Sprite;
    public float Player_Speed = 2.0f;
    bool isMoving = false;
    void Awake()
    {
        Player_RigidBody = this.GetComponent<Rigidbody2D>();
        Player_Animator = this.GetComponent<Animator>();
        Player_Sprite = this.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Player_RigidBody.position += new Vector2(Player_Speed, 0.0f) * Time.deltaTime;
            Player_Sprite.flipX = false;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Player_RigidBody.position += new Vector2(-Player_Speed, 0.0f) * Time.deltaTime;
            Player_Sprite.flipX = true;
            isMoving = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) 
            && !Player_Animator.GetBool("doJump")
            && !Player_Animator.GetBool("isFalling"))
        {
            isMoving = false;
            Player_Animator.SetBool("doJump", true);
            Player_Animator.SetBool("isRunning", false);
            Player_RigidBody.AddForce(Vector3.up * 3.0f, ForceMode2D.Impulse);
        }
        if(Player_RigidBody.linearVelocityY <= -0.00001f)
        {
            isMoving = false;
            Player_Animator.SetBool("doJump", false);
            Player_Animator.SetBool("isRunning", false);
            Player_Animator.SetBool("isFalling", true);
        }
        else
        {
            Player_Animator.SetBool("isFalling", false);
        }
        if (isMoving)
        {
            Player_Animator.SetBool("isRunning", true);
        }
        else
        {
            Player_Animator.SetBool("isRunning", false);
        }
        isMoving = false;
    }
}