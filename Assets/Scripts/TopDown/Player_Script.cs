using UnityEngine;
public class Player_Script : MonoBehaviour
{
    Rigidbody2D Player_RigidBody;
    Animator Player_Animator;
    float Player_Speed = 3.0f;
    bool isMoving = false;
    internal bool isAttacking = false;
    internal int Direction = 0;
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
            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !isMoving)
            {
                Player_RigidBody.position += new Vector2(0.0f, Player_Speed) * Time.deltaTime;
                Player_Animator.SetBool("isRunning", true);
                Direction = 1;
                Player_Animator.SetInteger("Direction", Direction);
                isMoving = true;
            }
            if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && !isMoving)
            {
                Player_RigidBody.position += new Vector2(Player_Speed, 0.0f) * Time.deltaTime;
                Player_Animator.SetBool("isRunning", true);
                Direction = 2;
                Player_Animator.SetInteger("Direction", Direction);
                isMoving = true;
            }
            if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && !isMoving)
            {
                Player_RigidBody.position += new Vector2(0.0f, -Player_Speed) * Time.deltaTime;
                Player_Animator.SetBool("isRunning", true);
                Direction = 3;
                Player_Animator.SetInteger("Direction", Direction);
                isMoving = true;
            }
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !isMoving)
            {
                Player_RigidBody.position += new Vector2(-Player_Speed, 0.0f) * Time.deltaTime;
                Player_Animator.SetBool("isRunning", true);
                Direction = 4;
                Player_Animator.SetInteger("Direction", Direction);
                isMoving = true;
            }
            if (!isMoving)
            {
                Player_Animator.SetBool("isRunning", false);
            }
        }
    }
}