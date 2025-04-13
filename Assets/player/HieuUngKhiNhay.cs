using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HieuUngKhiNhay : MonoBehaviour
{
    private Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        // nhan cac chuyen true
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ani.SetBool("kt", true);
        }
        // lien tuc cap nhat false neu khong nhan  space
        else if (!Input.GetKey(KeyCode.Space))
        {
            ani.SetBool("kt", false);
            
        }
    }
}
