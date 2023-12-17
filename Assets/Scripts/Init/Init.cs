using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Init : MonoBehaviour
{
    [SerializeField] Slider Loadingbar;
    public Image LoadingbarFill;
    public void LoadScene(int sceneid)
    {
        StartCoroutine(LoadSceneASync(sceneid));
    }
        
    IEnumerator LoadSceneASync(int sceneid)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneid);
        while (!operation.isDone) 
        {
            float Progressvalue = Mathf.Clamp01(operation.progress / 0.9f);
            LoadingbarFill.fillAmount = Progressvalue;
            yield return new WaitForSeconds(5f);
        }

    }
}

