using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            this.transform.position += this.transform.forward * Time.deltaTime * Speed;
        if (Input.GetKey(KeyCode.D))
            this.transform.position += this.transform.right * Time.deltaTime * Speed;
        if (Input.GetKey(KeyCode.S))
            this.transform.position -= this.transform.forward * Time.deltaTime * Speed;
        if (Input.GetKey(KeyCode.A))
            this.transform.position -= this.transform.right * Time.deltaTime * Speed;
    }
}
