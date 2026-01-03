using UnityEngine;
//using static UnityEditor.Searcher.SearcherWindow.Alignment;
public class Player_Movement_Script : MonoBehaviour
{
    float horizontal;
    bool isFacingRight = true;
    float Player_Speed = 3.0f;
    float Jumping_Power = 6.0f;
    Animator Player_Animator;
    Rigidbody2D Player_RigidBody;
    SpriteRenderer Player_Sprite;
    Transform groundCheck;
    public LayerMask groundLayer;
    void Awake()
    {
        groundCheck = this.transform.GetChild(0).GetComponent<Transform>();
        Player_RigidBody = this.GetComponent<Rigidbody2D>();
        Player_Animator = this.GetComponent<Animator>();
        Player_Sprite = this.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Player_Animator.SetBool("doJump", true);
            Player_Animator.SetBool("isRunning", false);
            Player_RigidBody.linearVelocity = new Vector2(Player_RigidBody.linearVelocityX, Jumping_Power);
        }
        if (IsGrounded())
        {
            if (horizontal == 1.0f || horizontal == -1.0f)
                Player_Animator.SetBool("isRunning", true);
            else
                Player_Animator.SetBool("isRunning", false);
        }
        if (!IsGrounded() && Player_RigidBody.linearVelocityY < 0.001f)
        {
            Player_Animator.SetBool("doJump", false);
            Player_Animator.SetBool("isFalling", true);
        }
        else if (!IsGrounded() && Player_RigidBody.linearVelocityY > 0.001f)
        {
            Player_Animator.SetBool("doJump", true);
            Player_Animator.SetBool("isFalling", false);
        }
        else
        {
            Player_Animator.SetBool("doJump", false);
            Player_Animator.SetBool("isFalling", false);
        }
        Flip();
    }
    private void FixedUpdate()
    {
        if (Player_RigidBody.linearVelocity.magnitude > 4.0f)
        {
            Player_RigidBody.AddForce(new Vector2(horizontal * Player_Speed, 0.0f).normalized, ForceMode2D.Force);
        }
        else
        {
            Player_RigidBody.AddForce(new Vector2(horizontal * Player_Speed, 0.0f) * 4.0f, ForceMode2D.Force);
        }
        //Player_RigidBody.linearVelocity = new Vector2(horizontal * Player_Speed, Player_RigidBody.linearVelocityY);
    }
    private void Flip()
    {
        if(isFacingRight && horizontal <0.0f || !isFacingRight && horizontal > 0.0f)
        {
            Player_Sprite.flipX = isFacingRight;
            isFacingRight = !isFacingRight;
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}