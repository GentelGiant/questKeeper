using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scrOnClickReset : MonoBehaviour {

    [SerializeField]
    private Button MyButton = null; 

    // Use this for initialization
	void Start () {
        MyButton.onClick.AddListener(() => { reset(); });
   
	}

    void reset()
    {
        Application.LoadLevel("main");
    }


	// Update is called once per frame
	void Update () {
	
	}
}
