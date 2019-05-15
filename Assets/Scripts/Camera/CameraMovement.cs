using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{

    
    private Vector3 smothingVecotr;
    private Vector3 smothingVecotr1;
    private Vector3 velocity = Vector3.zero;


    Vector3 smothingVecotr2;
    Vector3 smothingVecotr3;
    Vector3 positionNow; 
    Vector3 maxCoordinate;
    bool x = false;
    private float ReverseMouseWheel = -1; //smer mousewheel pri zoomu
    public float smoothTime = 0.1F;
    public float smoothTimeDrag = 0.5F;
    public float CameraSpeed = 0.3f;
    float ZoomSpeed = 15;
    private float MaxZoomDistance = 80; // maximalni zoom Y.souradnice
    private float MinZoomDistance = 10; // minimalni zoom Y.souradnice
    public float CameraHeight = 20f;
    private float MaxZdistance = 100;
    private float MaxXdistance = 100;
    private float MinZdistance = -100;
    private float MinXdistance = -100;

    float CameraOrthoSize;

    void Start()
    {
        
        CameraOrthoSize = Camera.main.orthographicSize;
        //    CamDirection = transform.position;
    }
    void LateUpdate()
    {


       
        /*
            Debug.Log(SceneManager.GetActiveScene().buildIndex);
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                Debug.Log("ahoj");
                    FindObjectOfType<AudioManager>().PlaySound("InGameMusic");
                x = false;
            }
        
        */

        DragMouse();
        //  string ahoj = "Horizontal";

        if (Time.timeScale != 0f)
        {



            float xAxisValue = Input.GetAxis("Horizontal");
            smothingVecotr1.x = new Vector3(xAxisValue, 0.0f, 0.0f).x;
       

            float zAxisValue = Input.GetAxis("Vertical");
            smothingVecotr1.z = new Vector3(0.0f, 0.0f, zAxisValue).z;

            float ZoomValue = Input.GetAxis("Mouse ScrollWheel");
            //   Debug.Log("transform.position" + transform.position.y);
         //   Debug.Log(transform.position.y);

            /*
                    if (transform.position.y <= CameraHeight)      
                    {
                        if (ZoomValue > 0)
                        {

                            ZoomValue = 0;             
                        } 
                    }
                    */

            smothingVecotr1.y = new Vector3(0.0f, ZoomValue, 0.0f).y * ZoomSpeed * ReverseMouseWheel;

            /* pouze pro pohled ze shora (pro orthoKameru)
            if (ZoomValue !=0 ) {
                CameraOrthoSize -= ZoomValue * ZoomSpeed;
                CameraOrthoSize = Mathf.Clamp(CameraOrthoSize, MinZoomDistance, MaxZoomDistance);
            }
            Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, CameraOrthoSize, 1000*smoothTime * Time.deltaTime);
            */

            //     smothingVecotr1 = new Vector3(0.0f, zAxisValue, xAxisValue);
            //    smothingVecotr1.z = new Vector3(0.0f, 0.0f, ZoomValue).z *ZoomSpeed;

            //smooth pohyb
            smothingVecotr = Vector3.SmoothDamp(smothingVecotr, smothingVecotr1, ref velocity, smoothTime);

            float ax = transform.position.y;
            float bx = transform.position.x;
            float cx = transform.position.z;

            float dist = smothingVecotr.y * CameraSpeed;
            // float dist = maxCoordinate.y + transform.position.y;  
            // Debug.Log("maxCoordinate.y" + maxCoordinate.y);  
          //  Debug.Log("final lenght" + ax + dist);
            if (ax + dist <= MinZoomDistance || ax + dist > MaxZoomDistance) { }
            if (bx + dist <= MinXdistance || bx + dist > MaxXdistance) { }
            if (cx + dist <= MinZdistance || cx + dist > MaxZdistance) { }
            else
            {
                transform.Translate(smothingVecotr * CameraSpeed);
            }
        }
            //    transform.Translate(smothingVecotr * CameraSpeed);
            //NEsmooth pohyb
             //   transform.Translate(new Vector3(xAxisValue, zAxisValue, 0.0f));
    }
        
            void DragMouse() {
                float CameraDragSpeed = 100;

                Vector3 pos = transform.position;
                if (Input.GetMouseButton(0))
                {
                    pos.x -= Input.GetAxis("Mouse X") * CameraDragSpeed * Time.deltaTime;
                    pos.z -= Input.GetAxis("Mouse Y") * CameraDragSpeed * Time.deltaTime;
                }
                transform.position = Vector3.SmoothDamp(pos, pos, ref velocity, smoothTimeDrag);

                //transform.position = pos;


            }


        }

