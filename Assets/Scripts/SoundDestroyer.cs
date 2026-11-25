using System.Collections;
using UnityEngine;

public class SoundDestroyer : MonoBehaviour
{
    private AudioSource _audioSource;

    private float _clipLength;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    //Destroy the sound object after the clip has finished playing
    private IEnumerator Start()
    {
        _clipLength = _audioSource.clip.length;
        yield return new WaitForSeconds(_clipLength);
        Destroy(gameObject);
    }
}
