using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour{
    [SerializeField] private float loadDelay = 1f;
    [SerializeField] private ParticleSystem finishEffect;

    private void OnTriggerEnter2D(Collider2D other){
        if (!other.CompareTag("Player")) return;
        finishEffect.Play();
        GetComponent<AudioSource>().Play();
        Invoke(nameof(ReloadScene), loadDelay);
    }

    private void ReloadScene(){
        SceneManager.LoadScene(0);
    }
}