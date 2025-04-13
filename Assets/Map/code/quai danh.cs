using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quaidanh : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator ani;
    

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player") )
        {
            ani.SetTrigger("quai");
         
        }
    }
}
