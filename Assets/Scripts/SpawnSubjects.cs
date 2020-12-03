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
        StartCoroutine(TestDelay(3f));
    }

    void CreateSubjects()
    {
        GameObject gameobject = gameobjects[Random.Range(0, gameobjects.Length)];
        Vector3 position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0 + 100, (Screen.width + 1) - 100), Screen.height, 0));
        GameObject clone = Instantiate(gameobject, position, Quaternion.identity);
    }

    IEnumerator TestDelay(float delay)
    {
        print("Delay start!");

        yield return new WaitForSeconds(delay);
        print("Delay finished!");
    }

    IEnumerator RepeatingCoroutine(float delay)
    {
        print("RepeatingCoroutine!");
        yield return new WaitForSeconds(delay);
    }
}