using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dichuyen : MonoBehaviour
{
    public float DiChuyen = 5f;
    public float LucNhay = 7f;
    public Transform KiemTraDat;
    public float BanKinhKiemTra = 0.2f;
    public LayerMask LayerMatDat;
    public Transform Dau;

    private bool DauChamDat = false;
    private Vector3 NhanDiChuyen;
    private Animator ani;
    private Rigidbody2D rb;
    private bool DangNamDat = false;

    //quyen sua nhac
    private float ThoiGianGiu = 0f;

    //Bien Sound effects
    public AudioClip jumpClip;
    public AudioClip runClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // kiem tra co dung tren dat hay khong
        DangNamDat = Physics2D.OverlapCircle(KiemTraDat.position, BanKinhKiemTra, LayerMatDat);

        //kiem tra dau co cham dat hay khong
        DauChamDat = Physics2D.OverlapCircle(Dau.position, BanKinhKiemTra, LayerMatDat);

        //nhan lenh di chuyen tu ban phim
        NhanDiChuyen.x = Input.GetAxis("Horizontal");
        //NhanDiChuyen.y = Input.GetAxis("Vertical");

        //thuc hien di chuyen theo lenh
        transform.position += NhanDiChuyen * DiChuyen * Time.deltaTime;

        //doi trang thai nhan vat khi di chuyen
        ani.SetFloat("TocDo", NhanDiChuyen.sqrMagnitude);

        // xac dinh huong nhin nhan vat
        if (NhanDiChuyen.x != 0)
        {

            // phai
            if (NhanDiChuyen.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1); 
            }
            //trai
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            // tang time neu con di chuyen
            ThoiGianGiu += 0.02f;
        }
        //phat nhac neu di chuyen
        if (NhanDiChuyen.x != 0)
        {
            if (ThoiGianGiu >= 1)
            {
                SoundManager.instance.PlaySoundOneShot(runClip);

                //dat lai time sau khi phat
                ThoiGianGiu = 0f;      
            }
        }
        // dat lai time sau khi ko di chuyen nua
        else
            ThoiGianGiu = 0f;

        // Xu ly nhay
        if (Input.GetKeyDown(KeyCode.Space) && DangNamDat && !DauChamDat)
        {
            rb.velocity = new Vector2(rb.velocity.x, LucNhay);
            ani.SetTrigger("nhay");
            SoundManager.instance.PlaySoundOneShot(jumpClip);
        }
        // cap nhat cho ani biet co dung tren dat hay ko
        ani.SetBool("matdat", DangNamDat);

        //nhanvat tan cong
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ani.SetBool("Danh", true);
        }
        else if (!Input.GetKey(KeyCode.Q))
        {
            ani.SetBool("Danh", false);
        }

    }
    //nhan vat bi thuong
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            ani.SetTrigger("BiThuong");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            ani.SetTrigger("BiThuong");
        }
    }
}
