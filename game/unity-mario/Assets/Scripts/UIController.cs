using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    private int rings = 0;
    public static string RINGS_30_ACH = "30ringscollected";

    public Text ringsText;

    public void addRing(int howmany)
    {
        rings += howmany;
        ringsText.text = "Rings: " + rings;
        if(rings >= 30)
        {
            if (PlayerPrefs.GetInt(RINGS_30_ACH) == 1)
            {
                Debug.Log("'Collect 30 rings' achieved earlier!");
            }
            else
            {
                PlayerPrefs.SetInt(RINGS_30_ACH, 1);
                Debug.Log("'Collect 30 rings' now achieved!");
            }
        }
    }

    public void resetRing()
    {
        rings = 0;
        ringsText.text = "Rings: " + rings;
    }

    public void startGame()
    {
        SceneManager.LoadScene(2);
    }

    public void SeeAchievements()
    {
        SceneManager.LoadScene(1);
    }

    public void backToMain()
    {
        SceneManager.LoadScene(0);
    }

}
