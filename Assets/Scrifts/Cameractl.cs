using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cameractl : MonoBehaviour
{
    public Transform player;
   
    void Start()
    {
       
    }
    

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0,8.3f,-7.3f);
    }
    
}
