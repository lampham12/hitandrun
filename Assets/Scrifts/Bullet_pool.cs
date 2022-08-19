using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_pool : MonoBehaviour
{
    public float timedestroy;
    Transform vitri;

    private void OnEnable()
    {
        transform.GetComponent<Rigidbody>().WakeUp();
        Invoke("hidepullet", timedestroy);
    }
    private void hidepullet()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        transform.GetComponent<Rigidbody>().Sleep();
        CancelInvoke();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemies"))
        {
            gameObject.SetActive(false);
            Destroy(other.gameObject);

        }
        //if(other.CompareTag("hi"))
        //{

        //    gameObject.SetActive(false);
        //    Instantiate(no, vitri.position, Quaternion.identity);
        //}

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
