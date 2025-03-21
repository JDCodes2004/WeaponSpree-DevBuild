using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookUpdated : MonoBehaviour
{
    public float mouseSensitivity = 75f;

    public Transform playerBody;
    public Transform playerWeapons;

    float xRotation = 91.06f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -91.06f, 91.06f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
