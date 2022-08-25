using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawn_script : MonoBehaviour
{
    public float timeMin, timeMax, time;
    public GameObject[] fish;

    private bool hasSpawned;
    private int numFish;

    public bool left, right;

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
        numFish = Random.Range(0, fish.Length);
        GameObject fishSpawned = Instantiate(fish[numFish], transform.position, Quaternion.identity);
        if (left ) fishSpawned.GetComponent<fish_Script>().left = true;

        if (right) fishSpawned.GetComponent<fish_Script>().right = true;

        time = Random.Range(timeMin, timeMax);
        hasSpawned = true;
        yield return new WaitForSeconds(time);
        hasSpawned = false;
    }
}
