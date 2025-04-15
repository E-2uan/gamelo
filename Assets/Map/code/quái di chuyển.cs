using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Unity.VisualScripting;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float distance = 5f;
    private Vector3 startPos;
    private bool movingLeft = true;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //khai bao gia tri di chuyen trai phai
        float leftBound = startPos.x + distance;
        float rightBound = startPos.x - distance; 
        if (movingLeft)
        {
            //di chuyen trai
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x < rightBound )
            { 
                movingLeft = false;
                flip();
            }
        }
        else
        {   
            //di chuyen phai
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if(transform.position.x > leftBound)
            {
                movingLeft =true;
                flip();
            }
        }
    }
    //ham dao nhan vat di chuyen nguoc lai
    void flip()
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1; // lat nguoc quai
        transform.localScale = scaler;
    }
    // quai danh nhan vat khi den gan
   

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("player"))
        {
            animator.SetTrigger("khôngđánh");
        }
        else
        {
            if (collision.gameObject.CompareTag("player"))
            {
                animator.SetTrigger("quai");
            }
        }
   }

}
