using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class testai : MonoBehaviour
{
    public Transform des;
    NavMeshAgent agent;
    private void Awake()
    {
       agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
      if(Input.GetKeyDown(KeyCode.A))
        {
            agent.destination = des.position;
           
        }
    }
}
