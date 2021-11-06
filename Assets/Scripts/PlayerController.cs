using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Transform camara;
    Vector2 movInput;
    Vector2 rotInput;
    float rotX;
    [SerializeField] float velMove = 7f;
    [SerializeField] float velSprint = 15f;
    [SerializeField] float sensibilidadMouse = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        camara = transform.GetChild(0);
        rotX = camara.eulerAngles.x;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        movInput.x = Input.GetAxis("Horizontal");
        movInput.y = Input.GetAxis("Vertical");

        rotInput.x = Input.GetAxis("Mouse X") * sensibilidadMouse;
        rotInput.y = Input.GetAxis("Mouse Y") * sensibilidadMouse;
    }

    private void FixedUpdate()
    {
        float vel = Input.GetKey(KeyCode.LeftShift) ? velSprint : velMove;
        rb.velocity = transform.forward * vel * movInput.y + transform.right * vel * movInput.x + new Vector3(0, rb.velocity.y, 0);

        transform.rotation *= Quaternion.Euler(0, rotInput.x , 0);

        rotX += rotInput.y;
        rotX = Mathf.Clamp(rotX, -50, 50);
        camara.localRotation = Quaternion.Euler(rotX, 0, 0);
    }
}