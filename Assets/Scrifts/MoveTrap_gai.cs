using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrap_gai : MonoBehaviour
{
    private float speed=2.3f;
    [SerializeField] private Vector3[] positions;
    private int index = 0;


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);
        if (transform.position == positions[index])
        {
            if (index == positions.Length - 1)
                index = 0;
            else
                index++;
        }
    }
}
