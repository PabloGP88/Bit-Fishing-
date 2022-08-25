using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishHook_script : MonoBehaviour
{
    public GameObject a, panelDamaged;
    public GameObject anchor;

    private GameObject audioManger;

    public float offset;

    public bool hasFish, pointSound;

    private bool playAudio,lose;

    // Start is called before the first frame update
    void Start()
    {
        playAudio = false;
        hasFish = false;
        audioManger = FindObjectOfType<audioManager_script>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Position();
        VerifyFish();
    }

    private void Position()
    {
        transform.position = new Vector3(transform.position.x, (anchor.transform.position.y - (offset * a.transform.localScale.y)),transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fish") {
            hasFish = true;
            if (!playAudio)
            {            
                audioManger.GetComponent<audioManager_script>().PlayAudio(0, 0.5f);
                playAudio = true;
            }
        }
        if (collision.gameObject.tag == "trap")
        {
           
            panelDamaged.SetActive(true);
            a = FindObjectOfType<fishingRod_Script>().gameObject;
            a.GetComponent<fishingRod_Script>().alive = false;
            if (!lose)
            {
                audioManger.GetComponent<audioManager_script>().PlayAudio(3, 0.5f);
                lose = true;
            }
            Destroy(panelDamaged, 0.5f);
        }

    }

    private void VerifyFish()
    {
        if (pointSound  && hasFish)
        {
            audioManger.GetComponent<audioManager_script>().PlayAudio(1, 0.5f);
            hasFish = false;
            playAudio = false;
            pointSound = false;
        }    
    }

}
