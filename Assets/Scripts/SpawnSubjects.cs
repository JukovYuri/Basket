using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSubjects : MonoBehaviour
{
    public float time;
    public GameObject[] gameobjects;

    void Start()
    {
        InvokeRepeating("CreateSubjects", 0, time);
    }

    void CreateSubjects()
    {
        GameObject gameobject = gameobjects[Random.Range(0, gameobjects.Length)];
        Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0 + 100, (Screen.width + 1) - 100), Screen.height, 0));
        GameObject clone = Instantiate(gameobject, position, Quaternion.identity);
    }
}