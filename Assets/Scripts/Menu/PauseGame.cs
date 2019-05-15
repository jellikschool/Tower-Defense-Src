using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseGame : MonoBehaviour
{
   
    private UI ui;
    private Spawn spawn;
    public GameObject PauseMenuUI;
    public GameObject ENDMenuUI;
    public GameObject VictoryMenuUI;

    public static bool PausedGame = false;
    public GameObject MainCamera1;
    public GameObject EndGameCamera1;
    private GameObject Path;
    public GameObject Enemy;

    private bool FinishGolem = false;
    private bool FinishGolemLive = true;


    int Cameras;

    private void Start()
    { GameObject camera = new GameObject();
        Enemy = new GameObject();
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        Path = GameObject.FindGameObjectWithTag("Path");

        spawn = Path.GetComponent<Spawn>();

        ui = camera.GetComponent<UI>();
            
    }

    void Update()
    {
       float hpNumber = FindObjectOfType<UI>().Lives;
        if (hpNumber <= 0)
        {
            
            SwitchOnEndGameCamera();
            ENDMenuUI.SetActive(true);        
            FindObjectOfType<AudioManager>().PlaySound("endGame");

        }


        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        Debug.Log(Enemy);
        Debug.Log(spawn.WaveNummber);
        if (spawn.WaveNummber == 12)
        {
            if (Enemy == null)
            {
                
                SwitchOnEndGameCamera();
                VictoryMenuUI.SetActive(true);
            }
           
            //FindObjectOfType<AudioManager>().PlaySound("endGame");

        }






        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            if (PausedGame)
            {
                ResumeGame();
            //    GameObject.FindGameObjectWithTag("PauseMenu").SetActive(true);
               
            }
            else
            {
               PausingGame();
          //      GameObject.FindGameObjectWithTag("PauseMenu").SetActive(false);
            }
        }
    }
    
      public void PausingGame()
        {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;     
        PausedGame = true;


      //  GameObject camerabox = GameObject.Find("CamerBox");
    //    CameraMovement CameraMovement = camerabox.GetComponent<CameraMovement>();
     //   CameraMovement.CameraSpeed = 0f;


    }

    
    public void ResumeGame() {
        FindObjectOfType<AudioManager>().PlaySound("ButtonClick");
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        PausedGame = false;

    

    }

    public void LoadMenu()
    {

    }
    public void QuitInGame()
    {
        Debug.Log("jdu do menu");
        SceneManager.LoadScene(0);

    }

    public void TurnOffGame()
    {
        // loadne dalsi level
        Debug.Log("quit");
        Application.Quit();


    }

    public void SwitchOnMainCamera()
    {
        EndGameCamera1.SetActive(false);
        MainCamera1.SetActive(true);
    }
    public void SwitchOnEndGameCamera()
    {
        MainCamera1.SetActive(false);
        EndGameCamera1.SetActive(true);
    }

    

}
