using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseScript : MonoBehaviour
{
    public int playersCounter;

    public Animator transition;
    public float timer;
    public float delayTime;

    public bool onVictory;


    // Start is called before the first frame update
    void Start()
    {
        playersCounter = 2;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (onVictory == true)
        {
            Win();
        }
        else
        {
            if (playersCounter <= 0)
            {
                Lose();
            }
        }

    }

    void Lose()
    {
        Change("Derrota");
    }

    void Win()
    {
        timer += Time.deltaTime;
        if (timer >= delayTime)
        {
            Change("Victoria");
        }
    }

    public void Change(string sceneName)
    {
        StartCoroutine(TransitionLoadScene(sceneName));
    }

    IEnumerator TransitionLoadScene(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(sceneName);
    }
}
