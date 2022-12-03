using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMpaddle : MonoBehaviour
{
    public Rigidbody2D MMpad;

    void Start()
    {
        MMpad = GetComponent<Rigidbody2D>();
        MMpad.AddForce(Vector2.right * 125);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
