using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuManage : MonoBehaviour
{
    [SerializeField] Button Play;
    [SerializeField] Button Setting;
    [SerializeField] Button Quit;
    [SerializeField] Button Blank;
    public int sceneid;

    public void Start()
    {
        foreach (Button button in FindObjectsOfType<Button>(true))
        {
            button.transform.localScale = Vector3.zero;
            StartCoroutine("ButtonStart");
        }
    }
    IEnumerator ButtonStart()
    {

        foreach (Button button in FindObjectsOfType<Button>(true))
        {
            button.transform.DOScale(Vector3.one, 0.75f).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void OnEnable()
    {
        foreach (Button button in FindObjectsOfType<Button>(true))
        {
            button.gameObject.AddComponent<AnimateButton>();
            Quit.onClick.AddListener(Exitgame);
            Play.onClick.AddListener(ChangetoPlay);
        }
    }

    void Exitgame()
    {
        Application.Quit();
    }
    void ChangetoPlay()
    {
        SceneManager.LoadScene(sceneid);
    }
}
