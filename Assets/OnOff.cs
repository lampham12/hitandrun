using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff : MonoBehaviour
{
    public GameObject onimage;
    public GameObject offimage;
    public GameObject on;
    public GameObject off;
    public bool taget;
    public void Start()
    {
        taget = true;
    }
    public void OnObject()
    {
        if (taget)
        {
            Debug.Log("da vao on");
            onimage.SetActive(true);
            offimage.gameObject.SetActive(false);
            on.SetActive(true);
            off.SetActive(false);           
        }
        if (taget)
        {
            Debug.Log("da vao off");
            onimage.SetActive(false);
            offimage.gameObject.SetActive(true);
            on.SetActive(false);
            off.SetActive(true);
        }
        
    }
    public void Target()
    {
       
    }
    

}
