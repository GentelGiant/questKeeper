using UnityEngine;
using System.Collections;

public class scrplFall : MonoBehaviour {
    float timeFall = 4;
    float timeCount = 0;
    bool go = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Character.Instance.transform.position.z >= this.transform.position.z)
        {
            go = true;
        }
        if(go==true)
        {
            timeCount += 1.0F * Time.deltaTime;
            if (timeCount >= timeFall)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.1f, this.transform.position.z);
            }
        }
        if (this.transform.position.y < -40)
        {
            Destroy(this.gameObject);
        }

	}
}
