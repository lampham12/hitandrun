using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_1 : MonoBehaviour
{
    public static Road_1 road1;
    private List<Vector3> listvector;
    private void Awake()
    {
        road1 = this;
    }
    private void Start()
    {
       
    }
    public void listvt()
    {
        listvector = new List<Vector3>();
        foreach (Transform i in transform.GetChild(0))
        {
            listvector.Add(i.position);
        }

    }
}
