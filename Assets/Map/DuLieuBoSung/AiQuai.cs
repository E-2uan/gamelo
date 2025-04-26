using UnityEngine;

public class aiQuai : MonoBehaviour
{
    public float TocDoQuai = 3f;
    public LayerMask LayerMatDat;
    public LayerMask LayerNhay;

    public Transform mucTieu;
    public Transform KiemTraDat;

    public float ktGround = 1f;
    public float LucNhay = 8f;
    public float offsetCheck = 1f;

    private Rigidbody2D rb;
    private float Huong;
    private bool DangQuayHuong = false;
    private Vector3 scaleGoc;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        scaleGoc = transform.localScale;
        Huong = (scaleGoc.x > 0f) ? -1f : 1f;
    }

    private void Update()
    {
        if (mucTieu == null) return;

        float KhoangCach = Vector2.Distance(transform.position, mucTieu.position);
        if (KhoangCach < 4.4f)
        {
            float Duoi = Mathf.Sign(mucTieu.position.x - transform.position.x);
            rb.velocity = new Vector2(Duoi * TocDoQuai, rb.velocity.y);
            transform.localScale = new Vector3(Mathf.Abs(scaleGoc.x) * (Duoi > 0f ? -1f : 1f),scaleGoc.y,scaleGoc.z);

            RaycastHit2D hitNhay = Physics2D.Raycast(KiemTraDat.position,Vector2.down,ktGround,LayerMatDat);
            if (hitNhay.collider != null && hitNhay.collider.name == "11")
                rb.velocity = new Vector2(rb.velocity.x, LucNhay);
        }
        else
        {
            rb.velocity = new Vector2(Huong * TocDoQuai, rb.velocity.y);
            Vector2 checkPoint = (Vector2)KiemTraDat.position + Vector2.right * Huong * offsetCheck;

            RaycastHit2D hitDat = Physics2D.Raycast(KiemTraDat.position, Vector2.down, ktGround,LayerMatDat);
            RaycastHit2D hitNhay = Physics2D.Raycast(KiemTraDat.position,Vector2.down,ktGround,LayerNhay);
            if (hitNhay.collider != null && hitNhay.collider.name == "12")
                rb.velocity = new Vector2(rb.velocity.x, LucNhay);

            if (hitDat.collider == false && !DangQuayHuong)
            {
                Huong *= -1f;
                DangQuayHuong = true;
            }
            else if (hitDat.collider != false)
            {
                DangQuayHuong = false;
            }

            transform.localScale = new Vector3(Mathf.Abs(scaleGoc.x) * (Huong > 0f ? -1f : 1f),scaleGoc.y,scaleGoc.z);
        }
    }
}
