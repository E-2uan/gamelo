using System.Collections;
using System.Diagnostics.Contracts;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public Transform diemDichChuyen;
    GameObject player;
    public Rigidbody2D rb;

    //tim tag cua player
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("player");
        rb = player.GetComponent<Rigidbody2D>();
    }

    //cham vao diem dich chuyen
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))//ktra co phai va player ko
        {
            if (Vector2.Distance(player.transform.position, transform.position) > 0.3f)
            {
                StartCoroutine(VaoCongDichChuyen());
                //StartCoroutine(HutVaoTamCong());
                //player.transform.position = diemDichChuyen.transform.position;
            }

        }
    }
    IEnumerator VaoCongDichChuyen()
    {
        //tat rigidbody 
        rb.simulated = false;
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(HutVaoTamCong());
        //dua player den cong con lai
        player.transform.position = diemDichChuyen.transform.position;
        yield return new WaitForSeconds(0.3f);
        //bat lai rigidbody
        rb.simulated = true;
    }

    IEnumerator HutVaoTamCong()
    {
        float thoigian = 0f;
        while (thoigian < 0.3f)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, transform.position, 4 * Time.deltaTime);
            yield return new WaitForEndOfFrame();
            thoigian += Time.deltaTime;
        }
    }
}
