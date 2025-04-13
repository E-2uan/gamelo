using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ThanhMau : MonoBehaviour
{
    // Start is called before the first frame update
    public Image ThanhChuaMau;

    public void CapNhatThanhMau(float LuongMauHienTai,float LuongMauToiDa)
    {
        // da du lieu len image
        ThanhChuaMau.fillAmount = LuongMauHienTai / LuongMauToiDa;
    }

}
