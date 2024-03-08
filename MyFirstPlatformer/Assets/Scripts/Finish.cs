using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Finish : MonoBehaviour
{
    private AudioSource finishSound;

    private bool levelComplite = false;
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelComplite)
        {
            finishSound.Play();
            levelComplite = true;    
            Invoke("ComleteLevel", 2f);
     
        }
          
    }
    private void ComleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
    }


}
