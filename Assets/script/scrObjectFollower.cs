using UnityEngine;
using System.Collections;

public class scrObjectFollower : MonoBehaviour
{
    [SerializeField]
    private GameObject target_;


    private Vector3 offset;
    public bool firstTime = true;
    public float lerp;
    //static scrObjectFollower _instance;
    //public static scrObjectFollower Instance
    //{
    //    get { return _instance; }
    //}
    void Awake()
    {
        //    _instance = this;
        offset = this.transform.position - target_.transform.position;
    }

    void Update()
    {

        //if (firstTime)
        //{

        //    offset = this.transform.position - target_.transform.position;
        //    firstTime = false;
        //}
        //else
        //{
           // if (Character.Instance.transform.position.x > -2.5f && Character.Instance.transform.position.x < 2.5f)
                transform.position = Vector3.Lerp(transform.position, target_.transform.position + offset, lerp * Time.deltaTime);
            //else if (Character.Instance.transform.position.x < -2.5f)
            //{
            //    Vector3 pos = target_.transform.position + offset;
            //    pos.x = -2.5f + offset.x;
            //    transform.position = Vector3.Lerp(transform.position, pos, 100f * Time.deltaTime);
            //}
            //else if (Character.Instance.transform.position.x > 2.5f)
            //{
            //    Vector3 pos = target_.transform.position + offset;
            //    pos.x = 2.5f + offset.x;
            //    transform.position = Vector3.Lerp(transform.position, pos, 100f * Time.deltaTime);
            //}

    }
}
