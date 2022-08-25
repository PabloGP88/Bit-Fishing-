using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager_script : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject continueButton,panelPausa;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        continueButton.SetActive(true);
        panelPausa.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        panelPausa.SetActive(false);
        continueButton.SetActive(false);
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void prueba100()
    {
        GameObject pointManager = FindObjectOfType<pointsManager_script>().gameObject;
        pointManager.GetComponent<pointsManager_script>().amountPoints += 100;
    }

}
