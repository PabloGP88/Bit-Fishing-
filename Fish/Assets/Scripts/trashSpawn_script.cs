using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashSpawn_script : MonoBehaviour
{
    

    public float timeMin, timeMax, time;
    public GameObject[] trash;

    private bool hasSpawned;
    private int numTrash;

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
        numTrash = Random.Range(0, trash.Length);
        GameObject trahSpawned = Instantiate(trash[numTrash], transform.position, Quaternion.identity);

        if (left) trahSpawned.GetComponent<trash_script>().left = true;

        if (right) trahSpawned.GetComponent<trash_script>().right = true;

        time = Random.Range(timeMin, timeMax);
        hasSpawned = true;
        yield return new WaitForSeconds(time);
        hasSpawned = false;
    }
}
