using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Spawn : MonoBehaviour
{
    public List<Transform> checkpoints = new List<Transform>();
    Transform[] arrayPoints;
    GameObject[] arrayObject;


    public float SpawnTime = 2f;
    public bool num;
    public int WaveNummber = 1;
    
    public int PathNummber = 1;
    bool CurrentWave = false;

    Despawn dev;
    private UI ui;

    private GameObject JellikZluta;
    private GameObject JellikCerna;
    private GameObject JellikBila;
    private GameObject golem;
    private GameObject FinalGolem;

    private GameObject PathLeft1;
    private EditorPath PathLeft1Editor;


    private GameObject PathRight1;
    private EditorPath PathRight1Editor;

    private GameObject PathRight2;
    private EditorPath PathRight2Editor;

    private GameObject PathLeft2;
    private EditorPath PathLeft2Editor;


    private GameObject m;



    IEnumerator SpawnDelay(GameObject unit, List<Transform> path, float spawnTime, float NummberUnits, EditorPath pathToFollow)
    {

        CurrentWave = true;

        if (WaveNummber == 1 || WaveNummber == 2 || WaveNummber == 3)
        {
            yield return new WaitForSeconds(12);
        }

        for (int i = 0; i < NummberUnits; i++)
        {
            yield return new WaitForSeconds(spawnTime);
            SpawnUnits(unit, path, pathToFollow);
        }

        if (WaveNummber > 3)
        {
            yield return new WaitForSeconds(50);
        }
        

        CurrentWave = false;
        
    }

    void SpawnUnits(GameObject unit, List<Transform> path, EditorPath pathToFollow)
    {
        unit.name = "Enemy";
        unit.tag = "Enemy";
        unit.GetComponent<MoveOnPath>().PathToFollow = pathToFollow;
        Instantiate(unit, path[0].position, path[0].rotation);
        


    }


    void Start()
    {

        JellikZluta = Resources.Load("Units/JellikZluta") as GameObject;
        JellikCerna = Resources.Load("Units/JellikCerna") as GameObject;
        JellikBila = Resources.Load("Units/JellikBila") as GameObject;
        golem = Resources.Load("Units/Golem") as GameObject;
        FinalGolem = Resources.Load("Units/FinalGolem") as GameObject;
        



        PathLeft1 = Resources.Load("Paths/PathLeft1") as GameObject;
        PathLeft1Editor = PathLeft1.GetComponent<EditorPath>();

        PathLeft2 = Resources.Load("Paths/PathLeft2") as GameObject;
        PathLeft2Editor = PathLeft2.GetComponent<EditorPath>();

        PathRight2 = Resources.Load("Paths/PathRight2") as GameObject;
        PathRight2Editor = PathRight2.GetComponent<EditorPath>();

        PathRight1 = Resources.Load("Paths/PathRight1") as GameObject;
        PathRight1Editor = PathRight1.GetComponent<EditorPath>();


        arrayPoints = GetComponentsInChildren<Transform>();
        WaveNummber = 1;

        foreach (Transform path_obj in arrayPoints)
        {
            if (path_obj != this.transform)
            {
                checkpoints.Add(path_obj);


                if (checkpoints.Count == arrayPoints.Length - 1)
                {
                    AddCollider(path_obj.gameObject);

                }


            }
        }

    }



    void Update()
    {

        if (PathNummber == 1)
        {
            if (WaveNummber == 1 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(JellikZluta, checkpoints, 6, 3, PathLeft1Editor));
                WaveNummber++;
            }

            if (WaveNummber == 2 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(JellikZluta, checkpoints, 6, 5, PathLeft1Editor));
                WaveNummber++;
            }
            if (WaveNummber == 3 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(JellikCerna, checkpoints, 6, 1, PathLeft1Editor));
                StartCoroutine(SpawnDelay(JellikZluta, checkpoints, 2, 3, PathLeft1Editor));
                WaveNummber++;
            }
            if (WaveNummber == 4 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(JellikCerna, checkpoints, 3, 3, PathLeft1Editor));
                WaveNummber++;

            }
            if (WaveNummber == 5 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(JellikZluta, checkpoints, 2, 10, PathLeft1Editor));
                WaveNummber++;

            }
            if (WaveNummber == 6 && CurrentWave == false)
            {

                StartCoroutine(SpawnDelay(JellikBila, checkpoints, 3, 2, PathLeft1Editor));
                StartCoroutine(SpawnDelay(JellikBila, checkpoints, 3, 4, PathLeft1Editor));
                WaveNummber++;

            }
            if (WaveNummber == 7 && CurrentWave == false)
            {  
                StartCoroutine(SpawnDelay(JellikZluta, checkpoints, 1, 10, PathLeft1Editor));
                WaveNummber++;
            }


            if (WaveNummber == 8 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(JellikZluta, checkpoints, 2, 6, PathLeft1Editor));
                StartCoroutine(SpawnDelay(JellikCerna, checkpoints, 4, 10, PathLeft1Editor));
                WaveNummber++;

            }

            if (WaveNummber == 9 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(JellikBila, checkpoints, 2, 4, PathLeft1Editor));
                StartCoroutine(SpawnDelay(JellikCerna, checkpoints, 4, 10, PathLeft1Editor));
                WaveNummber++;

            }
            if (WaveNummber == 10 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(golem, checkpoints, 6, 2, PathLeft1Editor));
                WaveNummber++;


            }

            if (WaveNummber == 11 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(FinalGolem, checkpoints, 1, 1, PathLeft1Editor));
                WaveNummber++;


            }


        }
        
        else if (PathNummber == 2)
        {
            if (WaveNummber == 1 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(JellikZluta, checkpoints, 6, 3, PathRight1Editor));
                WaveNummber++;
            }

            if (WaveNummber == 2 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(JellikZluta, checkpoints, 6, 5, PathRight1Editor));
                WaveNummber++;
            }

            if (WaveNummber == 3 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(JellikCerna, checkpoints, 6, 1, PathRight1Editor));
                StartCoroutine(SpawnDelay(JellikZluta, checkpoints, 2, 3, PathRight1Editor));
                WaveNummber++;

            }
            if (WaveNummber == 4 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(JellikCerna, checkpoints, 3, 3, PathLeft1Editor));
                WaveNummber++;


            }
            if (WaveNummber == 5 && CurrentWave == false)
            {
                
                StartCoroutine(SpawnDelay(JellikZluta, checkpoints, 2, 10, PathRight1Editor));
                WaveNummber++;

            }

            if (WaveNummber == 6 && CurrentWave == false)
            {

                StartCoroutine(SpawnDelay(JellikBila, checkpoints, 3, 2, PathRight1Editor));
                StartCoroutine(SpawnDelay(JellikZluta, checkpoints, 3, 4, PathRight1Editor));
                WaveNummber++;

            }
            if (WaveNummber == 7 && CurrentWave == false)
            {

                StartCoroutine(SpawnDelay(JellikZluta, checkpoints, 1, 10, PathRight1Editor));
                WaveNummber++;

            }

            if (WaveNummber == 8 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(JellikZluta, checkpoints, 2, 6, PathRight1Editor));
                StartCoroutine(SpawnDelay(JellikCerna, checkpoints, 4, 10, PathRight1Editor));
                WaveNummber++;

            }

            if (WaveNummber == 9 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(JellikBila, checkpoints, 2, 4, PathRight1Editor));
                StartCoroutine(SpawnDelay(JellikCerna, checkpoints, 4, 10, PathRight1Editor));
                WaveNummber++;

            }

            if (WaveNummber == 10 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(golem, checkpoints, 6, 2, PathRight1Editor));
                WaveNummber++;


            }



        }
        else if (PathNummber == 3)
        {
            if (WaveNummber == 1 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(JellikZluta, checkpoints, 6, 3, PathRight2Editor));
                WaveNummber++;
            }


            if (WaveNummber == 2 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(JellikZluta, checkpoints, 4, 4, PathRight2Editor));
                WaveNummber++;
            }

            if (WaveNummber == 3 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(JellikCerna, checkpoints, 2, 3, PathRight2Editor));
                StartCoroutine(SpawnDelay(JellikCerna, checkpoints, 6, 1, PathRight2Editor));
                WaveNummber++;
            }

            if (WaveNummber == 4 && CurrentWave == false)
            {
                
                StartCoroutine(SpawnDelay(JellikCerna, checkpoints, 3, 3, PathLeft1Editor));
                WaveNummber++;
                
            }
            if (WaveNummber == 5 && CurrentWave == false)
            {

                StartCoroutine(SpawnDelay(JellikZluta, checkpoints, 2, 10, PathRight2Editor));
                WaveNummber++;

            }
            if (WaveNummber == 6 && CurrentWave == false)
            {

                StartCoroutine(SpawnDelay(JellikZluta, checkpoints, 3, 2, PathRight2Editor));
                StartCoroutine(SpawnDelay(JellikBila, checkpoints, 3, 4, PathRight2Editor));
                WaveNummber++;

            }
            if (WaveNummber == 7 && CurrentWave == false)
            {

                StartCoroutine(SpawnDelay(JellikZluta, checkpoints, 1, 10, PathRight2Editor));
                WaveNummber++;


            }
            if (WaveNummber == 8 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(JellikZluta, checkpoints, 2, 6, PathRight2Editor));
                StartCoroutine(SpawnDelay(JellikCerna, checkpoints, 4, 10, PathRight2Editor));
                WaveNummber++;

            }

            if (WaveNummber == 9 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(JellikBila, checkpoints, 2, 4, PathRight2Editor));
                StartCoroutine(SpawnDelay(JellikCerna, checkpoints, 4, 10, PathRight2Editor));
                WaveNummber++;

            }
            if (WaveNummber == 10 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(golem, checkpoints, 6, 2, PathRight2Editor));
                WaveNummber++;


            }



        }
        else if (PathNummber == 4)
        {

            if (WaveNummber == 1 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(JellikZluta, checkpoints, 6, 3, PathLeft2Editor));
                WaveNummber++;
            }


            if (WaveNummber == 2 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(JellikZluta, checkpoints, 4, 4, PathLeft2Editor));
                WaveNummber++;
            }

            if (WaveNummber == 3 && CurrentWave == false)

            {
                StartCoroutine(SpawnDelay(JellikCerna, checkpoints, 2, 3, PathLeft2Editor));
                StartCoroutine(SpawnDelay(JellikCerna, checkpoints, 6, 1, PathLeft2Editor));
                WaveNummber++;
            }

            if (WaveNummber == 4 && CurrentWave == false)

            {
                
                StartCoroutine(SpawnDelay(JellikCerna, checkpoints, 3, 2, PathLeft1Editor));
                WaveNummber++;
            }
            if (WaveNummber == 5 && CurrentWave == false)
            {

                StartCoroutine(SpawnDelay(JellikZluta, checkpoints, 2, 10, PathLeft2Editor));
                WaveNummber++;

            }

            if (WaveNummber == 6 && CurrentWave == false)
            {

                StartCoroutine(SpawnDelay(JellikZluta, checkpoints, 3, 2, PathLeft2Editor));
                StartCoroutine(SpawnDelay(JellikBila, checkpoints, 3, 4, PathLeft2Editor));
                WaveNummber++;

            }
            if (WaveNummber == 7 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(golem, checkpoints, 1, 3, PathLeft2Editor));
                StartCoroutine(SpawnDelay(JellikZluta, checkpoints, 1, 9, PathLeft2Editor));
                WaveNummber++;

            }

            if (WaveNummber == 8 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(JellikZluta, checkpoints, 2, 6, PathLeft2Editor));
                StartCoroutine(SpawnDelay(JellikCerna, checkpoints, 4, 10, PathLeft2Editor));
                WaveNummber++;

            }

            if (WaveNummber == 9 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(JellikBila, checkpoints, 2, 4, PathLeft2Editor));
                StartCoroutine(SpawnDelay(JellikCerna, checkpoints, 4, 10, PathLeft2Editor));
                WaveNummber++;

            }
            if (WaveNummber == 10 && CurrentWave == false)
            {
                StartCoroutine(SpawnDelay(golem, checkpoints, 6, 2, PathLeft2Editor));
                WaveNummber++;


            }


        }

    
    }


    void AddCollider(GameObject obj)
    {
        float scale = 1.3f;
        obj.AddComponent<BoxCollider>();
        BoxCollider collider = obj.GetComponent<BoxCollider>();
        collider.isTrigger = true;
        collider.size = new Vector3(scale, scale, scale);
        Spawn spawn = obj.GetComponentInParent<Spawn>();
        obj.AddComponent<Despawn>();

    }








}
