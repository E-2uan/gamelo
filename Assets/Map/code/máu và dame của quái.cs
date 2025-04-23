using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class máuvàdamecủaquái : MonoBehaviour
{
    public float LuongMauHienTai;
    public float LuongMauToiDa = 3;

    //bien am thanh quai chet
    public AudioClip quaiDie;
    public AudioClip quaiHurt;
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
            SoundManager.instance.PlaySoundOneShot(quaiHurt);
            //xoa nhan vat khi het mau
            if (LuongMauHienTai <= 0)
            {
                SoundManager.instance.PlaySoundOneShot(quaiDie);
                Destroy(this.gameObject);
            }
        }
    }
    public  void Die()
    {
        if (LuongMauHienTai <= 0)
        {
             FindObjectOfType<KillCounter>().AddKill();
        }
    }

}
