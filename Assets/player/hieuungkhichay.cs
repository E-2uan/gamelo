using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hieuungkhichay : MonoBehaviour
{
    private Vector3 NhanDiChuyen;
    private Animator ani;

    void Start()
    {
        ani = GetComponent<Animator>();
    }
    void Update()
    {
        NhanDiChuyen.x = Input.GetAxis("Horizontal");
        ani.SetFloat("ktDiChuyen", NhanDiChuyen.sqrMagnitude);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ani.SetBool("ktMatDat", true);
        }
        else if (!Input.GetKey(KeyCode.Space))
        {
            ani.SetBool("ktMatDat", false);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ani.SetBool("Danh", true);
        }
        else if (!Input.GetKey(KeyCode.Q))
        {
            ani.SetBool("Danh", false);
        }
    }
}

