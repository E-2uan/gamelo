using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class máuvàdamecủaquái : MonoBehaviour
{
    public float LuongMauHienTai;
    public float LuongMauToiDa = 10;

    //bien am thanh quai chet
    public AudioClip quaiDie;
    // Start is called before the first frame update
    void Start()
    {
        //dat luong mau khi moi bat dau 
        LuongMauHienTai = LuongMauToiDa;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Dan"))
        {
            LuongMauHienTai -= 1;

            if (LuongMauHienTai <= 0)
            {
                SoundManager.instance.PlaySoundOneShot(quaiDie);
            }
                
            //xoa nhan vat khi het mau
            if (LuongMauHienTai <= 0)
            {
                SoundManager.instance.PlaySoundOneShot(quaiDie);
                Destroy(this.gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
