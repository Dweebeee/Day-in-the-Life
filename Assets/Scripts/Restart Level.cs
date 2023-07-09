using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Debug Reset"))
        {
            StartCoroutine(Restart(0));
        }
    }

    public IEnumerator Restart(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        //sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Debug.Log("Current scene is: " + sceneIndex);
    }
}