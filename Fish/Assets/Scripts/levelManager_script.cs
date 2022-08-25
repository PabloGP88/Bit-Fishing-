using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager_script : MonoBehaviour
{

    [SerializeField] GameObject pointManager;
    [SerializeField] GameObject[] stuffBlocked;
    [SerializeField] float pointsToGet;

    private bool enableStuff;


    // Start is called before the first frame update
    void Start()
    {
        pointManager = FindObjectOfType<pointsManager_script>().gameObject;
        for (int i = 0; i < stuffBlocked.Length; i++)
        {
            stuffBlocked[i].SetActive(false );
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pointManager.GetComponent<pointsManager_script>().amountPoints >= pointsToGet && !enableStuff)
        {
            GetComponent<Animator>().enabled = true;
            for (int i = 0; i < stuffBlocked.Length; i++)
            {
                stuffBlocked[i].SetActive(true);
            }
        }
    }
}
