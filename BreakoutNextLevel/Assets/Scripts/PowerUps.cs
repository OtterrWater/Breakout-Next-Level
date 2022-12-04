using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

    public float speed;

    // Using to Initialize
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0f, -1f) * Time.deltaTime * speed);

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
