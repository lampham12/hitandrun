using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvController : MonoBehaviour
{
    public static LvController lvControllerIstance;
    [SerializeField]private int lv = 0;
    [SerializeField]private int index = 0;

    public void Start()
    {
        lv = 1;
        Lv();
       
    }
    public void Lv()
    {
        foreach(Transform i in transform)
        {
            index++;
            Debug.Log("kkkkkkk");
            i.transform.gameObject.SetActive(false);
            if (index == lv)
            {
                i.transform.gameObject.SetActive(true);
            }
        }
    }
    public void Win()
    {
        lv++;
    }
    

}
