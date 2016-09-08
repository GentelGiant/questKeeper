using UnityEngine;
using System.Collections;

public class scrTreasure : MonoBehaviour {
   private bool open = false;
   private Animator[] anim;
   // string str;
	// Use this for initialization
	void Start () {
        anim = GetComponentsInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

	}
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "jigooli")
        {      
            if (open == false)
            {
                //Debug.Log(this.tag);
                anim[0].SetBool("open", true);
                anim[1].SetBool("moveCoin", true);

                if (this.tag == "key")
                    variable.Instance.keyCurrent++;
                if (this.tag == "gem")
                    variable.Instance.gem++;

                if (this.tag == "c1")
                    variable.Instance.coin += variable.Instance.typeCoin[0];
                else if (this.tag == "c2")
                    variable.Instance.coin += variable.Instance.typeCoin[1];
                else if (this.tag == "c3")
                    variable.Instance.coin += variable.Instance.typeCoin[2];
                else if (this.tag == "c4")
                    variable.Instance.coin += variable.Instance.typeCoin[3];
                else if (this.tag == "c5")
                    variable.Instance.coin += variable.Instance.typeCoin[4];
                else if (this.tag == "c6")
                    variable.Instance.coin += variable.Instance.typeCoin[5];
                else if (this.tag == "c7")
                    variable.Instance.coin += variable.Instance.typeCoin[6];

                open = true;
            }
        }

    }

    

    void OnGUI()
    {
        //GUI.Label(new Rect(0, 0, 100, 100), scrStaticObj.coin + "");
      //  GUI.Label(new Rect(0, 10, 100, 100), str + "");
    }
}
