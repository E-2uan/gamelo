using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerTuongTacThanhMau : MonoBehaviour
{
    public ThanhMau ThanhMau;
    public float LuongMauHienTai;
    public float LuongMauToiDa =10;

    // Start is called before the first frame update
    void Start()
    {
        //dat luong mau khi moi bat dau 
        ThanhMau.CapNhatThanhMau(LuongMauToiDa,LuongMauHienTai);
        LuongMauHienTai = LuongMauToiDa;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            LuongMauHienTai -= 1;
            ThanhMau.CapNhatThanhMau(LuongMauHienTai, LuongMauToiDa);

            //xoa nhan vat khi het mau
            if (LuongMauHienTai < 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // G
            float damagePerSecond = 1f;
            LuongMauHienTai -= damagePerSecond * Time.deltaTime;
            ThanhMau.CapNhatThanhMau(LuongMauHienTai, LuongMauToiDa);

            if (LuongMauHienTai <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}