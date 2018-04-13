using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int collected;
    public string newScene;

    void OnTriggerEnter2D(Collider2D collider)
    {
        print(collider.tag);
        if (collider.CompareTag("Player") && collected == 0)
        {
            print("Scene change");
            SceneManager.LoadScene(newScene);
        }
    }
}