using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneFader : MonoBehaviour
{
    public static SceneFader instance;

    [SerializeField]
      private GameObject fadecanvas;

    [SerializeField]
    private Animator fadeAnim;

    private void Awake()
    {

        MakeSingleton();
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void FadeIn(string levelName)
    {
        StartCoroutine(FadeInAnimation(levelName));
       
    }
    public void FadeOut()
    {
        StartCoroutine(FadeOutAnimation());
    }

    IEnumerator FadeInAnimation(string levelName)
    {
        fadecanvas.SetActive(true);
        fadeAnim.Play("FadeIn");
        yield return new WaitForSeconds(.7f);

        SceneManager.LoadScene("GamePlay");
        FadeOut();
    }

     IEnumerator FadeOutAnimation()
    {
        
        fadeAnim.Play("FadeIn");
        yield return new WaitForSeconds(1f);
        fadecanvas.SetActive(false);
       


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
