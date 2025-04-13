using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VatLyDan : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<ObjectPooling>().LayDanVe(gameObject);
    }

}
