using UnityEngine;
using System.Collections;

public class scrFade : MonoBehaviour {

    private Material material;
    public int tileDistanceZ, tileDistanceX;
    private bool c;
    private float disZNeg, disXNeg, disZpositive, disXPositive;
    private Shader transparentDiff, transparentStan;

	// Use this for initialization
	void Start () {
      material=GetComponentsInChildren<Renderer>()[0].material;
      disZNeg = transform.position.z - tileDistanceZ;
      disZpositive = transform.position.z + tileDistanceZ;
      disXNeg = transform.position.x - tileDistanceX;
      disXPositive = transform.position.x + tileDistanceX;
     transparentDiff= Shader.Find("Transparent/Diffuse");
     transparentStan = Shader.Find("Standard");
	}
	
	// Update is called once per frame
	void Update () {
       //c = Character.Instance.transform.position.z < transform.position.z + tileDistanceZ;
        if (Character.Instance.transform.position.z > disZNeg && Character.Instance.transform.position.z < disZpositive)
         if(   Character.Instance.transform.position.x > disXNeg && Character.Instance.transform.position.x < disXPositive)
            {

                material.shader = transparentDiff;

                //material.SetFloat("_Mode", 3);
                //material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                //material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                //material.SetInt("_ZWrite", 0);
                //material.DisableKeyword("_ALPHATEST_ON");
                //material.DisableKeyword("_ALPHABLEND_ON");
                //material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                //material.renderQueue = 3000;



                // Debug.Break();
                //material.SetFloat("_Mode", 2);
                //material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                //material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                //material.SetInt("_ZWrite", 0);
                //material.DisableKeyword("_ALPHATEST_ON");
                //material.EnableKeyword("_ALPHABLEND_ON");
                //material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                //material.renderQueue = 3000;

            }
            else
            {
                material.shader = transparentStan;

                //material.SetFloat("_Mode", 0);
                //material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                //material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                //material.SetInt("_ZWrite", 1);
                //material.DisableKeyword("_ALPHATEST_ON");
                //material.DisableKeyword("_ALPHABLEND_ON");
                //material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                //material.renderQueue = -1;
            }

	}

    //void OnGUI()
    //{
    //    GUI.color = Color.white;
    //    if(name=="wallDwn")
    //    GUI.Label(new Rect(20, 170, 100, 100),c + "");
    //}

}
