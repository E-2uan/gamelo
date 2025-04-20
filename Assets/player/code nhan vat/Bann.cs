using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bann : MonoBehaviour
{
    Vector3 Vector3;
    public ObjectPooling KhoDan;
    public Transform Ban;
    public float TocDoBan = 10f;
    public float ThoiGianCan = 0.001f;
    private float ThoiGianGiu = 0f;
    private bool DangGiuPhim = false;
    private void Update()
    {
        // Khi Moi giu phim
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DangGiuPhim = true;
            ThoiGianGiu = 0f;
        }

        // trong luc giu phimm
        if (DangGiuPhim && Input.GetKey(KeyCode.Q))
        {
            ThoiGianGiu += Time.deltaTime;
        }

        // tha phim
        if (Input.GetKeyUp(KeyCode.Q))
        {
            DangGiuPhim = false;

            // ban neu du time
            if (ThoiGianGiu >= ThoiGianCan)
            {
                Shoot();
            }

            //dat lai time
            ThoiGianGiu = 0f; 
        }
    }

    void Shoot()
    {
        GameObject Dan = KhoDan.LayDan();
        Dan.transform.position = Ban.position;
        Rigidbody2D rb = Dan.GetComponent<Rigidbody2D>();
       
        // 
        if (transform.localScale.x > 0)
        {
            // 
            rb.velocity = Ban.right * TocDoBan;
        }
        else
        {
            // 
            rb.velocity = -Ban.right * TocDoBan;
        }
    }
}
