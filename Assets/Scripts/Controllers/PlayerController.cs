using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{

    public int Antibodynum { get { return antibodynum; } set { antibodynum = value; } }
    Define.Direction dir = Define.Direction.Right;
    Define.Direction lookdir = Define.Direction.Right;
    [SerializeField]
    Vector3 Movedir = new Vector3();
    [SerializeField]
    float speed = 2f;
    [SerializeField]
    float Jetpack = 2f;
    [SerializeField]
    int antibodynum = 3;


    Vector3 shootdir = new Vector3();
    float Shootdelay = 0.5f;
    float nowshoot = 0.5f;

    float antiShootdelay = 1.5f;
    float antinowshoot = 1.5f;

    Rigidbody2D myRigid2D;

    public override void Init()
    {
        Managers.Input.KeyAction -= MakeMoveMent;
        Managers.Input.KeyAction += MakeMoveMent;
        myRigid2D = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }
    protected override void Update()
    {
        base.Update();

            nowshoot += Time.deltaTime;
            antinowshoot += Time.deltaTime;

        if (Managers.Game.WillIDie(transform.position))
            Player.player.Dieing();
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

        if (State == Define.State.Ouch)
            return;


        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {

            transform.rotation = Quaternion.Euler(0, 0, 0);
            if (State != Define.State.Jumping)
                State = Define.State.Moving;
            Movedir.x = 1.0f;
            dir = Define.Direction.Right;
            lookdir = Define.Direction.Right;
            shootdir.y = 0;
            shootdir.x = 1.0f;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {

            transform.rotation = Quaternion.Euler(0, 180, 0);
            if (State != Define.State.Jumping)
                State = Define.State.Moving;
            dir = Define.Direction.Left;
            lookdir = Define.Direction.Left;
            Movedir.x = 1.0f;
            shootdir.y = 0;
            shootdir.x = -1.0f;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            Movedir.x = 0;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {

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
        }else if (Input.GetKey(KeyCode.C))
        {
            if (State == Define.State.Jumping)
            {
                // 연료사용
                myRigid2D.velocity += new Vector2(0, 1f) * Jetpack * Time.deltaTime;
                Debug.Log("I'mFlying");
            }
        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            dir = Define.Direction.Up;
            shootdir.y = 1.0f;
            shootdir.x = 0;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            dir = Define.Direction.Down;
            shootdir.y = -1.0f;
            shootdir.x = 0;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            // Gen Drill
            if ( nowshoot >= Shootdelay)
            {
                nowshoot = 0;
                GameObject obj = Managers.Resource.Instantiate("Drill");
                // Init 함수로 집어넣어야함.
                obj.transform.position = transform.position + shootdir * 0.5f;
                obj.transform.rotation = Util.SetRotation(dir);
            }
            
            //Attack // TODO 쿨다운 / 장탄 수좀 넣어야함.
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if(antibodynum <= 0)
            {
                return;
            }
            // Gen Drill
            if (antinowshoot >= antiShootdelay)
            {
                nowshoot = 0;
                GameObject obj = Managers.Resource.Instantiate("AntiBody");
                // Init 함수로 집어넣어야함.
                obj.transform.position = transform.position + shootdir * 0.5f;
                obj.GetComponent<AttackAntibody>().Init(dir, lookdir);
                antibodynum++;
            }

            //Attack // TODO 쿨다운 / 장탄 수좀 넣어야함.
        }

    }

    Animator animator;

    protected override void Onstate()
    {
        base.Onstate();
        switch (_state)
        {
            case Define.State.Idle:
                animator.Play("Idle");
                break;
            case Define.State.Jumping:
                animator.Play("Jump");
                break;
            case Define.State.Moving:
                animator.Play("Moving");
                break;
            case Define.State.Ouch:
                OnOuch();
                break;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Liquid")
        {
            Player.player.Dieing();
        }
    }


    protected override void OnOuch()
    {
        StartCoroutine("ouchevent");
    }

    IEnumerator ouchevent()
    {
        Debug.Log("Fuck");
        for (int i =0; i< 50; i++)
        {
            transform.Translate(new Vector3(-0.5f / 50f, 0));
            yield return null;
        }
        State = Define.State.Idle;
    }
}
