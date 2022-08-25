using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishingRod_Script : MonoBehaviour
{

    public bool alive;

    pointsManager_script pointsManager;


    [SerializeField] GameObject gameOverPanel;

    private bool isPressed,ispc;

    public float sizeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        pointsManager = FindObjectOfType<pointsManager_script>().gameObject.GetComponent<pointsManager_script>();
        ispc = false;
        isPressed = false;   
    }

    // Update is called once per frame023

    void Update()
    {
        if (alive) { movment(); }
        if (!alive) gameOverPanel.SetActive(true);
    }

    private void movment()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ispc = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            ispc = false;
        }
        if ((Input.touchCount > 0 && transform.localScale.y<9f) || ispc && transform.localScale.y < 9f)
        {

            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + sizeSpeed * Time.deltaTime, transform.localScale.z);
            isPressed = true;
        }
        else if (Input.touchCount == 0 || !ispc)
        {
            isPressed = false;
        }
        if (!isPressed)
        {


            if (transform.localScale.y > 0.08856164f)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - (sizeSpeed + 1f) * Time.deltaTime, transform.localScale.z);
            }
        }
    }

}
