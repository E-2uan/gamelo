using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class playerTuongTacThanhMau : MonoBehaviour
{
    public ThanhMau ThanhMau;
    public float LuongMauHienTai;
    public float LuongMauToiDa =10;
    public GameObject GameOver;

    //bien sound effects
    public AudioClip dieClip;
    public AudioClip hurtClip;

    //bien cua am thanh
    private float ThoiGianGiu = 0f;

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
            
            //am thanh mat mau
            SoundManager.instance.PlaySoundOneShot(hurtClip);
           
        }
        if (collision.gameObject.CompareTag("0"))
        {
            
            ThanhMau.CapNhatThanhMau(LuongMauHienTai=0, LuongMauToiDa);

            //xoa nhan vat khi het mau
            if (LuongMauHienTai == 0)
            {
                //am thanh bi chet
                SoundManager.instance.PlaySoundOneShot(dieClip);

                Destroy(this.gameObject);
                GameOver.SetActive(true);
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

            // tang time neu con mat mau
            ThoiGianGiu += 0.05f;

            //am thanh mat mau lien tuc
            if (ThoiGianGiu >= 1)
            {
                SoundManager.instance.PlaySoundOneShot(hurtClip);

                //dat lai time sau khi phat
                ThoiGianGiu = 0f;
            }

            if (LuongMauHienTai <= 0)
            {
                //am thanh bi chet
                SoundManager.instance.PlaySoundOneShot(dieClip);

                Destroy(this.gameObject);
                GameOver.SetActive(true);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // G
            float damagePerSecond = 1f;
            LuongMauHienTai -= damagePerSecond * Time.deltaTime;
            ThanhMau.CapNhatThanhMau(LuongMauHienTai, LuongMauToiDa);

            // tang time neu con mat mau
            ThoiGianGiu += 0.05f;

            //am thanh mat mau lien tuc
            if (ThoiGianGiu >= 1)
            {
                SoundManager.instance.PlaySoundOneShot(hurtClip);

                //dat lai time sau khi phat
                ThoiGianGiu = 0f;
            }

            if (LuongMauHienTai <= 0)
            {
                //am thanh bi chet
                SoundManager.instance.PlaySoundOneShot(dieClip);

                Destroy(this.gameObject);
                GameOver.SetActive(true);
            }
        }

    }
}