using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    //tao bien chua dan(tuc la vien dan dau tien)
    public GameObject KhoDan;
    //tao bien so luong dan
    public int SoLuongDan = 10;
    //Tao bien hang doi chua dan
    private Queue<GameObject> HangDoiDan;


    private void Awake()
    {
        //tao hang doi chua dan
        HangDoiDan = new Queue<GameObject>();

        
        for(int i=0; i<SoLuongDan;i++)
        {
            //tao ra ban sao cua vien dan dau tien
            GameObject Dan = Instantiate(KhoDan);

            //an vien dan di
            Dan.SetActive(false);

            //cho vien dan vao hang doi
            HangDoiDan.Enqueue(Dan);
        }
    }

    public GameObject LayDan()
    { 
        //lay dan ra dung khi con trong hang doi
        if(HangDoiDan.Count >0)
        {
            GameObject Dan = HangDoiDan.Dequeue();
            Dan.SetActive(true);
            return Dan;
        }
        //tao hang doi moi neu ko co dan
        else
        {
            GameObject Dan = Instantiate(KhoDan);
            return Dan;
        }
   
    }

    public void LayDanVe(GameObject Dan)
    {
        //an dan di
        Dan.SetActive(false);
        // dua dan ve hang doi
        HangDoiDan.Enqueue(Dan);
    }
}
