using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Action : MonoBehaviour
{
    public int speed;
    public DalogManger manager;
    
    float h;
    float v;

    bool isHorizonMove;
    Vector3 dirVec;
    GameObject scanObject;

    Rigidbody2D rigid;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = manager.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vUp = manager.isAction ? false : Input.GetButtonUp("Vertical");

        if (hDown || vUp)
            isHorizonMove = true;
        else if (vDown || hUp)
            isHorizonMove = false;
        else if(hUp || vUp)
        {
            isHorizonMove = h != 0;
        }

        //Animation

        if(anim.GetInteger("hRaw") != h)
        {
            anim.SetBool("isMoveDirection", true);
            anim.SetInteger("hRaw", (int)h);
        }
        else if(anim.GetInteger("vRaw") != v)
        {
            anim.SetBool("isMoveDirection", true);
            anim.SetInteger("vRaw", (int)v);
        }
        else
        {
            anim.SetBool("isMoveDirection", false);
        }

        //Direction()
        if (vDown && v == 1)
            dirVec = Vector3.up;
        else if (vDown && v == -1)
            dirVec = Vector3.down;
        else if (hDown && h == -1)
            dirVec = Vector3.left;
        else if (hDown && h == 1)
            dirVec = Vector3.right;

        //Scan Object
        if(Input.GetButtonDown("Jump") ) 
        {
             if (scanObject == null)
            {

            }
            else
            {
                manager.Action(scanObject);
            }
                
                
        }


    }

    void Player_Move()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * speed;
    }

    

    void FixedUpdate()
    {
        Player_Move();

        //Scene에서만 보임
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;

        
    }
}
