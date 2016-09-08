using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scrHUD : MonoBehaviour {

    public Text gemShow;
    public Text coinShow;
    public Text keyShow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gemShow.text = variable.Instance.gem.ToString();
        coinShow.text = variable.Instance.coin.ToString();
        keyShow.text = variable.Instance.keyCurrent.ToString() + " / " + variable.Instance.keyMax[0].ToString();
	}
}
