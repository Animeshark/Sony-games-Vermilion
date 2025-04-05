using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public GameObject VictoryScreen;
    public TextMeshProUGUI VictoryText;
    public TextMeshProUGUI DefeatText;
    public TextMeshProUGUI TryAgainText;
    public GameObject DefeatScreen;


    // Start is called before the first frame update
    void Start()
    {
        DisplayEndScreen(true);
        DefeatText.fontMaterial.SetColor("_GlowColor", new Color(1, 0, 0));
        TryAgainText.fontMaterial.SetColor("_GlowColor", new Color(0, 1, 0));
    }

    public void DisplayEndScreen(bool isWin)
    {
        if (isWin)
        {
       
            VictoryScreen.SetActive(true);
        }
        else {
     
            DefeatScreen.SetActive(true);


        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
   
}
