using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour{
    [SerializeField] private float loadDelay = 0.5f;
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private AudioClip crashSfx;

    private bool _hasCrashed;

    private void OnTriggerEnter2D(Collider2D other){
        if (!other.CompareTag("Ground") || _hasCrashed) return;
        _hasCrashed = true;
        FindObjectOfType<PlayerController>().DisableControls();
        crashEffect.Play();
        GetComponent<AudioSource>().PlayOneShot(crashSfx);
        Invoke(nameof(ReloadScene), loadDelay);
    }

    private void ReloadScene(){
        SceneManager.LoadScene(0);
    }
}