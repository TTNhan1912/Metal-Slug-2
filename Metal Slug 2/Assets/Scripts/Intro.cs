using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public float intro_time = 5f;
    void Start()
    {
        StartCoroutine(Intro_for_wait());
    }

    IEnumerator Intro_for_wait()
    {
        yield return new WaitForSeconds(intro_time);

        SceneManager.LoadScene(1);
    }
}