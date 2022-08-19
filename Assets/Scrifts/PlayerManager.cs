using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.AI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager PlayerManagerIstance;
    private float distance =0;
    private Vector3 player;

    public int lvPlayer;
    public Text textlv;

    public Camera cameramain;
    public Transform Ballpos;
    private float timeball;

    public float speed ;
    public float swipespees ;
    private Transform localtrans;
    public Vector3 lastMouPos;
    private Vector3 mousePos;
    private Vector3 newPosfortrans;
    private Touch touch;
    private float speedleftright=0.014f;

    public bool Move = true;

    public Animator anim;

    Rigidbody rigidbody;

    public PathType pathsystem = PathType.Linear;
    public GameObject[] pathvalGameObject = new GameObject[8];
    private Vector3[] pathval = new Vector3[8];
    public GameObject[] pavalroad2_1 = new GameObject[8];
    public GameObject[] pavalroad2_2 = new GameObject[8];

    public bool therotation = true;
    public bool thewall =false;

    private void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        PlayerManagerIstance = this;
    }
    private void Start()
    {
        therotation = true;
        localtrans = GetComponent<Transform>();
        textlv.text = "Lv " + lvPlayer.ToString();
        thewall = false;
    }
    void Update()
    {
        transform.position = new Vector3((Mathf.Clamp(transform.position.x, distance - 3.5f, distance + 3.5f)), transform.position.y, transform.position.z);
        if (MenuManager.MenuManagerIstance.GameStace && Move)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.MoveTowards(transform.position.z, 1000, speed * Time.deltaTime));
            MovePlayer();
        }

        var ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit,12 
            ))
        {         
            Debug.DrawRay(transform.position, transform.forward * 12, Color.red);
            if (hit.transform.gameObject.tag == "enemies")
            {
                //StartCoroutine("thrownball");
                Enemies shot = hit.transform.gameObject.GetComponent<Enemies>();
                if (!shot.shotted)
                {
                    Pool_manager.Pool_managerInstance.spawnpool_enemy("bong", Ballpos,hit.point);
                    anim.SetLayerWeight(1, 1f);
                    Debug.Log("lv Player" + lvPlayer);
                    shot.shotted = true;
                }
            }
            //if(hit.transform==null) 
            //{ 
            //    anim.SetLayerWeight(1, 0f);
            //    textlv.text = "Lv " + lvPlayer.ToString();
            //    Debug.Log("ngung ban");
            //}


        }
        else
            anim.SetLayerWeight(1, 0f);

    }
    public void MovePlayer()
    {

        
        PlayRun();
        if (Input.GetMouseButton(0))
        {
            mousePos = cameramain.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 18));
            float xDiff = mousePos.x - lastMouPos.x;

            if (thewall)
            {
                newPosfortrans.x = localtrans.position.x;
            }
            else
            {
                //if (xDiff < 0.01)
                {
                    newPosfortrans.x = localtrans.position.x + xDiff * swipespees * Time.deltaTime;
                    newPosfortrans.y = localtrans.position.y;
                    newPosfortrans.z = localtrans.position.z;
                    localtrans.position = newPosfortrans/* + localtrans.forward * speed * Time.deltaTime*/;
                    // vector direct
                    //trai -a phai +a;
                    // dis lastmouse mouse;
                    //a- ;
                    //Debug.Log("e diff" + xDiff);
                    lastMouPos = mousePos;
                }

                //if (xDiff >= 0 && xDiff < 0.1f)
                //    transform.rotation = Quaternion.Euler(0, 30, 0);
                //if (xDiff < 0 && xDiff > -0.1f)
                //    transform.rotation = Quaternion.Euler(0, -30, 0);

            }

        }
        //if (!thewall)
        //{

        //    if (Input.touchCount > 0)
        //    {
        //        Debug.Log("hehehe");
        //        touch = Input.GetTouch(0);
        //        if (touch.phase == TouchPhase.Moved)
        //        {
        //            transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speedleftright, transform.position.y, transform.position.z);

        //        }

        //    }
        //}
        if (therotation == true)
        {
            if (Input.GetMouseButtonUp(0))
                transform.rotation = Quaternion.Euler(0, 0, 0);
        }

       
        if (transform.position.y < -0.2f)
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
            therotation = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
           
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.MoveTowards(transform.position.z, 1000, speed * Time.deltaTime));
            Cameractl.CameractlIstance.rotationcamera = true;
            Cameractl.CameractlIstance.right = true;
            transform.position = Vector3.Lerp(transform.position,new Vector3 (transform.position.x + 3.6f, transform.position.y + 1.2f, transform.position.z),50*Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 25f), 50f * Time.deltaTime);
            rigidbody.isKinematic = true;
            thewall = true;
            
        }
        if (other.tag == "Lo_xo_left")
        {
            therotation = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            
            Cameractl.CameractlIstance.rotationcamera = true;
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + -3.6f, transform.position.y + 1.2f, transform.position.z), 50 * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, -25f), 50f * Time.deltaTime);
            rigidbody.isKinematic = true;
            thewall = true;
            
            //transform.position = new Vector3(transform.position.x + -3.6f, transform.position.y + 1.2f, transform.position.z);
            //transform.Rotate(0, 0, -25f);
            //rigidbody.isKinematic = true;
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
            Cameractl.CameractlIstance.flash=true;
            player = transform.position;
            distance = 500;
            transform.position = new Vector3(transform.position.x + 500f, transform.position.y, transform.position.z);

        }
        if (other.tag == "out")
        {
            distance = 0;
            transform.position = player;
            Cameractl.CameractlIstance.flash = true;
        }
        if (other.transform.tag == "Finish")
        {
            Debug.Log("kakakaka");

        }        
        if (other.tag == "road_1")
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //lastMouPos = Vector3.zero;
            MovePaval(pathvalGameObject);
        }
        if (other.tag == "road_2_1")
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //lastMouPos = Vector3.zero;
            mousePos = Vector3.zero;
            MovePaval(pavalroad2_1);

        }
        if (other.tag == "road_2_2")
        { transform.rotation = Quaternion.Euler(0, 0, 0);
            //lastMouPos =Vector3.zero;
            mousePos = Vector3.zero;

            MovePaval(pavalroad2_2);

        }
        if (other.transform.tag == "enemies")
        {
            anim.SetLayerWeight(1, 0f);
            textlv.text = "Lv " + lvPlayer.ToString();
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Plane")
        {
            speed = 15f;
            anim.SetLayerWeight(1, 0f);
            anim.SetBool("IsRun", true);
            anim.SetBool("IsJump", false);
        }
    }
    
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
        transform.DOPath( pathval, 1.5f, pathsystem).SetEase(Ease.Linear).OnComplete(() =>
        {
            
            Move = true;        
            rigidbody.isKinematic = false;
        });
    }  

}







