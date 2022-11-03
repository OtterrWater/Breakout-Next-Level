using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleScript : MonoBehaviour
{
    public float speed, leftScreenEdge, rightScreenEdge;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed);
        if (transform.position.x < leftScreenEdge)
        {
            transform.position = new Vector2(leftScreenEdge, transform.position.y);
        }
        if (transform.position.x > rightScreenEdge){
            transform.position = new Vector2(rightScreenEdge, transform.position.y);
        }
    }
}