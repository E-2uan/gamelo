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
    public float ThoiGianBan = 0;
    public Animator Danh;

    public AudioClip fightClip;

    private void Start()
    {
        Danh = GetComponent<Animator>();
    }
    private void Update()
    {
        // tha phim
        if (Input.GetKey(KeyCode.Return))
        {
            ThoiGianBan += 0.05f;
            if (ThoiGianBan > 0.5)
            {
                Shoot();
                ThoiGianBan = 0;
                SoundManager.instance.PlaySoundOneShot(fightClip);
            }
        }
        else if(Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(animationShot());
            SoundManager.instance.PlaySoundOneShot(fightClip);
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
    IEnumerator animationShot()
    {
        Danh.SetBool("New Bool", true); 
        yield return new WaitForSeconds(0.5f);
        Shoot();
        Danh.SetBool("New Bool", false);
    }
}
