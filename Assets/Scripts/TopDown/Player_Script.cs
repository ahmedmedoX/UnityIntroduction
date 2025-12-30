using UnityEngine;

public class Player_Script : MonoBehaviour
{
    Rigidbody2D Player_RigidBody;
    Animator Player_Animator;
    public float Player_Speed = 2.0f;
    bool isMoving = false;
    bool isAttacking = false;
    void Start()
    {
        Player_RigidBody = this.GetComponent<Rigidbody2D>();
        Player_Animator = this.GetComponent<Animator>();
        Player_Animator.SetInteger("Direction", 4);
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
                Player_Animator.SetInteger("Direction", 1);
                isMoving = true;
            }
            if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && !isMoving)
            {
                Player_RigidBody.position += new Vector2(Player_Speed, 0.0f) * Time.deltaTime;
                Player_Animator.SetBool("isRunning", true);
                Player_Animator.SetInteger("Direction", 2);
                isMoving = true;
            }
            if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && !isMoving)
            {
                Player_RigidBody.position += new Vector2(0.0f, -Player_Speed) * Time.deltaTime;
                Player_Animator.SetBool("isRunning", true);
                Player_Animator.SetInteger("Direction", 3);
                isMoving = true;
            }
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !isMoving)
            {
                Player_RigidBody.position += new Vector2(-Player_Speed, 0.0f) * Time.deltaTime;
                Player_Animator.SetBool("isRunning", true);
                Player_Animator.SetInteger("Direction", 4);
                isMoving = true;
            }
            if (!isMoving)
            {
                Player_Animator.SetBool("isRunning", false);
            }
        }
    }
}