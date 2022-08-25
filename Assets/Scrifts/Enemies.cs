using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int lvenemies;
    public bool shotted;

    private void Start()
    {
        shotted = false;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Ball")
        {
            if (PlayerManager.PlayerManagerIstance.lvPlayer >= lvenemies)
                PlayerManager.PlayerManagerIstance.lvPlayer = PlayerManager.PlayerManagerIstance.lvPlayer + lvenemies;
            else
                PlayerManager.PlayerManagerIstance.lvPlayer -= 10;
            shotted = true;
        }
        if (other.gameObject.tag == "Player")
        {
            if (PlayerManager.PlayerManagerIstance.lvPlayer < lvenemies)
            {
                other.gameObject.SetActive(false);
                MenuManager.MenuManagerIstance.GameStace = false;
                MenuManager.MenuManagerIstance.YouLose.gameObject.SetActive(true);
            }
        }



    }
   
}
