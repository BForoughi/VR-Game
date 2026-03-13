using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementCopier : MonoBehaviour
{
    public Transform otherCube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(otherCube.transform.position.x-13, otherCube.transform.position.y, otherCube.transform.position.z);
        
    }
}
