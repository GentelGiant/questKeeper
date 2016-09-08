
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    private GameObject Player;
    private Vector2 getPosStart, getPosEnd, touchDeltaPosition;
    private Vector3 posJigooli;
    private int manner = -1, preManner = -1;
    private float tdt;
    string str = "",zaviestr;
    public float speed;
    public float delta;
    private Quaternion rotationJigooli = Quaternion.identity;
    Animator animW;
    Animator animDeath;
    //private int preManner = -1;
    float tempcountwalk = 0;

    public GameObject posionChar, burnedChar, drownChar, mainChar;
    public float TimeToPoison;
    public float TimeToBurn;
    public GameObject magicGO;
    public GameObject panelMagic;
    private bool useMagicOnce = true;
    public Text timeInjuredTXT, txtInjured;
    private float timeInjuredf;
    private int timeInjured;

    public bool burned = false;

    public Text timeMagicTXT, txtMagic;
    public float TimeToEndMagic;
    private float timeMagicf;
    private int timeMagic;


    // public Material myM;
    public float decix, deciz;
    bool isColide = false;

    bool stopColid = false;
    bool pltMov = false;
    public bool dead = false, detectNothing = false;

    // int dirMouse = -1;
    Vector2 mousePosition;
    Vector2 middleScene;

    Vector2 beginDeltaPos;
    float lerpSpeadCorrectPos = 0.5f;

    bool corrected = false;

    private Vector3 reveleNextTile;
    private int mapPositionIndexX;
    private int mapPositionIndexY;
    public resoneDead dieBy;
    private ColliderHit colliderHit = ColliderHit.non;

    public Camera mainCamera;

    private bool oncePerTouch = true;
  
    Vector2 active_mousepos = Vector2.zero;
    float active_angle = 0.0f;
    Vector3 displacement_mod = Vector2.zero;
    Vector3 direction;

    private Vector3 posFall;

    private bool stopPlayerOnPreTile = false;

    public enum resoneDead
    {
        fall,
        poision,
        burned,
        blade,
    }

    enum ColliderHit
    {
        non,
        stable,
        blade,
        river,
        poision,
        treasure,
        fire,
    }

    static Character _instance;
    public static Character Instance
    {
        get { return _instance; }
    }
    void Awake()
    {
        _instance = this;

    }

    void Start()
    {
        //Player.GetComponentsInChildren<Material>()..mainTexture = poisonChar;


        middleScene.x = Screen.width / 2;
        middleScene.y = Screen.height / 2;
        Player = GameObject.Find("jigooli");
        reveleNextTile = Player.transform.position;
        mapPositionIndexX = 0;
        mapPositionIndexY = 5;
        //animation stop
        /* animL = GameObject.Find("Foot_Left").GetComponent<Animator>();
         animR = GameObject.Find("Foot_right").GetComponent<Animator>();        
         animL.SetBool("waL", false);
         animR.SetBool("waR", false);*/

        //Player.GetComponentsInChildren<MeshFilter>()[0].mesh = meshDrown;

        //foreach (Renderer r in Player.GetComponentsInChildren<Renderer>())
        //{
        //    r.material = myM;

        //    foreach (Material M in r.materials)
        //    {
        //        M.mainTexture = textureDrown;
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (variable.Instance.isLoad == true && dead==false )
        {
            //correctpos();
            //  scrStaticObj.posJigZ = this.transform.position.z;

            //if (isColide == true)
            {
                decix = Player.transform.position.x - (int)Player.transform.position.x;
                deciz = Player.transform.position.z - (int)Player.transform.position.z;

                if (detectNothing == false)
                {
                    if ((Input.touchCount > 0))
                    {
                        Touch touch = Input.GetTouch(0);
                        if (touch.phase == TouchPhase.Began)
                        {
                            Ray touchRay = mainCamera.ScreenPointToRay(touch.position);
                            RaycastHit[] hits = Physics.RaycastAll(touchRay);
                            foreach (RaycastHit hit in hits)
                            {
                                if (hit.collider.gameObject == gameObject)
                                {
                                    useMag();
                                }
                            }


                            beginDeltaPos = touch.position;
                        }
                        if (touch.phase == TouchPhase.Stationary)
                        {
                        }
                        if (touch.phase == TouchPhase.Ended)
                        {
                            directMove(touch);
                        }
                        if (touch.phase == TouchPhase.Moved && oncePerTouch)
                        {
                            directMove(touch);
                        }
                    }
                    else
                    {
                        {
                            if (Input.GetKey(KeyCode.Z))
                                useMag();
                            if ((Input.GetKey(KeyCode.UpArrow)) || Input.GetKey(KeyCode.W))
                            //bala
                            {
                                Animator[] animPlayer = Player.GetComponentsInChildren<Animator>();
                                for (int i = 0; i < animPlayer.Length; i++)
                                    animPlayer[i].SetBool("idle", false);

                                correctpos();
                                manner = 0;
                                rotationJigooli.eulerAngles = new Vector3(GameObject.Find("jigooli").transform.eulerAngles.x, 0, Player.transform.eulerAngles.z);
                                Player.transform.rotation = rotationJigooli;
                            }
                            else if ((Input.GetKey(KeyCode.RightArrow)) || Input.GetKey(KeyCode.D))
                            //rast
                            {
                                Animator[] animPlayer = Player.GetComponentsInChildren<Animator>();
                                for (int i = 0; i < animPlayer.Length; i++)
                                    animPlayer[i].SetBool("idle", false);

                                correctpos();
                                manner = 1;
                                rotationJigooli.eulerAngles = new Vector3(GameObject.Find("jigooli").transform.eulerAngles.x, 90, Player.transform.eulerAngles.z);
                                Player.transform.rotation = rotationJigooli;
                            }
                            //chap
                            else if ((Input.GetKey(KeyCode.LeftArrow)) || Input.GetKey(KeyCode.A))
                            {
                                Animator[] animPlayer = Player.GetComponentsInChildren<Animator>();
                                for (int i = 0; i < animPlayer.Length; i++)
                                    animPlayer[i].SetBool("idle", false);

                                correctpos();
                                manner = 3;
                                rotationJigooli.eulerAngles = new Vector3(GameObject.Find("jigooli").transform.eulerAngles.x, 270, Player.transform.eulerAngles.z);
                                Player.transform.rotation = rotationJigooli;
                            }
                            //paein
                            else if ((Input.GetKey(KeyCode.DownArrow)) || Input.GetKey(KeyCode.S))
                            {
                                Animator[] animPlayer = Player.GetComponentsInChildren<Animator>();
                                for (int i = 0; i < animPlayer.Length; i++)
                                    animPlayer[i].SetBool("idle", false);

                             //   Character.Instance.allowFollow = false;
                                correctpos();
                              //  Character.Instance.allowFollow = true;

                                manner = 2;
                                rotationJigooli.eulerAngles = new Vector3(GameObject.Find("jigooli").transform.eulerAngles.x, 180, Player.transform.eulerAngles.z);
                                Player.transform.rotation = rotationJigooli;
                            }

                            posJigooli = Player.transform.position;
                        }
                    }
                }

                if (variable.Instance.isInjuerd)
                {
                    // Debug.Break();
                    timeInjuredf -= 1 * Time.deltaTime;
                    timeInjured = (int)timeInjuredf;
                    timeInjuredTXT.text = timeInjured.ToString();
                }

                if (stopPlayerOnPreTile == false)
                {
                    switch (colliderHit)
                    {
                        case ColliderHit.blade:
                            {
                                break;
                            }
                        case ColliderHit.fire:
                            {
                                break;
                            }
                        case ColliderHit.poision:
                            {

                                break;
                            }
                        case ColliderHit.river:
                            {
                                break;
                            }
                        case ColliderHit.stable:
                            {
                                stopPlayerOnPreTile = true;
                                break;
                            }
                        case ColliderHit.treasure:
                            {
                                stopPlayerOnPreTile = true;
                                break;
                            }
                    }
                    if (manner == 0)//bala
                    {

                        posJigooli.z += speed * Time.deltaTime;
                        Player.transform.position = posJigooli;
                    }
                    else if (manner == 1)//rast
                    {
                        posJigooli.x += speed * Time.deltaTime;
                        Player.transform.position = posJigooli;
                    }
                    else if (manner == 2)//paein
                    {
                        posJigooli.z -= speed * Time.deltaTime;
                        Player.transform.position = posJigooli;
                    }
                    else if (manner == 3)//chap
                    {
                        posJigooli.x -= speed * Time.deltaTime;
                        Player.transform.position = posJigooli;
                    }

                }
            }

            if (manner == -1)//vayse
            {
                Animator[] animPlayer = Player.GetComponentsInChildren<Animator>();
                for (int i = 0; i < animPlayer.Length; i++)
                    animPlayer[i].SetBool("idle", true);

                correctpos();
            }
            if (stopPlayerOnPreTile == true && manner != preManner && manner != -1)
            {
                //manner = -1;
                stopPlayerOnPreTile = false;
                colliderHit = ColliderHit.non;
            }


            //if (reveleNextTile.z + 0.5f < Player.transform.position.z)
            //{
            //    reveleNextTile.z++;
            //    mapPositionIndexX++;
            //    if (variable.Instance.tileName[mapPositionIndexX, mapPositionIndexY] == 'n')
            //    {
            //        dieBy = resoneDead.fall;
            //        dead = true;
            //    }
            //}

            //if (reveleNextTile.x + 0.5f < Player.transform.position.x)
            //{
            //    reveleNextTile.x++;
            //    //Debug.Log(mapPositionIndexY);
            //    if (mapPositionIndexY < 9)
            //        mapPositionIndexY++;
            //    else
            //    {
            //        dieBy = resoneDead.fall;
            //        dead = true;
            //    }

            //    if (variable.Instance.tileName[mapPositionIndexX, mapPositionIndexY] == 'n')
            //    {
            //        dieBy = resoneDead.fall;
            //        dead = true;
            //    }
            //}
            //if (reveleNextTile.z - 0.5f > Player.transform.position.z)
            //{
            //    reveleNextTile.z--;
            //    if (mapPositionIndexX - 1 >= 0)
            //        mapPositionIndexX--;
            //    else
            //    {
            //        dieBy = resoneDead.fall;
            //        dead = true;
            //    }
            //    if (variable.Instance.tileName[mapPositionIndexX, mapPositionIndexY] == 'n')
            //    {
            //        dieBy = resoneDead.fall;
            //        dead = true;
            //    }
            //}
            //if (reveleNextTile.x - 0.5f > Player.transform.position.x)
            //{
            //    reveleNextTile.x--;
            //    if (mapPositionIndexY - 1 >= 0)
            //        mapPositionIndexY--;
            //    else
            //    {
            //        dieBy = resoneDead.fall;
            //        dead = true;
            //    }
            //    if (variable.Instance.tileName[mapPositionIndexX, mapPositionIndexY] == 'n')
            //    {
            //        dieBy = resoneDead.fall;
            //        dead = true;
            //    }
            //}


            switch (colliderHit)
            {
                case ColliderHit.blade:
                    {
                        dead = true;
                        dieBy = resoneDead.blade;
                        break;
                    }
                case ColliderHit.fire:
                    {
                        if (timeInjured <= 0 || burned == false)//&& variable.Instance.isInjuerd)
                        {
                            variable.Instance.isInjuerd = false;
                            panelMagic.SetActive(false);
                            if (variable.Instance.useMagic == false)
                            {
                                // variable.Instance.die = true;
                                str = "mordFired";
                            }
                            else { str = "healP"; }
                        }
                        break;
                    }
                case ColliderHit.poision:
                    {

                        if (timeInjured <= 0)//&& variable.Instance.isInjuerd)
                        {
                            variable.Instance.isInjuerd = false;
                            panelMagic.SetActive(false);
                            if (variable.Instance.useMagic == false)
                            {
                                // variable.Instance.die = true;
                                str = "mordPoison";
                            }
                            else { str = "healP"; }
                        }
                        break;
                    }
                case ColliderHit.river:
                    {
                        break;
                    }
            }



            if (variable.Instance.useMagic)
            {
                timeMagicf -= 1 * Time.deltaTime;
                timeMagic = (int)timeMagicf;
                timeMagicTXT.text = timeMagic.ToString();
                if (timeMagic <= -1)
                {
                    variable.Instance.useMagic = false;
                    panelMagic.SetActive(false);
                    magicGO.SetActive(false);
                    useMagicOnce = true;
                }
            }




        }


        if (dead == true)
        {
            if (dieBy == resoneDead.fall)
            {
                tempcountwalk = tempcountwalk + speed * Time.deltaTime;

                if (tempcountwalk >= 0.5)
                {
                    manner = -1;
                    Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                    Physics.gravity = new Vector3(0, -9.81f, 0f);
                    Player.GetComponent<Rigidbody>().useGravity = true;
                }
            }
            else
            {
                burned = false;
                Application.LoadLevel(0);
            }
        }

        //magic
        //if (variable.Instance.useMagic && timeMagic <= -1)
        //{
        //    variable.Instance.useMagic = false;
        //    panelMagic.SetActive(false);
        //}

       

        //reset
        if (GameObject.Find("jigooli").transform.position.y < -6)
        {
            //scrStaticObj.detectEmptyPlatform = false;
            burned = false;
            Application.LoadLevel(0);
        }

    }


    void OnTriggerEnter(Collider col)
    {
        str = "";
        

        if (variable.Instance.isLoad == true)
        {

            if (col.gameObject.name != "river(Clone)")
                pltMov = false;

            if (col.tag == "nothing")
            {
                detectNothing = true;
                col.enabled = false;
            }
            //if (col.tag == "nothingFall")
            //{
            //    Debug.Break();
            //    dead = true;
            //    dieBy = resoneDead.fall;
            //}
            if (col.gameObject.name == "pltPoison(Clone)")
            {
                if (variable.Instance.useMagic == false)
                {
                    colliderHit = ColliderHit.poision;
                    str = "poison";


                    panelMagic.SetActive(true);
                    variable.Instance.isInjuerd = true;
                    timeInjuredf = TimeToPoison;
                    txtInjured.text = "Time Remainig healing";

                    deactiveChar();
                    posionChar.SetActive(true);
                    Animator[] animPlayer = Player.GetComponentsInChildren<Animator>();
                    for (int i = 0; i < animPlayer.Length; i++)
                        animPlayer[i].SetBool("idle", false);
                }
            }
            if (col.gameObject.name == "treasure(Clone)")
            {
                colliderHit = ColliderHit.treasure;
                str = "treasure";
                preManner = manner;
                manner = -1;
            }
            else if (col.tag == "topBlade")
            {
                if (variable.Instance.useMagic == false)
                {
                    colliderHit = ColliderHit.blade;
                    str = "tigh mord";
                    manner = -1;
                }

            }
            else if (col.tag == "bodyBlade")
            {
                str = "stop";
                manner = -1;
            }
            else if (col.tag == "pltStable" || col.tag == "tree")
            {
                colliderHit = ColliderHit.stable;
                preManner = manner;
                manner = -1;
            }
            else if (col.tag == "fireEarth")
            {
                if (variable.Instance.useMagic == false)
                {
                    colliderHit = ColliderHit.fire;
                    str = "fire";

                    burned = true;

                    panelMagic.SetActive(true);
                    variable.Instance.isInjuerd = true;
                    timeInjuredf = TimeToBurn;
                    txtInjured.text = "Time Remainig healing";

                    deactiveChar();
                    burnedChar.SetActive(true);
                    Animator[] animPlayer = Player.GetComponentsInChildren<Animator>();
                    for (int i = 0; i < animPlayer.Length; i++)
                        animPlayer[i].SetBool("idle", false);
                }
            }
            else if (col.gameObject.name == "PartiFire")
            {
                str = "fire particle mord";
            }
            else if (col.gameObject.name == "pltFireOnOffUp(Clone)")
            {
                str = "fire particle mord";
            }
            else if (col.gameObject.name == "pltFireOnOffR(Clone)")
            {
                str = "fire particle mord";
            }
            else if (col.gameObject.name == "pltFireOnOffD(Clone)")
            {
                str = "fire particle mord";
            }
            else if (col.gameObject.name == "pltFireOnOffL(Clone)")
            {
                str = "fire particle mord";
            }

            else if (col.gameObject.name == "pltMoveable(Clone)")
            {
                pltMov = true;
            }
            else if (col.tag == "river" && pltMov == false)
            {
                colliderHit = ColliderHit.river;
                str = "river";


                deactiveChar();
                drownChar.SetActive(true);
                Animator[] animPlayer = Player.GetComponentsInChildren<Animator>();
                for (int i = 0; i < animPlayer.Length; i++)
                    animPlayer[i].SetBool("idle", false);

                if (burned == true)
                {
                    burned = false;
                }
                else
                {
                    str = "mordRiver";
                }
            }
            else if (col.gameObject.name == "pltFall(Clone)")
            {
            }
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (variable.Instance.isLoad == true)
        {

            //if (col.gameObject.name == "blade(Clone)")
            //{
            //    str = "tigh mord";
            //}


            if (col.tag == "nothing")
            {
                detectNothing = true;
                col.enabled = false;
            }

            if (col.gameObject.name == "treasure(Clone)")
            {
                colliderHit = ColliderHit.treasure;
                str = "treasure";
                preManner = manner;
                manner = -1;
            }
            else if (col.tag == "pltStable" || col.tag == "tree")
            {
                colliderHit = ColliderHit.stable;
                preManner = manner;
                manner = -1;
            }
            else if (col.tag == "fireEarth")
            {
                if (variable.Instance.useMagic == false)
                {
                    colliderHit = ColliderHit.fire;
                    str = "fire";

                    burned = true;

                    panelMagic.SetActive(true);
                    variable.Instance.isInjuerd = true;
                    timeInjuredf = TimeToBurn;
                    txtInjured.text = "Time Remainig healing";

                    deactiveChar();
                    burnedChar.SetActive(true);
                    Animator[] animPlayer = Player.GetComponentsInChildren<Animator>();
                    for (int i = 0; i < animPlayer.Length; i++)
                        animPlayer[i].SetBool("idle", false);
                }
            }
            else if (col.gameObject.name == "pltPoison(Clone)")
            {
                if (variable.Instance.useMagic == false)
                {
                    colliderHit = ColliderHit.poision;
                    str = "poison";


                    panelMagic.SetActive(true);
                    variable.Instance.isInjuerd = true;
                    timeInjuredf = TimeToPoison;
                    txtInjured.text = "Time Remainig healing";

                    deactiveChar();
                    posionChar.SetActive(true);
                    Animator[] animPlayer = Player.GetComponentsInChildren<Animator>();
                    for (int i = 0; i < animPlayer.Length; i++)
                        animPlayer[i].SetBool("idle", false);
                }
            }
        }
    }


    void correctpos()
    {
        corrected = true;
        if (decix > 0)
        {
            if (decix > 0.5)
            {
                Vector3 p = new Vector3(GameObject.Find("jigooli").transform.position.x - (decix - 0.5f), Player.transform.position.y, Player.transform.position.z);
                ///Player.transform.position = p;
                 Player.transform.position = p;  Player.transform.position = Vector3.Lerp(GameObject.Find("jigooli").transform.position, p, lerpSpeadCorrectPos);
            }
            else if (decix < 0.5)
            {
                Vector3 p = new Vector3(GameObject.Find("jigooli").transform.position.x + (0.5f - decix), Player.transform.position.y, Player.transform.position.z);
               // Player.transform.position = p;
                Player.transform.position = Vector3.Lerp(GameObject.Find("jigooli").transform.position, p, lerpSpeadCorrectPos);
            }
        }
        else if (decix < 0)
        {
            if (decix > -0.5)
            {
                Vector3 p = new Vector3(GameObject.Find("jigooli").transform.position.x + (-decix - 0.5f), Player.transform.position.y, Player.transform.position.z);
                Player.transform.position = Vector3.Lerp(GameObject.Find("jigooli").transform.position, p, lerpSpeadCorrectPos);
               // Player.transform.position = p;
            }
            else if (decix < -0.5)
            {
                Vector3 p = new Vector3(GameObject.Find("jigooli").transform.position.x + (-0.5f - decix), Player.transform.position.y, Player.transform.position.z);
               // Player.transform.position = p;
                Player.transform.position = Vector3.Lerp(GameObject.Find("jigooli").transform.position, p, lerpSpeadCorrectPos);
            }
        }
        if (deciz > 0)
        {
            if (deciz > 0.5)
            {
                Vector3 p = new Vector3(GameObject.Find("jigooli").transform.position.x, Player.transform.position.y, Player.transform.position.z - (deciz - 0.5f));
               // Player.transform.position = p;
                 Player.transform.position = Vector3.Lerp(GameObject.Find("jigooli").transform.position, p, lerpSpeadCorrectPos);
            }
            else if (deciz < 0.5)
            {
                Vector3 p = new Vector3(GameObject.Find("jigooli").transform.position.x, Player.transform.position.y, Player.transform.position.z + (0.5f - deciz));
              //  Player.transform.position = p;
                Player.transform.position = Vector3.Lerp(GameObject.Find("jigooli").transform.position, p, lerpSpeadCorrectPos);
            }
        }
        else if (decix < 0)
        {
            if (deciz > -0.5)
            {
                Vector3 p = new Vector3(GameObject.Find("jigooli").transform.position.x, Player.transform.position.y, Player.transform.position.z + (-deciz - 0.5f));
               // Player.transform.position = p;
                Player.transform.position = Vector3.Lerp(GameObject.Find("jigooli").transform.position, p, lerpSpeadCorrectPos);
            }
            else if (deciz < -0.5)
            {
                Vector3 p = new Vector3(GameObject.Find("jigooli").transform.position.x, Player.transform.position.y, Player.transform.position.z + (-0.5f - deciz));
               // Player.transform.position = p; 
                Player.transform.position = Vector3.Lerp(GameObject.Find("jigooli").transform.position, p, lerpSpeadCorrectPos);
            }
        }
        corrected = false;
    }

    void directMove(Touch touch)
    {
        oncePerTouch = true;

        touchDeltaPosition = touch.position - beginDeltaPos;
        float zavie = MathHelper.GetDegrees(touch.position, beginDeltaPos);
        zaviestr = zavie.ToString();
        //bala
        if (zavie >= 30 && zavie <= 120 && (Mathf.Abs(touchDeltaPosition.x) > delta && Mathf.Abs(touchDeltaPosition.y) > delta))
        {
            Animator[] animPlayer = Player.GetComponentsInChildren<Animator>();
            for (int i = 0; i < animPlayer.Length; i++)
                animPlayer[i].SetBool("idle", false); 
            
            correctpos();

            manner = 0;
            //tempManner = 0;
            rotationJigooli.eulerAngles = new Vector3(GameObject.Find("jigooli").transform.eulerAngles.x, 0, Player.transform.eulerAngles.z);
            Player.transform.rotation = rotationJigooli;
            //GameObject.Find("jigooli").transform.eulerAngles = new Vector3(GameObject.Find("jigooli").transform.eulerAngles.x, 0,Player.transform.eulerAngles.z);                       
        }
        //rast
        else if (((zavie < 30 && zavie >= 0) || (zavie <= -0.1f && zavie >= -60)) && (Mathf.Abs(touchDeltaPosition.x) > delta && Mathf.Abs(touchDeltaPosition.y) > delta))
        {
            Animator[] animPlayer = Player.GetComponentsInChildren<Animator>();
            for (int i = 0; i < animPlayer.Length; i++)
                animPlayer[i].SetBool("idle", false);

            correctpos();

            manner = 1;
            //tempManner = 1;
            rotationJigooli.eulerAngles = new Vector3(GameObject.Find("jigooli").transform.eulerAngles.x, 90, Player.transform.eulerAngles.z);
            Player.transform.rotation = rotationJigooli;
            //GameObject.Find("jigooli").rotation.eulerAngles = new Vector3(GameObject.Find("jigooli").transform.eulerAngles.x, 90,Player.transform.eulerAngles.z);
            //str = "becharkhRast";
        }
        //chap
        else if (((zavie > 120 && zavie <= 180) || (zavie > -180 && zavie < -160)) && (Mathf.Abs(touchDeltaPosition.x) > delta && Mathf.Abs(touchDeltaPosition.y) > delta))
        {
            Animator[] animPlayer = Player.GetComponentsInChildren<Animator>();
            for (int i = 0; i < animPlayer.Length; i++)
                animPlayer[i].SetBool("idle", false); 
            
            correctpos();

            manner = 3;
            //tempManner = 3;
            rotationJigooli.eulerAngles = new Vector3(GameObject.Find("jigooli").transform.eulerAngles.x, 270, Player.transform.eulerAngles.z);
            Player.transform.rotation = rotationJigooli;
            //GameObject.Find("jigooli").transform.eulerAngles = new Vector3(GameObject.Find("jigooli").transform.eulerAngles.x, 270,Player.transform.eulerAngles.z);

        }
        //paein
        else if (zavie >= -160 && zavie < -60 && (Mathf.Abs(touchDeltaPosition.x) > delta && Mathf.Abs(touchDeltaPosition.y) > delta))
        {
            Animator[] animPlayer = Player.GetComponentsInChildren<Animator>();
            for (int i = 0; i < animPlayer.Length; i++)
                animPlayer[i].SetBool("idle", false); 
            
            correctpos();

            manner = 2;
            //tempManner = 2;
            rotationJigooli.eulerAngles = new Vector3(GameObject.Find("jigooli").transform.eulerAngles.x, 180, Player.transform.eulerAngles.z);
            Player.transform.rotation = rotationJigooli;
            //Player.transform.eulerAngles = new Vector3(GameObject.Find("jigooli").transform.eulerAngles.x, 180,Player.transform.eulerAngles.z);
        }
        posJigooli = Player.transform.position;
    }


    void deactiveChar()
    {
        mainChar.SetActive(false);
        posionChar.SetActive(false);
        burnedChar.SetActive(false);
        drownChar.SetActive(false);
    }


    void useMag()
    {
        if (useMagicOnce)
        {
            useMagicOnce = false;
            if (variable.Instance.magic != 0)
            {
                variable.Instance.useMagic = true;

                magicGO.SetActive(true);
                panelMagic.SetActive(true);
                timeMagicf = TimeToEndMagic;
                txtMagic.text = "Time Magic Left";

                burned = false;
                variable.Instance.magic--;

                posionChar.SetActive(false);
                burnedChar.SetActive(false);
                drownChar.SetActive(false);
                mainChar.SetActive(true);
            }
        }
    }


    void OnGUI()
    {
        GUI.color = Color.white;
        GUI.Label(new Rect(0, 180, 100, 100), variable.Instance.magic + " magic");
        GUI.Label(new Rect(0, 280, 800, 100), str + "");
      //  GUI.Label(new Rect(0, 300, 800, 100), zaviestr + "");
        //  GUI.Label(new Rect(0, 220, 100, 100), mapPositionIndexX + "_" + mapPositionIndexY);
        //  if (variable.Instance.tileName != null)
        //      GUI.Label(new Rect(0, 240, 100, 100), variable.Instance.tileName[mapPositionIndexX, mapPositionIndexY] + "");

        GUI.Label(new Rect(0, 300, 100, 100), 1.0f / Time.deltaTime + "");
       // GUI.Label(new Rect(0, 300, 100, 100), manner + "");



    }
}
