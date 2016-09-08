using UnityEngine;
using System.Collections;

public class scrBladeChild : MonoBehaviour {
    int dir = 0;//up
    public float speedOffOnBlade;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (variable.Instance.isLoad == true)
        {
            if (this.transform.localPosition.y < 0.5f && dir == 0)//up
            {
                this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + speedOffOnBlade, this.transform.localPosition.z);
            }
            else { dir = 1; }

            if (this.transform.localPosition.y > -0.3f && dir == 1)//dwn
            {
                this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y - speedOffOnBlade, this.transform.localPosition.z);
            }
            else { dir = 0; }
        }
    }
}
