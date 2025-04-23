using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VatLyDan : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Kiem tra xem co phai quai khong
        /*
        enemy enemyScript = collision.GetComponent<enemy>();
        if (enemyScript != null)
        {
            //enemyScript.Die();
        }
        */

        máuvàdamecủaquái máuvàdamecủaquáiScript = collision.GetComponent<máuvàdamecủaquái>();
        if (máuvàdamecủaquáiScript != null)
        {
            máuvàdamecủaquáiScript.Die();
        }
        
        //tra dan ve 
        FindObjectOfType<ObjectPooling>().LayDanVe(gameObject);

    }

}
