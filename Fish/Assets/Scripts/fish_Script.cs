using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish_Script : MonoBehaviour
{
    public float speedMin, speedMax, speed, posYmin, posYmax , points;

    private bool fished;

    public bool right, left;

    private Vector3 hookPos;

    public Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
        fished = false;
        speed = Random.Range(speedMin, speedMax);
        transform.position = new Vector3(transform.position.x, Random.Range(posYmin, posYmax), transform.position.z);
        velocity = new Vector2(speed, 0);
        if (left) transform.Rotate(0, 180, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!fished)
        {
            if (right) GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + velocity * Time.deltaTime);
            if (left) {
                GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position - velocity * Time.deltaTime);
            }
           
        }
        if (fished)
        {
            hookPos = GameObject.FindGameObjectWithTag("Hook").transform.position;
            transform.position = new Vector3(hookPos.x,hookPos.y,-2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hook")
        {
            if (!collision.gameObject.GetComponent<fishHook_script>().hasFish) {
                
                fished = true;
                transform.Rotate(0, 0, 90);
                Destroy(GetComponent<Animator>());
            }
        }
        if (collision.gameObject.tag == "Limit")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Bucket")
        {
            
            GameObject pointsManager = FindObjectOfType<pointsManager_script>().gameObject;
            pointsManager.GetComponent<pointsManager_script>().amountPoints += points;
            GameObject hook = FindObjectOfType<fishHook_script>().gameObject;
            hook.GetComponent<fishHook_script>().pointSound = true;
            Destroy(gameObject);
        }

    }

}
