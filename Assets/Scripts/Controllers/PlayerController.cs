using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{

    enum Direction
    {
        Up,
        Down,
        Right,
        Left
    }

    Direction dir = Direction.Left;
    [SerializeField]
    Vector3 Movedir = new Vector3();
    [SerializeField]
    float speed = 2f;
    [SerializeField]
    float Jetpack = 2f;

    Vector3 shootdir = new Vector3();
    float Shootdelay = 0.5f;
    float nowshoot = 0f;
    bool shooted = false;


    Rigidbody2D myRigid2D;

    public override void Init()
    {
        Managers.Input.KeyAction -= MakeMoveMent;
        Managers.Input.KeyAction += MakeMoveMent;
        myRigid2D = gameObject.GetComponent<Rigidbody2D>();
    }
    protected override void Update()
    {
        base.Update();

        if (shooted)
        {
            nowshoot += Time.deltaTime;
        }
    }

    protected override void UpdateDie()
    {

    }
    protected override void UpdateMoving() 
    {
        transform.Translate(Movedir * Time.deltaTime * speed);

        if (Movedir.x == 0 && State == Define.State.Moving)
        {
            State = Define.State.Idle;
        }
    }
    protected override void UpdateIdle() 
    { 
        
    }
    protected override void UpdateSkill() 
    { 
        
    }
    protected override void UpdateJumping()
    {
        transform.Translate(Movedir * Time.deltaTime * speed);
    }
    public void MakeMoveMent()
    {

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {

            transform.rotation = Quaternion.Euler(0, 0, 0);
            if (State != Define.State.Jumping)
                State = Define.State.Moving;
            Movedir.x = 1.0f;
            dir = Direction.Right;
            shootdir.y = 0;
            shootdir.x = 1.0f;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {

            transform.rotation = Quaternion.Euler(0, 180, 0);
            if (State != Define.State.Jumping)
                State = Define.State.Moving;
            dir = Direction.Left;
            Movedir.x = 1.0f;
            shootdir.y = 0;
            shootdir.x = -1.0f;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            Movedir.x = 0;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            dir = Direction.Up;
            shootdir.y = 1.0f;
            shootdir.x = 0;

            if (State == Define.State.Jumping)
            {
                // 연료사용
                myRigid2D.velocity += new Vector2(0, 1f) * Jetpack * Time.deltaTime;
            }
            else
            {
                myRigid2D.AddForce(new Vector2(0, 3f), ForceMode2D.Impulse);
                State = Define.State.Jumping;
            }
        }else if (Input.GetKey(KeyCode.UpArrow))
        {
            if (State == Define.State.Jumping)
            {
                // 연료사용
                myRigid2D.velocity += new Vector2(0, 1f) * Jetpack * Time.deltaTime;
                Debug.Log("I'mFlying");
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            dir = Direction.Down;
            shootdir.y = -1.0f;
            shootdir.x = 0;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            // Gen Drill
            if ( nowshoot >= Shootdelay || !shooted)
            {
                shooted = true;
                nowshoot = 0;
                GameObject obj = Managers.Resource.Instantiate("Drill");
                obj.transform.position = transform.position + shootdir;
                obj.transform.rotation = SetRotation();
            }
            
            //Attack // TODO 쿨다운 / 장탄 수좀 넣어야함.
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            if (State == Define.State.Jumping)
            {
                if (Movedir.x != 0)
                    State = Define.State.Moving;
                else
                    State = Define.State.Idle;
            }
        } 
    }

    public Quaternion SetRotation()
    {
        Quaternion q = new Quaternion();
        switch (dir)
        {
            case Direction.Up:
                q = Quaternion.Euler(0, 0, 90);
                break;
            case Direction.Down:
                q = Quaternion.Euler(0, 0, -90);
                break;
            case Direction.Right:
                q = Quaternion.Euler(0, 0, 0);
                break;
            case Direction.Left:
                q = Quaternion.Euler(0, 0, 180);
                break;
        }
        return q;
    }
}
