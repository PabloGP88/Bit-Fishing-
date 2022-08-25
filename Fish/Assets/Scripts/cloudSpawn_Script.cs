using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudSpawn_Script : MonoBehaviour
{
    public GameObject cloud;
    public float timeMin,timeMax,time;

    private bool hasSpawned;

    // Start is called before the first frame update
    void Start()
    {
        time = Random.Range(timeMin, timeMax);
        hasSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasSpawned)
        {
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        
        Instantiate(cloud, transform.position, Quaternion.identity);
        time = Random.Range(timeMin, timeMax);
        hasSpawned = true;
        yield return new WaitForSeconds(time);
        hasSpawned = false;
    }

}
