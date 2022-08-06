using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.AI;

public class PlayerManager : MonoBehaviour
{
    private int distance;
    private Vector3 player;

    private int lv;
    public Text textlv;

    public float speed = 10f;
    public Camera cameramain;
    public float swipespees = 31.5f;
    private Transform localtrans;
    private Vector3 lastMouPos;
    private Vector3 mousePos;
    private Vector3 newPosfortrans;

    private bool Move = true;

    private Animator anim;

    Rigidbody rigidbody;
    NavMeshAgent agent;

    public PathType pathsystem = PathType.Linear;
    public GameObject[] pathvalGameObject = new GameObject[8];
    private Vector3[] pathval = new Vector3[8];
    public GameObject[] pavalroad2_1 = new GameObject[8];
    public GameObject[] pavalroad2_2 = new GameObject[8];


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        rigidbody = gameObject.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        localtrans = GetComponent<Transform>();
        textlv.text = "Lv " + lv.ToString();
    }
    void Update()
    {
        transform.position = new Vector3((Mathf.Clamp(transform.position.x, distance - 3.5f, distance + 3.5f)), transform.position.y, transform.position.z);
        if (MenuManager.MenuManagerIstance.GameStace && Move) 
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

        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.MoveTowards(transform.position.z, 1000, speed * Time.deltaTime));
        PlayRun();
        if (Input.GetMouseButton(0))
        {
            mousePos = cameramain.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
            float xDiff = mousePos.x - lastMouPos.x;
            newPosfortrans.x = localtrans.position.x + xDiff * Time.deltaTime * swipespees;
            newPosfortrans.y = localtrans.position.y;
            newPosfortrans.z = localtrans.position.z;
            localtrans.position = newPosfortrans/* + localtrans.forward * speed * Time.deltaTime*/;


            lastMouPos = mousePos;

        }


        if (transform.position.y >= 1f)
        {
            speed = 10f;
            anim.SetLayerWeight(1, 0f);
            anim.SetBool("IsRun", true);
            anim.SetBool("IsJump", false);
        }
        if (transform.position.y < -0.3)
        {
            gameObject.SetActive(false);
            MenuManager.MenuManagerIstance.GameStace = false;
            MenuManager.MenuManagerIstance.YouLose.gameObject.SetActive(true);
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
        if (other.transform.tag == "Lo_xo_right")
        {
            transform.position = new Vector3(transform.position.x + 3.6f, transform.position.y + 1.2f, transform.position.z);
            transform.Rotate(0, 0, 25f);
            rigidbody.isKinematic = true;


        }
        if (other.tag == "Lo_xo_left")
        {
            transform.position = new Vector3(transform.position.x + -3.6f, transform.position.y + 1.2f, transform.position.z);
            transform.Rotate(0, 0, -25f);
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
        //if (other.tag == "road_1")
        //{
        //    agent.enabled=true;
        //    Move = false;
        //    Debug.Log(other.name);
        //    Transform des;
        //    des = other.transform.GetChild(1);
        //    MoveAI(des);
        //    //Move = true;
        //}
        if (other.tag == "road_1")
        {

            MovePaval(pathvalGameObject);
        }
        if (other.tag == "road_2_1")
        {
            MovePaval(pavalroad2_1);

        }
        if (other.tag == "road_2_2")
        {
            MovePaval(pavalroad2_2);

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
    //public void MoveAI(Transform des)
    //{
    //    Debug.Log(des.localPosition);
    //    Vector3 tar = des.position;
    //    tar.y = transform.position.y;
        
    //    Debug.Log(agent.SetDestination(tar));
    //    StartCoroutine(WaitComplete());
        
    //}
    //private IEnumerator WaitComplete()
    //{
    //    yield return null;
    //    yield return new WaitUntil(() => agent.remainingDistance ==0);
    //    Debug.Log(agent.pathStatus);
    //    agent.enabled = false;
    //    Move = true;
        
    //}
    
    public void ToListVector(GameObject[] pavalpoint)
    {
        for (int i = 0; i < pathvalGameObject.Length; i++)
        {
            pathval[i] = pavalpoint[i].transform.position;
        }
    }
    public void MovePaval(GameObject[] pavalpoint)
    {
        Move = false;
        ToListVector(pavalpoint);
        rigidbody.isKinematic = true;
        transform.DOPath( pathval, 3f, pathsystem).SetEase(Ease.Linear).OnComplete(() =>
        {
            Move = true;
            rigidbody.isKinematic = false;
        });
    }

   
    
        
    
}







