using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_script : MonoBehaviour
{
    //variables
    float rotationOnX;
    float mouseSensity = 90f;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        //cursor be gone
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
            
    }

    // Update is called once per frame
    void Update()
    {
        //taking mouse input
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensity;
        float m_X = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensity;
        //using y axis
        rotationOnX -= mouseY;
        rotationOnX = Mathf.Clamp(rotationOnX, -90f, 90f);
        transform.localEulerAngles = new Vector3(rotationOnX, 0f, 0f);

        //using X axis
        player.Rotate(Vector3.up * m_X);
           

    }
}
