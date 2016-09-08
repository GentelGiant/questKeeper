using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System;
#if UNITY_EDITOR
using UnityEditor;
using System.Collections.Generic;
#endif

public class scrIO : MonoBehaviour
{
    public TextAsset Room1;

    public TextAsset L1Echunck1, L1Echunck2, L1Echunck3, L1Echunck4, L1Echunck5, L1Echunck6, L1Echunck7, L1Echunck8, L1Echunck9, L1Echunck10;
    public TextAsset L1Nchunck1, L1Nchunck2, L1Nchunck3, L1Nchunck4, L1Nchunck5, L1Nchunck6, L1Nchunck7, L1Nchunck8, L1Nchunck9, L1Nchunck10;
    public TextAsset L1Hchunck1, L1Hchunck2, L1Hchunck3, L1Hchunck4, L1Hchunck5, L1Hchunck6, L1Hchunck7, L1Hchunck8, L1Hchunck9, L1Hchunck10;
 

    public  TextAsset L1Echunck1min, L1Echunck2min, L1Echunck3min, L1Echunck4min, L1Echunck5min, L1Echunck6min, L1Echunck7min, L1Echunck8min,L1Echunck9min, L1Echunck10min;
    public TextAsset L1Echunck1nil, L1Echunck2nil, L1Echunck3nil, L1Echunck4nil, L1Echunck5nil, L1Echunck6nil, L1Echunck7nil, L1Echunck8nil, L1Echunck9nil, L1Echunck10nil;
    public TextAsset L1Nchunck1min, L1Nchunck2min, L1Nchunck3min, L1Nchunck4min, L1Nchunck5min, L1Nchunck6min, L1Nchunck7min, L1Nchunck8min,L1Nchunck9min, L1Nchunck10min;
    public TextAsset L1Nchunck1nil, L1Nchunck2nil, L1Nchunck3nil, L1Nchunck4nil, L1Nchunck5nil, L1Nchunck6nil, L1Nchunck7nil, L1Nchunck8nil, L1Nchunck9nil, L1Nchunck10nil;
    public TextAsset L1Hchunck1min, L1Hchunck2min, L1Hchunck3min, L1Hchunck4min, L1Hchunck5min, L1Hchunck6min, L1Hchunck7min, L1Hchunck8min, L1Hchunck9min, L1Hchunck10min;
    public TextAsset L1Hchunck1nil, L1Hchunck2nil, L1Hchunck3nil, L1Hchunck4nil, L1Hchunck5nil, L1Hchunck6nil, L1Hchunck7nil, L1Hchunck8nil, L1Hchunck9nil, L1Hchunck10nil;


     
    private GameObject earth,nothing,earthFirst, treasure, tree, blade, pltFall, pltMoveRL, pltPoison,pltFire, river, pltFireOnOffD, pltFireOnOffL, pltFireOnOffR, pltFireOnOffUp;

    private float xOffset = 0.0f,preOffset=0.0f;//, xOffset2=-28;
    private float zOffset = 1.0f;
    private float distanceBetweenTiles = 1f;
    float x, z;
    GameObject[] earths,falls;

    public bool manual;
    private int column=10;
    int rowH;
    int rowN;
    int countChunk = 5;

    string easyChunk = "", normalChunk = "", hardChunk = "";

   // private char[,] scrStaticObj.tileName;
   // private Vector2[,] tilePosition;

    //private char[,] tileNameE;
    //private char[,] tileNameN;
    //private char[,] tileNameH;

    private int index = 0;
    private chunk chunkCurrent;

    private int countKeys=0, countGems=0;
    private bool isTreeAgain = false;

    private System.Collections.Generic.List<GameObject> treasurs = new System.Collections.Generic.List<GameObject>();
    private System.Collections.Generic.List<float> treasursZoffset = new System.Collections.Generic.List<float>();


    enum chunk
    {
        easy,
        normal,
        hard,
    }

    void Awake()
    {
        variable b = new variable();

        earthFirst = GameObject.Find("earthFirst");
        earth = (GameObject)(Resources.Load("prefab/earth"));
        nothing = (GameObject)(Resources.Load("prefab/nothing"));
        treasure = (GameObject)(Resources.Load("prefab/treasure/treasure"));
        tree = (GameObject)(Resources.Load("prefab/tree"));
        blade = (GameObject)(Resources.Load("prefab/hazard/blade"));
        pltFall = (GameObject)(Resources.Load("prefab/hazard/pltFall"));
        pltMoveRL = (GameObject)(Resources.Load("prefab/hazard/pltMoveRL"));
        pltPoison = (GameObject)(Resources.Load("prefab/hazard/pltPoison"));
        pltFire = (GameObject)(Resources.Load("prefab/hazard/pltFire"));
        river = (GameObject)(Resources.Load("prefab/hazard/river"));
        pltFireOnOffD = (GameObject)(Resources.Load("prefab/hazard/fire/pltFireOnOffD"));
        pltFireOnOffL = (GameObject)(Resources.Load("prefab/hazard/fire/pltFireOnOffL"));
        pltFireOnOffR = (GameObject)(Resources.Load("prefab/hazard/fire/pltFireOnOffR"));
        pltFireOnOffUp = (GameObject)(Resources.Load("prefab/hazard/fire/pltFireOnOffUp"));

        easyChunk += Room1 + "_";

    }


    void Start()
    {
        x = earthFirst.transform.position.x;
        z = 6.5f;
        //Debug.Log(manual);

        if (manual == true)
        {
            #region easy
            //*********************** easy
            for (int i = 0; i < countChunk; i++)
            {
                int ran = UnityEngine.Random.Range(1, 20);
               // Debug.Log(ran);
                switch (ran)
                {
                    case 1:
                        {
                            easyChunk += L1Echunck1min.text + "_";
                        }
                        break;
                    case 2:
                        {
                            easyChunk += L1Echunck2min.text + "_";
                        }
                        break;
                    case 3:
                        {
                            easyChunk += L1Echunck3min.text + "_";
                        }
                        break;
                    case 4:
                        {
                            easyChunk += L1Echunck4min.text + "_";
                        }
                        break;
                    case 5:
                        {
                            easyChunk += L1Echunck5min.text + "_";
                        }
                        break;
                    case 6:
                        {
                            easyChunk += L1Echunck6min.text + "_";
                        }
                        break;
                    case 7:
                        {
                            easyChunk += L1Echunck7min.text + "_";
                        }
                        break;
                    case 8:
                        {
                            easyChunk += L1Echunck8min.text + "_";
                        }
                        break;
                    case 9:
                        {
                            easyChunk += L1Echunck9min.text + "_";
                        }
                        break;
                    case 10:
                        {
                            easyChunk += L1Echunck10min.text + "_";
                        }
                        break;
                    case 11:
                        {
                            easyChunk += L1Echunck1nil.text + "_";
                        }
                        break;
                    case 12:
                        {
                            easyChunk += L1Echunck2nil.text + "_";
                        }
                        break;
                    case 13:
                        {
                            easyChunk += L1Echunck3nil.text + "_";
                        }
                        break;
                    case 14:
                        {
                            easyChunk += L1Echunck4nil.text + "_";
                        }
                        break;
                    case 15:
                        {
                            easyChunk += L1Echunck5nil.text + "_";
                        }
                        break;
                    case 16:
                        {
                            easyChunk += L1Echunck6nil.text + "_";
                        }
                        break;
                    case 17:
                        {
                            easyChunk += L1Echunck7nil.text + "_";
                        }
                        break;
                    case 18:
                        {
                            easyChunk += L1Echunck8nil.text + "_";
                        }
                        break;
                    case 19:
                        {
                            easyChunk += L1Echunck9nil.text + "_";
                        }
                        break;
                    case 20:
                        {
                            easyChunk += L1Echunck10nil.text + "_";
                        }
                        break;

                    default:
                        easyChunk += L1Echunck1min.text + "_";
                        break;
                }
            }
            #endregion
            #region normal
            //*********************** normal
            for (int i = 0; i < countChunk; i++)
            {
                int ran = UnityEngine.Random.Range(1, 20);
                //Debug.Log(ran);
                switch (ran)
                {
                    case 1:
                        {
                            normalChunk += L1Nchunck1min.text + "_";
                        }
                        break;
                    case 2:
                        {
                            normalChunk += L1Nchunck2min.text + "_";
                        }
                        break;
                    case 3:
                        {
                            normalChunk += L1Nchunck3min.text + "_";
                        }
                        break;
                    case 4:
                        {
                            normalChunk += L1Nchunck4min.text + "_";
                        }
                        break;
                    case 5:
                        {
                            normalChunk += L1Nchunck5min.text + "_";
                        }
                        break;
                    case 6:
                        {
                            normalChunk += L1Nchunck6min.text + "_";
                        }
                        break;
                    case 7:
                        {
                            normalChunk += L1Nchunck7min.text + "_";
                        }
                        break;
                    case 8:
                        {
                            normalChunk += L1Nchunck8min.text + "_";
                        }
                        break;
                    case 9:
                        {
                            normalChunk += L1Nchunck9min.text + "_";
                        }
                        break;
                    case 10:
                        {
                            normalChunk += L1Nchunck10min.text + "_";
                        }
                        break;
                    case 11:
                        {
                            normalChunk += L1Nchunck1nil.text + "_";
                        }
                        break;
                    case 12:
                        {
                            normalChunk += L1Nchunck2nil.text + "_";
                        }
                        break;
                    case 13:
                        {
                            normalChunk += L1Nchunck3nil.text + "_";
                        }
                        break;
                    case 14:
                        {
                            normalChunk += L1Nchunck4nil.text + "_";
                        }
                        break;
                    case 15:
                        {
                            normalChunk += L1Nchunck5nil.text + "_";
                        }
                        break;
                    case 16:
                        {
                            normalChunk += L1Nchunck6nil.text + "_";
                        }
                        break;
                    case 17:
                        {
                            normalChunk += L1Nchunck7nil.text + "_";
                        }
                        break;
                    case 18:
                        {
                            normalChunk += L1Nchunck8nil.text + "_";
                        }
                        break;
                    case 19:
                        {
                            normalChunk += L1Nchunck9nil.text + "_";
                        }
                        break;
                    case 20:
                        {
                            normalChunk += L1Nchunck10nil.text + "_";
                        }
                        break;

                    default:
                        normalChunk += L1Nchunck1min.text + "_";
                        break;
                }
            }
            #endregion
            #region hard
            //*********************** normal
            for (int i = 0; i < countChunk; i++)
            {
                int ran = UnityEngine.Random.Range(1, 20);
                //Debug.Log(ran);
                switch (ran)
                {
                    case 1:
                        {
                            hardChunk += L1Hchunck1min.text + "_";
                        }
                        break;
                    case 2:
                        {
                            hardChunk += L1Hchunck2min.text + "_";
                        }
                        break;
                    case 3:
                        {
                            hardChunk += L1Hchunck3min.text + "_";
                        }
                        break;
                    case 4:
                        {
                            hardChunk += L1Hchunck4min.text + "_";
                        }
                        break;
                    case 5:
                        {
                            hardChunk += L1Hchunck5min.text + "_";
                        }
                        break;
                    case 6:
                        {
                            hardChunk += L1Hchunck6min.text + "_";
                        }
                        break;
                    case 7:
                        {
                            hardChunk += L1Hchunck7min.text + "_";
                        }
                        break;
                    case 8:
                        {
                            hardChunk += L1Hchunck8min.text + "_";
                        }
                        break;
                    case 9:
                        {
                            hardChunk += L1Hchunck9min.text + "_";
                        }
                        break;
                    case 10:
                        {
                            hardChunk += L1Hchunck10min.text + "_";
                        }
                        break;
                    case 11:
                        {
                            hardChunk += L1Hchunck1nil.text + "_";
                        }
                        break;
                    case 12:
                        {
                            hardChunk += L1Hchunck2nil.text + "_";
                        }
                        break;
                    case 13:
                        {
                            hardChunk += L1Hchunck3nil.text + "_";
                        }
                        break;
                    case 14:
                        {
                            hardChunk += L1Hchunck4nil.text + "_";
                        }
                        break;
                    case 15:
                        {
                            hardChunk += L1Hchunck5nil.text + "_";
                        }
                        break;
                    case 16:
                        {
                            hardChunk += L1Hchunck6nil.text + "_";
                        }
                        break;
                    case 17:
                        {
                            hardChunk += L1Hchunck7nil.text + "_";
                        }
                        break;
                    case 18:
                        {
                            hardChunk += L1Hchunck8nil.text + "_";
                        }
                        break;
                    case 19:
                        {
                            hardChunk += L1Hchunck9nil.text + "_";
                        }
                        break;
                    case 20:
                        {
                            hardChunk += L1Hchunck10nil.text + "_";
                        }
                        break;

                    default:
                        hardChunk += L1Hchunck1min.text + "_";
                        break;
                }
            }
            #endregion

        }
        else
        {
            easyChunk = Room1 + "_" + L1Echunck1.text + "_" + L1Echunck2.text + "_" + L1Echunck3.text + "_" + L1Echunck4.text + "_" + L1Echunck5.text + "_" + L1Echunck6.text + "_" + L1Echunck7.text + "_" + L1Echunck8.text + "_" + L1Echunck9.text + "_" + L1Echunck10.text + "_" + Room1 + "_";
        }

        //zOffset = 0;
        #region easy file read
        //textFile = Resources.Load("Language_files/testfile") as TextAsset;
        chunkCurrent = chunk.easy;
        string[] linesFromfile = easyChunk.Split("_"[0]);
        int rowE = linesFromfile.Length-1;
        // tileNameE = new char[rowE, column];
         foreach (string ln in linesFromfile)
         {
             //Debug.Log(ln);
             char[] linetxt = ln.ToCharArray();
             generateObj(linetxt);
             zOffset += distanceBetweenTiles;
             xOffset = 0.0f;
             index++;
         }
        index = 0;
        zOffset -= distanceBetweenTiles;
        #endregion

      

        if (manual == true)
        {
           // Debug.Log("nabayad biad");

            #region normal file read
            chunkCurrent = chunk.normal;
            linesFromfile = normalChunk.Split("_"[0]);
            rowN = linesFromfile.Length - 1;
            // int columnN = (easyChunk.Length / rowN) - 1;
            //tileNameN = new char[rowN, column];

            foreach (string ln in linesFromfile)
            {
                char[] linetxt = ln.ToCharArray();
                generateObj(linetxt);
                zOffset += distanceBetweenTiles;
                xOffset = 0.0f;
                index++;
            }
            index = 0;
            zOffset -= distanceBetweenTiles;
            #endregion

           

            #region hard file read
            chunkCurrent = chunk.hard;
            linesFromfile = hardChunk.Split("_"[0]);
            rowH = linesFromfile.Length - 1;
            // int columnH = (easyChunk.Length / rowH) - 1;
            //tileNameH = new char[rowH, column];

            foreach (string ln in linesFromfile)
            {
                // Debug.Log(ln);
                char[] linetxt = ln.ToCharArray();
                generateObj(linetxt);
                zOffset += distanceBetweenTiles;
                xOffset = 0.0f;
                index++;
            }
            index = 0;
            #endregion
            //  Debug.Log(row);
            //   Debug.Log(column);
        }
         int rowMain;
         // if (manual == true)
         // {
         //     //Debug.Log("nabayad biad");
         //     rowMain = rowE + rowH + rowN;
         //     //Debug.Log(rowE);
         //     //Debug.Log(rowN);
         //     //Debug.Log(rowH);
         //     variable.Instance.tileName = new char[rowMain, column];
         //     int indexi = 0, indexj = 0;

         //     // Debug.Log(row);
         //     //  Debug.Log(column);
         //     for (int i = 0; i < rowE; i++)
         //     {
         //         for (int j = 0; j < column; j++)
         //         {
         //             if (indexi < rowE)
         //             {
         //                 //Debug.Log(indexi);
         //                 //Debug.Log(indexj);
         //                 variable.Instance.tileName[indexi, indexj] = tileNameE[i, j];

         //             }
         //             indexj++;
         //         }
         //         indexj = 0;
         //         indexi++;
         //     }
         //     //Debug.Log(rowE);
         //    // Debug.Log(rowE + rowN);
         //   //  Debug.Log(rowMain);
         //     // indexi = 0; indexj = 0;
         //     for (int i = 0; i < rowN; i++)
         //     {
         //         for (int j = 0; j < column; j++)
         //         {
         //             if (indexi >= rowE && indexi < rowE + rowN)
         //                 variable.Instance.tileName[indexi, indexj] = tileNameN[i, j];
         //             indexj++;
         //         }
         //         indexj = 0;
         //         indexi++;
         //     }
         //     //   indexi = 0; indexj = 0;

         //     for (int i = 0; i < rowH; i++)
         //     {
         //         for (int j = 0; j < column; j++)
         //         {
         //             if (indexi >= rowE + rowN && indexi < rowMain)
         //                 variable.Instance.tileName[indexi, indexj] = tileNameH[i, j];
         //             indexj++;
         //         }
         //         indexj = 0;
         //         indexi++;
         //     }
         //     //indexi = 0; indexj = 0;
         // }
         //else
         //{
         //     rowMain = rowE;
         //     variable.Instance.tileName = new char[rowMain, column];
         //     int indexi = 0, indexj = 0;
         //     for (int i = 0; i < rowE; i++)
         //     {
         //         for (int j = 0; j < column; j++)
         //         {
         //             if (indexi < 100)
         //             {
         //                 //Debug.Log(indexi);
         //                 //Debug.Log(indexj);
         //                 variable.Instance.tileName[indexi, indexj] = tileNameE[i, j];

         //             }
         //             indexj++;
         //         }
         //         indexj = 0;
         //         indexi++;
         //     }
         //}

         index = 0;


       //  Debug.Log(zOffset+distanceBetweenTiles);

         Vector3 pos = variable.Instance.room1.transform.position;
         pos.z = zOffset+distanceBetweenTiles;
          variable.Instance.room2.transform.position = pos;


         fillTreasure();

         variable.Instance.isLoad = true;
    }

    void fillTreasure()
    {

        for (int i = 0; i < variable.Instance.NoGem[0]; i++)
        {
            int ran = UnityEngine.Random.Range(0, treasurs.Count);
            treasurs[ran].tag = "gem";

            GameObject rew = Instantiate(variable.Instance.rewards[0], treasurs[ran].transform.position, Quaternion.identity) as GameObject;
            rew.transform.SetParent(treasurs[ran].transform, true);

            treasurs.RemoveAt(ran);
        }

        for (int i = 0; i < variable.Instance.keyMax[0]; i++)
        {
            int ran = UnityEngine.Random.Range(0, treasurs.Count);
            treasurs[ran].tag = "key";

            GameObject rew = Instantiate(variable.Instance.rewards[2], treasurs[ran].transform.position, Quaternion.identity) as GameObject;
            rew.transform.SetParent(treasurs[ran].transform, true);

            treasurs.RemoveAt(ran);
        }
       

         for (int i = 0; i < treasurs.Count; i++)
        {
            if (treasursZoffset[i] < 30)
            {
                int ranTypeCoin = UnityEngine.Random.Range(0, 5);
                if (ranTypeCoin == 0 || ranTypeCoin == 1)
                    treasurs[i].tag = "c1";
                else if (ranTypeCoin == 2 || ranTypeCoin == 3)
                    treasurs[i].tag = "c2";
                else if (ranTypeCoin == 4 )
                    treasurs[i].tag = "c3";  
            }
            else if (treasursZoffset[i] >= 30 && treasursZoffset[i] < 60)
                {
                    int ranTypeCoin = UnityEngine.Random.Range(0, 5);
                    if (ranTypeCoin == 0 || ranTypeCoin == 1)
                        treasurs[i].tag = "c3";
                    else if (ranTypeCoin == 2 || ranTypeCoin == 3)
                        treasurs[i].tag = "c4";
                    else if (ranTypeCoin == 4)
                        treasurs[i].tag = "c5";
                }
            else if (treasursZoffset[i] >= 60)
            {
                int ranTypeCoin = UnityEngine.Random.Range(0, 5);
                if (ranTypeCoin == 0 || ranTypeCoin == 1)
                    treasurs[i].tag = "c5";
                else if (ranTypeCoin == 2 || ranTypeCoin == 3)
                    treasurs[i].tag = "c6";
                else if (ranTypeCoin == 4)
                    treasurs[i].tag = "c7";
            }

            GameObject rew = Instantiate(variable.Instance.rewards[1], treasurs[i].transform.position, Quaternion.identity) as GameObject;
            rew.transform.SetParent(treasurs[i].transform, true);

        }




        

    }


    void generateObj(char[] line)
    {
       // Debug.Log(index);
        for (int i = 0; i < line.Length; i++)
        {
            //Debug.Log(line.Length);
            if (line[i] == 'e')
            {
                //str += "earth";
                GameObject er= Instantiate(earth, new Vector3(x + xOffset, earth.transform.position.y, z + zOffset), Quaternion.identity) as GameObject;
                
                Color col = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0.8f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
                er.GetComponentsInChildren<Renderer>()[0].material.color = col;
                if (zOffset > 10)
                {
                    int ran = UnityEngine.Random.Range(0, variable.Instance.flowers.Length + 4);
                    if (ran < variable.Instance.flowers.Length)
                    {
                        GameObject flow = Instantiate(variable.Instance.flowers[ran], new Vector3(x + xOffset, variable.Instance.flowers[ran].transform.position.y, z + zOffset), Quaternion.identity) as GameObject;
                        flow.transform.SetParent(er.transform, true);
                    }
                }
                if (zOffset < 10)
                {
                    er.GetComponentsInChildren<Renderer>()[0].material.mainTexture = variable.Instance.whiteTexture;
                    if (xOffset >= 2 && xOffset < 8 && zOffset >= 2 && zOffset < 8)
                        er.GetComponentsInChildren<Renderer>()[0].material.color = new Color(0.815f, 0.717f, 0.807f, 1);
                    else
                        er.GetComponentsInChildren<Renderer>()[0].material.color = new Color(0.466f, 0.392f, 0.313f, 1);

                    //er.GetComponentsInChildren<MeshRenderer>()[0].enabled = false;
                    er.GetComponentsInChildren<MeshRenderer>()[1].enabled = false;
                }

            }
            //else if (line[i] == 'w')
            //{
            //    //str += "wood";
            //    Instantiate(tree, new Vector3(x + xOffset, tree.transform.position.y, z + zOffset), Quaternion.identity);
            //    GameObject er = Instantiate(earth, new Vector3(x + xOffset, earth.transform.position.y, z + zOffset), Quaternion.identity) as GameObject;
            //}
            else if (line[i] == 's')
            {
                //str += "stable";
                int ran = UnityEngine.Random.Range(0, variable.Instance.stabales.Length);
                if (isTreeAgain == true)
                {
                    isTreeAgain = false;
                    ran = variable.Instance.stabales.Length - 2;
                }

                if (ran != variable.Instance.stabales.Length - 1 && ran != variable.Instance.stabales.Length - 2)
                    isTreeAgain = true;
              //  preOffset = xOffset;
                Vector3 posGenerate=new Vector3(x + xOffset, variable.Instance.stabales[ran].transform.position.y,z + zOffset);

                 if (variable.Instance.stabales[ran].tag == "tree")
                 {
                     Vector3 dir = new Vector3(0, 0, 1f);
                      if (checkRayTree(posGenerate, dir))
                          ran = variable.Instance.stabales.Length - 2;
                 }
                 if (variable.Instance.stabales[ran].tag == "tree")
                 {
                     Vector3 dir = new Vector3(0, 0, -1f);
                     if (checkRayTree(posGenerate, dir))
                         ran = variable.Instance.stabales.Length - 2;
                 }
               

               // Debug.Log(ran);
                 GameObject stable= Instantiate(variable.Instance.stabales[ran], new Vector3(x + xOffset, variable.Instance.stabales[ran].transform.position.y, z + zOffset), Quaternion.identity)as GameObject;
                 GameObject er = Instantiate(earth, new Vector3(x + xOffset, earth.transform.position.y, z + zOffset), Quaternion.identity) as GameObject;
                 if (ran == 3 || ran == 4)
                 {
                     int ranF = UnityEngine.Random.Range(0, variable.Instance.flowers.Length + 4);
                     if (ranF < variable.Instance.flowers.Length)
                     {
                         GameObject flow = Instantiate(variable.Instance.flowers[ranF], new Vector3(x + xOffset, variable.Instance.flowers[ranF].transform.position.y + 0.4f, z + zOffset), Quaternion.identity) as GameObject;
                         flow.transform.SetParent(er.transform, true);
                     }
                 }
            
            }
            else if (line[i] == 'b')
            {
                // str += "blade";
                int ran = UnityEngine.Random.Range(0, variable.Instance.blade.Length);
                blade = variable.Instance.blade[ran];

                GameObject bladeObj=Instantiate(blade, new Vector3(x + xOffset, blade.transform.position.y, z + zOffset), Quaternion.identity)as GameObject;
                GameObject er = Instantiate(earth, new Vector3(x + xOffset, earth.transform.position.y, z + zOffset), Quaternion.identity) as GameObject;
              
                Color col = new Color(variable.Instance.colorPltBlade.x, variable.Instance.colorPltBlade.y, variable.Instance.colorPltBlade.z);
                er.GetComponentsInChildren<Renderer>()[0].material.mainTexture = variable.Instance.whiteTexture;
                er.GetComponentsInChildren<Renderer>()[0].material.color = col;
          
              //  scrStaticObj.tileName[index, i] = 'b';
             //   scrStaticObj.tilePosition[index, i] = new Vector2(x + xOffset, z + zOffset);
            }
            else if (line[i] == 'p')
            {
                //str += "poi";
                GameObject poison = Instantiate(pltPoison, new Vector3(x + xOffset, pltPoison.transform.position.y, z + zOffset), Quaternion.identity) as GameObject;
                GameObject er = Instantiate(earth, new Vector3(x + xOffset, earth.transform.position.y, z + zOffset), Quaternion.identity) as GameObject;
              
            //    scrStaticObj.tileName[index, i] = 'p';
            //    scrStaticObj.tilePosition[index, i] = new Vector2(x + xOffset, z + zOffset);
            }
            else if (line[i] == 'f')
            {
                //str += "fire";
                GameObject fire = Instantiate(pltFire, new Vector3(x + xOffset, pltFire.transform.position.y, z + zOffset), Quaternion.identity) as GameObject;
                GameObject er = Instantiate(earth, new Vector3(x + xOffset, earth.transform.position.y, z + zOffset), Quaternion.identity) as GameObject;
              
             //   scrStaticObj.tileName[index, i] = 'f';
             //   scrStaticObj.tilePosition[index, i] = new Vector2(x + xOffset, z + zOffset);
            }
            else if (line[i] == 'u')
            {
                Instantiate(pltFall, new Vector3(x + xOffset, pltFall.transform.position.y, z + zOffset), Quaternion.identity);
             //   scrStaticObj.tileName[index, i] = 'u';
             //   scrStaticObj.tilePosition[index, i] = new Vector2(x + xOffset, z + zOffset);
            }
            else if (line[i] == 'm')
            {
                Instantiate(pltMoveRL, new Vector3(x + xOffset, pltMoveRL.transform.position.y, z + zOffset), Quaternion.identity);
            //    scrStaticObj.tileName[index, i] = 'm';
             //   scrStaticObj.tilePosition[index, i] = new Vector2(x + xOffset, z + zOffset);
            }
            else if (line[i] == 'r')
            {
                Instantiate(river, new Vector3(x + xOffset + 4.5f, river.transform.position.y, z + zOffset), Quaternion.identity);
            //    scrStaticObj.tileName[index, i] = 'r';
            //    scrStaticObj.tilePosition[index, i] = new Vector2(x + xOffset, z + zOffset);
            }
            else if (line[i] == '1')
            {
                //str += "todei";
                Instantiate(pltFireOnOffUp, new Vector3(x + xOffset, pltFireOnOffUp.transform.position.y, z + zOffset), Quaternion.Euler(0, 90, 0));
                GameObject er = Instantiate(earth, new Vector3(x + xOffset, earth.transform.position.y, z + zOffset), Quaternion.identity) as GameObject;
              
            //    scrStaticObj.tileName[index, i] = '1';
            //    scrStaticObj.tilePosition[index, i] = new Vector2(x + xOffset, z + zOffset);
            }
            else if (line[i] == '2')
            {
                //str += "todei";
                Instantiate(pltFireOnOffR, new Vector3(x + pltFireOnOffR.transform.position.y, z + zOffset), Quaternion.Euler(0, 180, 0));
                GameObject er = Instantiate(earth, new Vector3(x + xOffset, earth.transform.position.y, z + zOffset), Quaternion.identity) as GameObject;
              
            //    scrStaticObj.tileName[index, i] = '2';
               // scrStaticObj.tilePosition[index, i] = new Vector2(x + xOffset, z + zOffset);
            }
            else if (line[i] == '3')
            {
                //str += "todei";
                Instantiate(pltFireOnOffD, new Vector3(x + xOffset, pltFireOnOffD.transform.position.y, z + zOffset), Quaternion.Euler(0, 270, 0));
                GameObject er = Instantiate(earth, new Vector3(x + xOffset, earth.transform.position.y, z + zOffset), Quaternion.identity) as GameObject;
              
           //     scrStaticObj.tileName[index, i] = '3';
               // scrStaticObj.tilePosition[index, i] = new Vector2(x + xOffset, z + zOffset);
            }
            else if (line[i] == '4')
            {
                //str += "todei";
                Instantiate(pltFireOnOffL, new Vector3(x + xOffset, pltFireOnOffL.transform.position.y, z + zOffset), Quaternion.Euler(0, 180, 0));
                GameObject er = Instantiate(earth, new Vector3(x + xOffset, earth.transform.position.y, z + zOffset), Quaternion.identity) as GameObject;
              
            //    scrStaticObj.tileName[index, i] = '4';
             //   scrStaticObj.tilePosition[index, i] = new Vector2(x + xOffset, z + zOffset);
            }
            else if (line[i] == 't')
            {
                //str += "treasure";
               treasurs.Add(Instantiate(treasure, new Vector3(x + xOffset, treasure.transform.position.y, z + zOffset), Quaternion.identity) as GameObject);
               treasursZoffset.Add(zOffset);

                GameObject er = Instantiate(earth, new Vector3(x + xOffset, earth.transform.position.y, z + zOffset), Quaternion.identity) as GameObject;



           //     GameObject rew = Instantiate(variable.Instance.rewards[0], new Vector3(x + xOffset, earth.transform.position.y, z + zOffset), Quaternion.identity) as GameObject;
          //      rew.transform.SetParent(treas.transform, true);

            //    scrStaticObj.tileName[index, i] = 't';
             //   scrStaticObj.tilePosition[index, i] = new Vector2(x + xOffset, z + zOffset);
            }
            else if (line[i] == 'n')
            {
                Instantiate(nothing, new Vector3(x + xOffset, nothing.transform.position.y, z + zOffset), Quaternion.identity);
                //if (chunkCurrent == chunk.easy)
                //{
                //    // scrStaticObj.nPositions.Add(new Vector2(x + xOffset, z + zOffset));
                //    tileNameE[index, i] = 'n';
                //    //   scrStaticObj.tilePosition[index, i] = new Vector2(x + xOffset, z + zOffset);
                //}
                //else if (chunkCurrent == chunk.normal)
                //{
                //    tileNameN[index, i] = 'n';
                //}
                //else if (chunkCurrent == chunk.hard)
                //{
                //    tileNameH[index, i] = 'n';
                //}
            }

            xOffset += distanceBetweenTiles;
        }

    }

    bool checkRayTree(Vector3 posGenerate,Vector3 dir)
    {
            RaycastHit[] hits;
            hits = Physics.RaycastAll(posGenerate, dir);//, 30.0f);
            for (int k = 0; k < hits.Length; k++)
            {
               // Debug.Log(hits[k].collider.gameObject.tag);
                if (hits[k].collider.gameObject.tag == "tree")
                {
                    return true;
                }
            }
            return false;
    }
    /*    private bool Load(string fileName)
     {
         // Handle any problems that might arise when reading the text
         try
         {
             string line;
             // Create a new StreamReader, tell it which file to read and what encoding the file
             // was saved as
             StreamReader theReader = new StreamReader(fileName, Encoding.Default);
             // Immediately clean up the reader after this block of code is done.
             // You generally use the "using" statement for potentially memory-intensive objects
             // instead of relying on garbage collection.
             // (Do not confuse this with the using directive for namespace at the 
             // beginning of a class!)
             using (theReader)
             {
                 // While there's lines left in the text file, do this:
                 do
                 {
                     line = theReader.ReadLine();
                     index = 0;
                     if (line != null)
                     {
                         // Do whatever you need to do with the text line, it's a string now
                         // In this example, I split it into arguments based on comma
                         // deliniators, then send that array to DoStuff()
                         string[] entries = line.Split(',');
                         char[] lnObj=entries[index].ToCharArray();
                         if (entries.Length > 0)
                         {
                             //Debug.Log(entries[index]);
                             index++;

                             generateObj(lnObj);
                             zOffset += distanceBetweenTiles;
                             xOffset = 0.0f;
                         }
                     }
                 }
                 while (line != null);
                 // Done reading, close the reader and return true to broadcast success    
                 theReader.Close();
                 return true;
                 }
             }
             // If anything broke in the try block, we throw an exception with information
             // on what didn't work
             catch (Exception e)
             {
                 Debug.Log(e.Message);
                 Console.WriteLine("{0}0", e.Message);
                 return false;
             }
         }*/


}




#if UNITY_EDITOR

[CustomEditor(typeof(scrIO))]
public class editUI : Editor
{
    private bool Toggle;
    private scrIO _evCtrl = null;
    private float sizeWidth = 94;
    void OnEnable()
    {
        _evCtrl = (scrIO)target;
        Toggle = _evCtrl.manual;
    }
    public override void OnInspectorGUI()
    {
       // base.OnInspectorGUI();
         GUILayout.BeginHorizontal();
           GUILayout.Label("RandomChunckGenerate", GUILayout.Width(70));
          
           Toggle = _evCtrl.manual = EditorGUILayout.Toggle(Toggle);
           //Debug.Log(Toggle);
           GUILayout.EndHorizontal();

           GUILayout.Space(5);
           GUILayout.BeginHorizontal();
           GUILayout.Label("Room1", GUILayout.Width(sizeWidth));
           _evCtrl.Room1 = EditorGUILayout.ObjectField(_evCtrl.Room1, typeof(TextAsset), true) as TextAsset;
           GUILayout.EndHorizontal();

           if (Toggle)
           {
               #region easy editor
               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck1min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck1min = EditorGUILayout.ObjectField(_evCtrl.L1Echunck1min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck2min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck2min = EditorGUILayout.ObjectField(_evCtrl.L1Echunck2min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck3min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck3min = EditorGUILayout.ObjectField(_evCtrl.L1Echunck3min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck4min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck4min = EditorGUILayout.ObjectField(_evCtrl.L1Echunck4min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck5min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck5min = EditorGUILayout.ObjectField(_evCtrl.L1Echunck5min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck6min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck6min = EditorGUILayout.ObjectField(_evCtrl.L1Echunck6min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck7min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck7min = EditorGUILayout.ObjectField(_evCtrl.L1Echunck7min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck8min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck8min = EditorGUILayout.ObjectField(_evCtrl.L1Echunck8min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck9min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck9min = EditorGUILayout.ObjectField(_evCtrl.L1Echunck9min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck10min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck10min = EditorGUILayout.ObjectField(_evCtrl.L1Echunck10min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck1nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck1nil = EditorGUILayout.ObjectField(_evCtrl.L1Echunck1nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck2nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck2nil = EditorGUILayout.ObjectField(_evCtrl.L1Echunck2nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck3nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck3nil = EditorGUILayout.ObjectField(_evCtrl.L1Echunck3nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck4nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck4nil = EditorGUILayout.ObjectField(_evCtrl.L1Echunck4nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck5nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck5nil = EditorGUILayout.ObjectField(_evCtrl.L1Echunck5nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck6nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck6nil = EditorGUILayout.ObjectField(_evCtrl.L1Echunck6nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck7nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck7nil = EditorGUILayout.ObjectField(_evCtrl.L1Echunck7nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck8nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck8nil = EditorGUILayout.ObjectField(_evCtrl.L1Echunck8nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck9nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck9nil = EditorGUILayout.ObjectField(_evCtrl.L1Echunck9nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck10nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck10nil = EditorGUILayout.ObjectField(_evCtrl.L1Echunck10nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               #endregion

               #region normal editor

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Nchunck1min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Nchunck1min = EditorGUILayout.ObjectField(_evCtrl.L1Nchunck1min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Nchunck2min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Nchunck2min = EditorGUILayout.ObjectField(_evCtrl.L1Nchunck2min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Nchunck3min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Nchunck3min = EditorGUILayout.ObjectField(_evCtrl.L1Nchunck3min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Nchunck4min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Nchunck4min = EditorGUILayout.ObjectField(_evCtrl.L1Nchunck4min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Nchunck5min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Nchunck5min = EditorGUILayout.ObjectField(_evCtrl.L1Nchunck5min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Nchunck6min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Nchunck6min = EditorGUILayout.ObjectField(_evCtrl.L1Nchunck6min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Nchunck7min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Nchunck7min = EditorGUILayout.ObjectField(_evCtrl.L1Nchunck7min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Nchunck8min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Nchunck8min = EditorGUILayout.ObjectField(_evCtrl.L1Nchunck8min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Nchunck9min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Nchunck9min = EditorGUILayout.ObjectField(_evCtrl.L1Nchunck9min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Nchunck10min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Nchunck10min = EditorGUILayout.ObjectField(_evCtrl.L1Nchunck10min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Nchunck1nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Nchunck1nil = EditorGUILayout.ObjectField(_evCtrl.L1Nchunck1nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Nchunck2nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Nchunck2nil = EditorGUILayout.ObjectField(_evCtrl.L1Nchunck2nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Nchunck3nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Nchunck3nil = EditorGUILayout.ObjectField(_evCtrl.L1Nchunck3nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Nchunck4nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Nchunck4nil = EditorGUILayout.ObjectField(_evCtrl.L1Nchunck4nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Nchunck5nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Nchunck5nil = EditorGUILayout.ObjectField(_evCtrl.L1Nchunck5nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Nchunck6nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Nchunck6nil = EditorGUILayout.ObjectField(_evCtrl.L1Nchunck6nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Nchunck7nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Nchunck7nil = EditorGUILayout.ObjectField(_evCtrl.L1Nchunck7nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Nchunck8nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Nchunck8nil = EditorGUILayout.ObjectField(_evCtrl.L1Nchunck8nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Nchunck9nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Nchunck9nil = EditorGUILayout.ObjectField(_evCtrl.L1Nchunck9nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Nchunck10nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Nchunck10nil = EditorGUILayout.ObjectField(_evCtrl.L1Nchunck10nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               #endregion

               #region hard editor

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Hchunck1min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Hchunck1min = EditorGUILayout.ObjectField(_evCtrl.L1Hchunck1min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Hchunck2min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Hchunck2min = EditorGUILayout.ObjectField(_evCtrl.L1Hchunck2min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Hchunck3min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Hchunck3min = EditorGUILayout.ObjectField(_evCtrl.L1Hchunck3min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Hchunck4min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Hchunck4min = EditorGUILayout.ObjectField(_evCtrl.L1Hchunck4min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Hchunck5min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Hchunck5min = EditorGUILayout.ObjectField(_evCtrl.L1Hchunck5min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Hchunck6min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Hchunck6min = EditorGUILayout.ObjectField(_evCtrl.L1Hchunck6min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Hchunck7min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Hchunck7min = EditorGUILayout.ObjectField(_evCtrl.L1Hchunck7min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Hchunck8min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Hchunck8min = EditorGUILayout.ObjectField(_evCtrl.L1Hchunck8min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Hchunck9min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Hchunck9min = EditorGUILayout.ObjectField(_evCtrl.L1Hchunck9min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Hchunck10min", GUILayout.Width(sizeWidth));
               _evCtrl.L1Hchunck10min = EditorGUILayout.ObjectField(_evCtrl.L1Hchunck10min, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Hchunck1nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Hchunck1nil = EditorGUILayout.ObjectField(_evCtrl.L1Hchunck1nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Hchunck2nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Hchunck2nil = EditorGUILayout.ObjectField(_evCtrl.L1Hchunck2nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Hchunck3nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Hchunck3nil = EditorGUILayout.ObjectField(_evCtrl.L1Hchunck3nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Hchunck4nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Hchunck4nil = EditorGUILayout.ObjectField(_evCtrl.L1Hchunck4nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Hchunck5nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Hchunck5nil = EditorGUILayout.ObjectField(_evCtrl.L1Hchunck5nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Hchunck6nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Hchunck6nil = EditorGUILayout.ObjectField(_evCtrl.L1Hchunck6nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Hchunck7nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Hchunck7nil = EditorGUILayout.ObjectField(_evCtrl.L1Hchunck7nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Hchunck8nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Hchunck8nil = EditorGUILayout.ObjectField(_evCtrl.L1Hchunck8nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Hchunck9nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Hchunck9nil = EditorGUILayout.ObjectField(_evCtrl.L1Hchunck9nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Hchunck10nil", GUILayout.Width(sizeWidth));
               _evCtrl.L1Hchunck10nil = EditorGUILayout.ObjectField(_evCtrl.L1Hchunck10nil, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               #endregion
           }
           else
           {
               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck1", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck1 = EditorGUILayout.ObjectField(_evCtrl.L1Echunck1, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck2", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck2 = EditorGUILayout.ObjectField(_evCtrl.L1Echunck2, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck3", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck3 = EditorGUILayout.ObjectField(_evCtrl.L1Echunck3, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck4", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck4 = EditorGUILayout.ObjectField(_evCtrl.L1Echunck4, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck5", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck5 = EditorGUILayout.ObjectField(_evCtrl.L1Echunck5, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck6", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck6 = EditorGUILayout.ObjectField(_evCtrl.L1Echunck6, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck7", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck7 = EditorGUILayout.ObjectField(_evCtrl.L1Echunck7, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck8", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck8 = EditorGUILayout.ObjectField(_evCtrl.L1Echunck8, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck9", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck9 = EditorGUILayout.ObjectField(_evCtrl.L1Echunck9, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();

               GUILayout.Space(5);
               GUILayout.BeginHorizontal();
               GUILayout.Label("L1Echunck10", GUILayout.Width(sizeWidth));
               _evCtrl.L1Echunck10 = EditorGUILayout.ObjectField(_evCtrl.L1Echunck10, typeof(TextAsset), true) as TextAsset;
               GUILayout.EndHorizontal();
           }
    }
}
#endif