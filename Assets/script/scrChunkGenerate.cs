using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class scrChunkGenerate : MonoBehaviour {
 /*  private List<char[,]>  chunks=new List<char[,]>();
   private char[,] subChunk;
   string line1,line2,line3,line;
   int count=0;
   public TextAsset getEasyChunk1, getEasyChunk2, getEasyChunk3, getEasyChunk4, getEasyChunk5, getMiddleChunk1, getHardChunk1;
   string stFile;*/
   void Start()
   {

  /*     {
           subChunk = new char[3, 2]{
                {'e','e'},
                {'e','e'},
                {'e','e'}};
           chunks.Add(subChunk);
       }
       {
           subChunk = new char[3, 2]{
                {'e','e'},
                {'e','e'},
                {'e','e'}};
           for (int i = 0; i < 3; i++) /// ye doonei ha
           {
               for (int j = 0; j < 2; j++)
               {
                   subChunk[i, j] = 'n';
                   chunks.Add(subChunk);
                   subChunk = new char[3, 2]{
                {'e','e'},
                {'e','e'},
                {'e','e'}};
               }
           }
       }
       {
           ////////// 2taeiha
           subChunk = new char[3, 2]{
                {'n','n'},
                {'e','e'},
                {'e','e'}};
           chunks.Add(subChunk);
           subChunk = new char[3, 2]{
                {'e','e'},
                {'n','n'},
                {'e','e'}};
           chunks.Add(subChunk);
           subChunk = new char[3, 2]{
                {'e','e'},
                {'e','e'},
                {'n','n'}};
           chunks.Add(subChunk);
           subChunk = new char[3, 2]{
                {'n','e'},
                {'n','e'},
                {'e','e'}};
           chunks.Add(subChunk);
           subChunk = new char[3, 2]{
                {'e','n'},
                {'e','n'},
                {'e','e'}};
           chunks.Add(subChunk);
           subChunk = new char[3, 2]{
                {'e','e'},
                {'n','e'},
                {'n','e'}};
           chunks.Add(subChunk);
           subChunk = new char[3, 2]{
                {'e','e'},
                {'e','n'},
                {'e','n'}};
           chunks.Add(subChunk);
           subChunk = new char[3, 2]{
                {'e','n'},
                {'n','e'},
                {'e','e'}};
           chunks.Add(subChunk);
           subChunk = new char[3, 2]{
                {'n','e'},
                {'e','n'},
                {'e','e'}};
           chunks.Add(subChunk);
           subChunk = new char[3, 2]{
                {'e','n'},
                {'e','e'},
                {'n','e'}};
           chunks.Add(subChunk);
           subChunk = new char[3, 2]{
                {'n','e'},
                {'e','e'},
                {'e','n'}};
           chunks.Add(subChunk);
           subChunk = new char[3, 2]{
                {'n','e'},
                {'e','e'},
                {'n','e'}};
           chunks.Add(subChunk);
           subChunk = new char[3, 2]{
                {'e','n'},
                {'e','e'},
                {'e','n'}};
           chunks.Add(subChunk);
           subChunk = new char[3, 2]{
                {'e','e'},
                {'n','e'},
                {'e','n'}};
           chunks.Add(subChunk);
           subChunk = new char[3, 2]{
                {'e','e'},
                {'e','n'},
                {'n','e'}};
           chunks.Add(subChunk);

       }
       //d:\\chunk.txt
       stFile = getEasyChunk2.name;
       Debug.Log(stFile);
       System.IO.StreamWriter file = new System.IO.StreamWriter("Assets/chunk/easy/" + stFile + ".txt");
       while (count < 15)
       {
           int ran1 =UnityEngine.Random.Range(0, 21);
           int ran2 =UnityEngine.Random.Range(0, 21);
           int ran3 =UnityEngine.Random.Range(0, 21);
           int ran4 =UnityEngine.Random.Range(0, 21);
           int ran5 =UnityEngine.Random.Range(0, 21);

           char[,] obj1 = chunks[ran1];
           char[,] obj2 = chunks[ran2];
           char[,] obj3 = chunks[ran3];
           char[,] obj4 = chunks[ran4];
           char[,] obj5 = chunks[ran5];

           line1 = obj1[0, 0].ToString() + obj1[0, 1] + obj2[0, 0] + obj2[0, 1] + obj3[0, 0] + obj3[0, 1] + obj4[0, 0] + obj4[0, 1] + obj5[0, 0] + obj5[0, 1];

           line2 = obj1[1, 0].ToString() + obj1[1, 1] + obj2[1, 0] + obj2[1, 1] + obj3[1, 0] + obj3[1, 1] + obj4[1, 0] + obj4[1, 1] + obj5[1, 0] + obj5[1, 1];

           line3 = obj1[2, 0].ToString() + obj1[2, 1] + obj2[2, 0] + obj2[2, 1] + obj3[2, 0] + obj3[2, 1] + obj4[2, 0] + obj4[2, 1] + obj5[2, 0] + obj5[2, 1];

           line = line1 + "\r\n" + line2 + "\r\n" + line3;

           
       
           // Compose a string that consists of three lines.
           //string lines = "First line.\r\nSecond line.\r\nThird line.";

           // Write the string to a file.
          
           file.WriteLine(line);
           count++;
           
       }
       file.Close();
       count = 0;
   */
   }
   

    // Update is called once per frame
    void Update()
    {
	
	}
    
}
