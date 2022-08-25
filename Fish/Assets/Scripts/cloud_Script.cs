using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud_Script : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedMin,speedMax,speed;
    public string tag;
    private GameObject target;

    void Start()
    {
        speed = Random.Range(speedMin, speedMax);
        target = GameObject.FindGameObjectWithTag(tag);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        if (transform.position == target.transform.position) Destroy(gameObject);
    }
}
