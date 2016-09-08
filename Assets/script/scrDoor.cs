using UnityEngine;
using System.Collections;

public class scrDoor : MonoBehaviour {
    public GameObject[] wallUp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "player")
        {
            GetComponentsInChildren<Animator>()[0].SetBool("openDoor", true);
            gameObject.tag = "Untagged";
            //for (int i = 0; i < wallUp.Length; i++)
            //    wallUp[i].GetComponent<scrFade>().enabled = true;
        }
    }
}
