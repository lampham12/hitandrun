using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_right : MonoBehaviour
{
    Rigidbody rg;
    private void OnTriggerEnter(Collider other)
    {
        rg = other.GetComponent<Rigidbody>();
    }
    private void OnTriggerExit(Collider other)
    {
        other.gameObject.transform.rotation = Quaternion.Slerp(other.transform.rotation, Quaternion.Euler(0, 0, 0), 50 * Time.deltaTime);
        //other.gameObject.transform.Rotate(0, 0, -25);
        rg.velocity= new Vector3(-3.5f, 3, 0f);
        //rg.AddForce(new Vector3(-3f, 5f, 3f));
        rg.isKinematic = false;
        Cameractl.CameractlIstance.rotationcamera = false;
        Cameractl.CameractlIstance.right = false;

    }
}
