using UnityEngine;
using System.Collections;

public class scrRiver : MonoBehaviour {

    private float scrollSpeed = -0.1F;
	void Update () {
        float offset = Time.time * scrollSpeed;
        Renderer[] rend = this.GetComponentsInChildren<Renderer>();
        rend[0].material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
	}
}
