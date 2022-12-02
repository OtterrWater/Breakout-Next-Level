using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMball : MonoBehaviour
{
    public Rigidbody2D MMrb;
    public int MMbc;
    void Start()
    {
        MMrb = GetComponent<Rigidbody2D>();
        MMrb.AddForce(Vector2.up * 500);
        MMbc = GameObject.FindGameObjectsWithTag("brick").Length;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("brick"))
        {
            Destroy(other.gameObject);

            //gm.UpdateScore(+1);
            UpdateMMbc();
        }
    }

    public void UpdateMMbc()
    {
        MMbc--;
    }
}
