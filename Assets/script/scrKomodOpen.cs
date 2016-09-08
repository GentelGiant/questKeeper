using UnityEngine;
using System.Collections;

public class scrKomodOpen : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "player")
        {
            GetComponent<Animator>().SetBool("openDoorKomod", true);
        }
    }
}
