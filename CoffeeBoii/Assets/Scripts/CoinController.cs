using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public EnvironmentController environment;
    public ChangeScene exit;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);

            
        }
    }

    void OnDestroy()
    {
        int index = (int)(Random.value * 4);
        environment.sEList[index] = !environment.sEList[index];
        //environment.sEList[3] = !environment.sEList[3];
        exit.collected--;
    }
}
