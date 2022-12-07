using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomicCameraScript : MonoBehaviour
{

    public Vector3 point = new Vector3(0, 0, 0);
    public Vector3 rotationAxis = new Vector3(0, 1, 0);
    
    public float anglePerSecond;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        transform.RotateAround(point, rotationAxis, anglePerSecond * Time.deltaTime);
    }
}
