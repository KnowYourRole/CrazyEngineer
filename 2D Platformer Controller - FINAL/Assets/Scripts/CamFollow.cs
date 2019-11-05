using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour
{


    [SerializeField]
    private float xMax;



    [SerializeField]
    private float xMin;

    private Transform target;

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), transform.position.y, transform.position.z);
    }
}
