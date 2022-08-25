using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointsManager_script : MonoBehaviour
{

    public Text pointsText,highScoreText;
    public float amountPoints;

    private bool hsBeated;

    [SerializeField] GameObject newHighScore;

    audioManager_script audioManager;

    // Start is called before the first frame update
    void Start()
    {
        hsBeated = false;
        audioManager = FindObjectOfType<audioManager_script>();
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = amountPoints.ToString();
        highScoreText.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();
        if (amountPoints > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", amountPoints);
            highScoreText.text = amountPoints.ToString();
            newHighScore.SetActive(true);
            if (!hsBeated)
            {
                audioManager.PlayAudio(2, 0.5f);
                hsBeated = true;
            }
        }
    }
}
