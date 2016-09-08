using UnityEngine;
using System.Collections;

public class scrFallDetectPlayer : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "nothingFall")
        {
            Character.Instance.dead = true;
            Character.Instance.dieBy = Character.resoneDead.fall;
        }
    }
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "nothingFall")
        {
            Character.Instance.dead = true;
            Character.Instance.dieBy = Character.resoneDead.fall;
        }
    }
}
