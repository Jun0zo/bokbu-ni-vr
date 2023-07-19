using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomSpace : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Transform>().position = new Vector3(Random.RandomRange(-9, 6), 2, Random.RandomRange(-10, 4));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
