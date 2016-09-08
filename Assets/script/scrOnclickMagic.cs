//using UnityEngine;
//using System.Collections;
//using UnityEngine.UI;

//public class scrOnclickMagic : MonoBehaviour
//{
//    [SerializeField]
//    private Button MyButton = null; // assign in the editor
//    public GameObject panelMagic;
//    public Text timeMagicTXT,txtMagic;

//    public GameObject posionChar, burnedChar, drownChar, mainChar;
//    public GameObject Player;

//    public float TimeToEndMagic;
//    private float timeMagicf;
//    private int timeMagic;

//    string str;
//    //AudioSource sBtn;
//    void Start()
//    {
//        MyButton.onClick.AddListener(() => { useMag(); });
//    }

//    void Update()
//    {
      

//        //if ( variable.Instance.useMagic && timeMagic <= -1 )
//        //{
//        //    variable.Instance.useMagic = false;
//        //    panelMagic.SetActive(false);
//        //}

//        //if (variable.Instance.useMagic)
//        //{
//        //    timeMagicf -= 1 * Time.deltaTime;
//        //    timeMagic = (int)timeMagicf;
//        //    timeMagicTXT.text = timeMagic.ToString();
//        //}

//    }

//    void useMag()
//    {
//        if (variable.Instance.magic != 0)
//        {
//            variable.Instance.useMagic = true;
           
//            panelMagic.SetActive(true);
//            timeMagicf = TimeToEndMagic;
//            txtMagic.text="Time Magic Left";

//            Character.Instance.burned = false;
//            variable.Instance.magic--;

//            deactiveChar();
//            mainChar.SetActive(true);
//        }
//    }

//    void deactiveChar()
//    {
//        mainChar.SetActive(false);
//        posionChar.SetActive(false);
//        burnedChar.SetActive(false);
//        drownChar.SetActive(false);
//    }
//}