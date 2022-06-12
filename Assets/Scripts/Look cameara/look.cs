using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class look : MonoBehaviour
{ 
    [Header("reference")]
    [SerializeField] WallRun wallRun;
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;
    [SerializeField] GameObject Player;
    [SerializeField] Transform cam ;
    [SerializeField] Transform orientation;
    [SerializeField] Transform pivot;
    PhotonView view;


    float mouseX;
    float mouseY;

    float multiplier = 0.01f;

    float xRotation;
    float yRotation;

    private bool visible;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        visible = false;
        view = GetComponent<PhotonView>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            visible = !visible;
            Cursor.visible = visible;
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;
        }

        if (!visible && view.IsMine)
        {
            MyInput();

            cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, wallRun.tilt);
            Player.transform.localRotation = Quaternion.Euler(0, yRotation, 0);
            pivot.transform.localRotation = Quaternion.Euler(xRotation,0, 0);
        }
    }
    void MyInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        yRotation += mouseX * sensX * multiplier;
        xRotation -= mouseY * sensY * multiplier;

        xRotation = Mathf.Clamp(xRotation,-40f, 40f);

    }

}