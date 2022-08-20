using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool_manager : MonoBehaviour
{
    Rigidbody rg;

    [System.Serializable]
    public class Pool
    {
        public string name;
        public GameObject doituong;
        public int size;

    }

    public static Pool_manager Pool_managerInstance;
    public List<Pool> _pool;
    Dictionary<string, Queue<GameObject>> pooldictionary;
    float thoigian = 0f;

    private void Awake()
    {
        Pool_managerInstance = this;
    }
    void Start()
    {
        pooldictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in _pool)
        {
            Queue<GameObject> objectpool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.doituong);
                obj.SetActive(false);
                objectpool.Enqueue(obj);
            }
            pooldictionary.Add(pool.name, objectpool);
        }
    }
    //public void spawnpool(string name, Transform posBullet)
    //{

    //    GameObject objspam = pooldictionary[name].Dequeue();
    //    objspam.SetActive(true);
    //    objspam.transform.position = posBullet.position;
    //    rg = objspam.GetComponent<Rigidbody>();
    //    rg.AddForce(posBullet.transform.up * 1000);
    //    pooldictionary[name].Enqueue(objspam);

    //}
    public void spawnpool_enemy(string name, Transform posBullet,Vector3 hit)
        {
        if (Time.time > thoigian)
        {

            GameObject objspam = pooldictionary[name].Dequeue();
            objspam.SetActive(true);
            objspam.transform.position = posBullet.position;
            rg = objspam.GetComponent<Rigidbody>();
            objspam.transform.position = Vector3.MoveTowards(objspam.transform.position, hit, 500 * Time.deltaTime);
            rg.AddForce(posBullet.transform.forward * 2500);
            pooldictionary[name].Enqueue(objspam);
            thoigian = Time.time + 0.01f;
        }

    }

}

