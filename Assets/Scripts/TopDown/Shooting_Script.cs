using NUnit.Framework.Internal;
using Unity.VisualScripting;
using UnityEngine;
public class Shooting_Script : MonoBehaviour
{
    float bulletSpeed = 6.0f;
    public GameObject Bullet;
    Vector2 Direction_Vector;
    Player_Script Movement;
    bool Shoot = false;
    int Direction = 0;
    void Awake()
    {
        Movement = GetComponent<Player_Script>();
    }
    void Update()
    {
        if (Movement.isAttacking && !Shoot)
        {
            Shoot = true;
            switch (Movement.Direction)
            {
                case 1:
                    {
                        Direction_Vector = Vector2.up;
                        Direction = 3;
                        break;
                    }
                case 2:
                    {
                        Direction_Vector = Vector2.right;
                        Direction = 2;
                        break;
                    }
                case 3:
                    {
                        Direction_Vector = Vector2.down;
                        Direction = 1;
                        break;
                    }
                case 4:
                    {
                        Direction_Vector = Vector2.left;
                        Direction = 4;
                        break;
                    }
            }
            GameObject Bullect_Obj = Instantiate(Bullet, GetComponent<Rigidbody2D>().position,
                Quaternion.Euler(0.0f, 0.0f, Direction * 90.0f));
            Bullect_Obj.AddComponent<Rigidbody2D>().linearVelocity = Direction_Vector * bulletSpeed;
            Bullect_Obj.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        else
        {
            if (!Movement.isAttacking)
                Shoot = false;
        }
    }
}