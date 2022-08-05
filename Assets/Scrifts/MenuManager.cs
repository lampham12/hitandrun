using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public static MenuManager MenuManagerIstance;

    public bool GameStace;
    public GameObject menuElement;
    public GameObject YouLose;
    void Start()
    {
        MenuManagerIstance = this;
        GameStace = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        Debug.Log("start game");
        GameStace = true;
        menuElement.SetActive(false);
    }
    public void EndGame()
    {
        menuElement.SetActive(true);
    }
    public void Retry_btn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Active Scene : " + SceneManager.GetActiveScene().name);
    }
}
