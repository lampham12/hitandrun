using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_1 : MonoBehaviour
{
    public GameObject[] point = new GameObject[8];
    public static Vector3[] pointroad = new Vector3[8];
    private void Start()
    {
        for(int i = 0; i <point.Length; i++)
        {
            pointroad[i] = point[i].transform.position;
        }
    }
}
