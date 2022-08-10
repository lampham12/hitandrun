using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cameractl : MonoBehaviour
{
    public static Cameractl CameractlIstance;
    public Transform player;
    public bool rotationcamera;
    private Vector3 cam;
    public bool right;

    void Start()
    {
        rotationcamera = false;
        CameractlIstance = this;
        cam = Vector3.zero;
    }


    // Update is called once per frame
    void Update()
    {
        if (rotationcamera == false)
            Move_Player();
       
        else
            if (right)
            RotationTrapGai_right();
            else
            RotationTrapgai_left();
            

    }

    void Move_Player()
    {
       // 
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x+ 0,player.position.y +8.3f ,player.position.z - 9.3f), 2*Time.deltaTime); /*new Vector3(0, 8.3f,player.position.z  -9.3f);*/
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(24.64f, 0, 0), 3 * Time.deltaTime);
    }

    void RotationTrapGai_right()
    {
        
        Debug.Log("right==" + right);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), 4.0f * Time.deltaTime);
        cam = player.position + new Vector3(-1.74f, 2.68652f, -8.6017f);
        transform.position = Vector3.Lerp(transform.position, cam, 4.0f * Time.deltaTime);
    }
    void RotationTrapgai_left()
    {
        Debug.Log("right=" + right);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), 4.0f * Time.deltaTime);
        cam = player.position + new Vector3(1.74f, 2.24652f, -8.6017f);
        transform.position = Vector3.Lerp(transform.position, cam, 4.0f * Time.deltaTime);

    }
    public void Camerain()
    {
        transform.position = new Vector3(player.position.x + 0, 8.3f, player.position.z - 9.3f);
    }

}