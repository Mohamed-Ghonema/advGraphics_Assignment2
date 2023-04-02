using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    [SerializeField] GameObject firstCam;
    [SerializeField] GameObject secondCam;
    [SerializeField] GameObject thirdCam;

    [SerializeField] Light light1;
    [SerializeField] Light light2;
    [SerializeField] Light light3;

    [SerializeField] Transform playerCamera = null;
    [SerializeField] Transform playerCamera2 = null;
    [SerializeField] float sensitivity = 3.0f;
    [SerializeField] float walkSpeed = 10.0f;
    [SerializeField] float gravity = -10.0f;
    [SerializeField] float jumpHeight = 0.5f;
    [SerializeField] bool lockCursor = true;
    [SerializeField] int cam = 1;

    float cameraPitch = 0.0f;
    CharacterController controller = null;

    Vector3 velocity;



    void Start()
    {

        controller = GetComponent<CharacterController>();
        if(lockCursor){

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }




    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Camera")) {

            if (cam == 1)
            {
                cam = 2;

                firstCam.SetActive(false);
                secondCam.SetActive(true);
                thirdCam.SetActive(false);
            }
            else if (cam == 2) {

                cam = 3;

                firstCam.SetActive(true);
                secondCam.SetActive(false);
                thirdCam.SetActive(false);

            }
            else if (cam == 3)
            {

                cam = 1;

                firstCam.SetActive(false);
                secondCam.SetActive(false);
                thirdCam.SetActive(true);

            }

        }

        if (cam == 1) {
            MouseMovement();

        } else if (cam == 2){

            MouseMovement2();
        }
        else if (cam == 3)
        {
            MouseMovement();

        }


        if (Input.GetButtonDown("Light")) {

            light1.enabled = !light1.enabled;
            light2.enabled = !light2.enabled;
            light3.enabled = !light3.enabled;

        }




        PlayerMovement();
        
    }


    void MouseMovement(){


        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X") ,Input.GetAxis("Mouse Y"));

        cameraPitch -= mouseDelta.y * sensitivity;

        cameraPitch = Mathf.Clamp(cameraPitch, -90f, 90f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate(Vector3.up * mouseDelta.x * sensitivity);


    }

    void MouseMovement2()
    {


        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        cameraPitch -= mouseDelta.y * sensitivity;

        cameraPitch = Mathf.Clamp(cameraPitch, -90f, 90f);

        playerCamera2.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate(Vector3.up * mouseDelta.x * sensitivity);


    }


    void PlayerMovement(){

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        if(controller.isGrounded){
            velocity.y = 0.0f;
        }


        velocity.y += gravity * Time.deltaTime;


        if(controller.isGrounded && Input.GetButtonDown("Jump")){

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }

        
        Vector3 move = (transform.right * x) + (transform.forward * z) + (Vector3.up * velocity.y);

        controller.Move(move * Time.deltaTime * walkSpeed);



    }
}
