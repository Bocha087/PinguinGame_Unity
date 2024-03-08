using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    private Animator animator;

    private Rigidbody2D rb;

    [SerializeField] private AudioSource audioDeathEffect;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Traps"))
        {
          //  audioDeathEffect.Play();
            Die();
        }       
    }

    private void Die()
    {
        audioDeathEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
