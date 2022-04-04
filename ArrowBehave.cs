using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehave : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce((PlayerBehave.Instance.transform.position - transform.position).normalized * 100);
        transform.up = PlayerBehave.Instance.transform.position - transform.position;
    }
}
