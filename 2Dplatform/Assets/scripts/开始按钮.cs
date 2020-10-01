using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class 开始按钮 : MonoBehaviour
{   
    public void Click_test()
    {
        SceneManager.LoadScene("Game");
    }
}
