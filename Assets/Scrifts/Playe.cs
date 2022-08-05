using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playe : MonoBehaviour
{
    private Transform Player;
    private Vector3 startmousePos, startPlayerPos;
    private bool movePlayer;
    [Range(0, 1)] public float speeds;
    private float velocity;
    private float speed = 8f;

    private int lv;
    public Text textlv;

    private float distance=0;
    private Vector3 player;

    private Animator anim;
    Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        Player = transform;
        //textlv.text = "Lv " + lv.ToString();
    }
    private void Update()
    {

        Player.position = new Vector3((Mathf.Clamp(Player.position.x, distance - 3.2f, distance + 3.2f)), Player.position.y, Player.position.z);
        //if (MenuManager.MenuManagerIstance.GameStace)
        MovePlayer();
        var ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 4
            ))
        {
            Debug.DrawRay(transform.position, transform.forward * 4, Color.red);
            if (hit.transform.gameObject.tag == "enemies")
            {
                anim.SetBool("IsRun", false);
                anim.SetBool("IsNem", true);
                anim.SetLayerWeight(1, 1f);
            }

        }
    }

    public void MovePlayer()
    {
        PlayRun();  
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            movePlayer = true;
            Plane newplan = new Plane(Vector3.up, 0);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (newplan.Raycast(ray, out var distance))
            {
                startmousePos = ray.GetPoint(distance);
                startPlayerPos = Player.position;
            }

        }
        else if (Input.GetMouseButtonUp(0))
            movePlayer = false;

        if (movePlayer)
        {
            Plane newplan = new Plane(Vector3.up, 0);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (newplan.Raycast(ray, out var distance))
            {
                Vector3 mouseNewPos = ray.GetPoint(distance);
                Vector3 MouseNewPos = mouseNewPos - startmousePos;
                Vector3 DerisePlayerPos = mouseNewPos + startPlayerPos;

                //DerisePlayerPos.x = Mathf.Clamp(DerisePlayerPos.x, -2.5f, 2.5f);
                Player.position = new Vector3(Mathf.SmoothDamp(Player.position.x, DerisePlayerPos.x, ref velocity, speeds), Player.position.y, Player.position.z);

            }
        }
        if (transform.position.y >= 1f)
        {
            speed = 8f;
            anim.SetLayerWeight(1, 0f);
            anim.SetBool("IsRun", true);
            anim.SetBool("IsJump", false);
        }
}

    public void PlayRun()
    {
        anim.SetBool("IsRun", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Lo_xo")
        {
            rigidbody.velocity = new Vector3(0, 8.5f, 0);
            speed = speed * 1.2f;
            Debug.Log("aaaa");
            anim.SetBool("IsJump", true);
            anim.SetBool("IsRun", false);
        }

            if (other.transform.tag == "Lo_xo_cheo")
        {
            transform.position = new Vector3(transform.position.x + 3.3f, transform.position.y + 1.5f, transform.position.z);
            transform.Rotate(0, 0, 25f);
            rigidbody.isKinematic = true;


        }
        if (other.transform.tag == "Trap_gai")
        {
            gameObject.SetActive(false);
            MenuManager.MenuManagerIstance.GameStace = false;
            MenuManager.MenuManagerIstance.YouLose.gameObject.SetActive(true);

        }
        if (other.transform.tag == "in")
        {
            Destroy(other.gameObject);
            player = transform.position;
            distance = 500;
            transform.position = new Vector3(transform.position.x + 500f, transform.position.y, transform.position.z);

        }
        if (other.tag == "out")
        {
            distance = 0;
            transform.position = player;
        }
        if (other.transform.tag == "Finish")
        {
            Debug.Log("kakakaka");

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "enemies")
        {

            lv++;
            anim.SetLayerWeight(1, 0f);
            textlv.text = "Lv " + lv.ToString();
        }

    }
}


