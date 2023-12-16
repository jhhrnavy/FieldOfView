using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float moveSpeed = 6f;

    private Rigidbody _rb;
    private Camera _viewCam;
    private Vector3 _velocity;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _viewCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = _viewCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _viewCam.transform.position.y));
        transform.LookAt(mousePos + Vector3.up * transform.position.y);
        _velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _velocity * Time.fixedDeltaTime);
    }
}
