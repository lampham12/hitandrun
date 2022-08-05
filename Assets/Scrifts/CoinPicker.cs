using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinPicker : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textcoins;
    int coins = 0;
    private void Start()
    {
        textcoins.text = "Coins :" + coins.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "coins")
        {         
            coins++;          
            Destroy(other.gameObject);
            Debug.Log("coins" + coins);
            textcoins.text = "Coins :" + coins.ToString();
            
        }
    }
}
