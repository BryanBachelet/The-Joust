using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oeuf_Behavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (transform.position.x > 6.95f)
        {
            transform.position = new Vector3(-6.90f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -6.95f)
        {
            transform.position = new Vector3(6.90f, transform.position.y, transform.position.z);
        }
    }
}
