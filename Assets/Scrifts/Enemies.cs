using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int lvenemies;
    public bool shotted;

    private void Start()
    {
        shotted= false;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            
            PlayerManager.PlayerManagerIstance.lvPlayer = PlayerManager.PlayerManagerIstance.lvPlayer+ lvenemies;
            //Destroy(gameObject);
            //foreach (Transform i in transform)
            //{
            //    i.gameObject.SetActive(false);
            //}
        }
    }

}
