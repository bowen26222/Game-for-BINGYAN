using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class LoadScene : MonoBehaviour
{
    public Text loadingText;
    private int curProgressValue = 0;
    void FixedUpdate()
    {
        int progressValue = 100;
        if (curProgressValue < progressValue)
        {
            curProgressValue++;
        }
        loadingText.text = "芜湖起飞...." + curProgressValue + "%";
        if (curProgressValue == 100)
        {
            loadingText.text = "OK";
            SceneManager.LoadScene("Menu");
        }
    }
}
