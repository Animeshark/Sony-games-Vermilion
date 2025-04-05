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
    public TextMeshProUGUI[] TryAgainText;
    public GameObject DefeatScreen;
    public int enemyNum;


    // Start is called before the first frame update
    void Start()
    {
        DefeatText.fontMaterial.SetColor("_GlowColor", new Color(1, 0, 0));
        TryAgainText[0].fontMaterial.SetColor("_GlowColor", new Color(0, 1, 0));
        TryAgainText[1].fontMaterial.SetColor("_GlowColor", new Color(0, 1, 0));
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
        Debug.Log("resfsief");
        SceneManager.LoadScene(0);
    }
   
    public void EnemyDefeated()
    {
        enemyNum--;
        if (enemyNum <= 0)
        {
            DisplayEndScreen(true);
        }
    }
}
