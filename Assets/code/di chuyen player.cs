using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class dichuyenplayer : MonoBehaviour
{
    //khai bao 
    public float tocdo;
    public float trai_phai;

    private bool right = true;
    private Rigidbody2D rb;
    private Animator animator;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

 
    void Update()
    {
        trai_phai = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(trai_phai*tocdo,rb.velocity.y);

        //goi ham flip
        flip();
        //nhanvat tan cong
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("quai");
        }
    }
    
    void flip()
    {
        if(right && trai_phai <0 || !right && trai_phai >0 )
        {
                right = !right;
                Vector3 kich_thuoc = transform.localScale;
                kich_thuoc.x = kich_thuoc.x * -1;
                transform.localScale = kich_thuoc;

        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            animator.SetTrigger("quai");
        }
    }
}
