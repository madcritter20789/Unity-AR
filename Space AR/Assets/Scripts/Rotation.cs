using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public GameObject planet;
    public Vector3 rotatePlanet;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        planet.transform.Rotate(rotatePlanet*Time.deltaTime);  
    }
}
