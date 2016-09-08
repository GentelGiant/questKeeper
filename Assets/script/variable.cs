using UnityEngine;
using System.Collections;

public class variable : MonoBehaviour
{
    public int coin = 0;
    public int gem = 0;
    public int keyCurrent = 0;
   // public int keyMax = 0;
    public int magic = 10;

    public int[] keyMax;
    public int[] NoGem;
    public int[] typeCoin;

    public bool useMagic;
    public bool isInjuerd;
    public bool die;

   // public char[,] tileName;
    public bool isLoad = false;

    public GameObject[] rewards;
    public GameObject[] blade;
    public GameObject[] stabales;

    public Texture whiteTexture;
    public Vector3 colorPltBlade;
    public GameObject[] flowers;

    public GameObject room1,room2;

   
    static variable _instance;
    public static variable Instance
    {
        get { return _instance; }
    }
    void Awake()
    {
        _instance = this;

    }

}
