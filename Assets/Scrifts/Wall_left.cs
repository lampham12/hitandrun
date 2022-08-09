using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_left : MonoBehaviour
{
    Rigidbody rg;
    private void OnTriggerEnter(Collider other)
    {
        rg = other.GetComponent<Rigidbody>();
    }
    private void OnTriggerExit(Collider other)
    {
        other.gameObject.transform.rotation = Quaternion.Slerp(other.transform.rotation, Quaternion.Euler(0, 0, 0), 50 * Time.deltaTime);
        rg.velocity = new Vector3(3.5f, 3, 0f);
        rg.isKinematic = false;
        Cameractl.CameractlIstance.rotationcamera = false;

    }
}
