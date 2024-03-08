using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherrys = 0;

    [SerializeField] private AudioSource audioCollectEffect;


    [SerializeField] private Text cherrysText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            audioCollectEffect.Play();
            Destroy(collision.gameObject);
            cherrys++;
            cherrysText.text = "Bananas:" + cherrys;
            
        }
    }
}
