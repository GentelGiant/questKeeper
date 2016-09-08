using UnityEngine;
using System.Collections;

public class scrplfMoveable : MonoBehaviour {
    float xtemp;
    int dir = 0;
    public float limitDistance;
    public float speedMoveablePlt;
	// Use this for initialization
	void Start () {
        xtemp = this.transform.position.x;
	}
	
	// Update is called once per frame
    void Update()
    {
        if (variable.Instance.isLoad == true)
        {

            if (this.transform.position.x < limitDistance && dir == 0)
            {
                this.transform.position = new Vector3(xtemp, this.transform.position.y, this.transform.position.z);
                xtemp = this.transform.position.x + speedMoveablePlt;
            }
            else { dir = 1; }
            if (this.transform.position.x > -limitDistance && dir == 1)
            {
                this.transform.position = new Vector3(xtemp, this.transform.position.y, this.transform.position.z);
                xtemp = this.transform.position.x - speedMoveablePlt;
            }
            else { dir = 0; }
        }
    }
}
