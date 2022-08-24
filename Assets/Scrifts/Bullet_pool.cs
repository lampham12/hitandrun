using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_pool : MonoBehaviour
{
    Transform vitri;
    private Transform spawnPos;
    private Transform targetPos;
    private void OnEnable()
    {
    }
    private void OnDisable()
    {
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
    public void Init(Transform spawnPos, Transform targetPos)
    {
        //Debug.LogError("spawn");
        this.spawnPos = spawnPos;
        this.targetPos = targetPos;
        transform.position = spawnPos.position;
        transform.gameObject.SetActive(true);
    }
    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, Vector3.Lerp(transform.position, targetPos.transform.position, 0.5f), 0.3f);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogError("update");

        if (targetPos != null)
        {
            Move();
        }
    }
}
