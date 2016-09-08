using UnityEngine;
using System.Collections;

public class scrBladeOffOn : MonoBehaviour {
    int dir = 0;//up
    public float speedOffOnBlade;
    public float up;
    public float down;
    public float waitTimeDwn;
    private bool waitingStartDwn = false, waitingStartUp = false;

	void Start () {
	}
	
	void Update () {
        if (variable.Instance.isLoad == true)
        {
            if (this.transform.position.y >= up && waitingStartUp == false)
            {
                waitingStartDwn = false;
                waitingStartUp = true;
                dir = -1;
                StartCoroutine(waitingDwn(waitTimeDwn));
            }
            if (this.transform.position.y <= down && waitingStartDwn==false)
            {
                waitingStartDwn = true;
                waitingStartUp = false;
                dir = -1;
                StartCoroutine(waitingUp(waitTimeDwn)); 
            }

            if (dir == 0)//up
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + speedOffOnBlade, this.transform.position.z);
            }

            if ( dir == 1)//dwn
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - speedOffOnBlade, this.transform.position.z);
            }
        }
	}

    IEnumerator waitingUp(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        dir = 0;
    }
    IEnumerator waitingDwn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        dir = 1;
    }

}
