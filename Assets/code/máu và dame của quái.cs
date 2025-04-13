using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class máuvàdamecủaquái : MonoBehaviour
{
    public float LuongMauHienTai;
    public float LuongMauToiDa = 10;

    // Start is called before the first frame update
    void Start()
    {
        //dat luong mau khi moi bat dau 
        LuongMauHienTai = LuongMauToiDa;
    }

      private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            LuongMauHienTai -= 1;       

            //xoa nhan vat khi het mau
            if (LuongMauHienTai < 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
