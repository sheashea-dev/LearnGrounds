using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable Objects/Sound Manager", fileName ="Sound Manager")]
public class SoundManagerSO : ScriptableObject
{
    private static SoundManagerSO instance;

    public static SoundManagerSO Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load<SoundManagerSO>("Sound Manager");
            }
            return instance;
        }
    }
    public AudioSource SoundObject;

    //Randomization multipliers for volume and pitch to give the sound effectsmore variance & feel more natural
    private static float _volumeChangeMultiplier = 0.15f;
    private static float _pitchChangeMultiplier = 0.1f;

    //Single SFX clip one shot method
    public static void PlaySoundFXClip(AudioClip clip, Vector3 soundPos, float volume, float pan, float spatialBlend)
    {
        float randVolume = Random.Range(volume - _volumeChangeMultiplier, volume + _volumeChangeMultiplier);
        float randPitch = Random.Range(1 - _pitchChangeMultiplier, 1 + _pitchChangeMultiplier);

        AudioSource a = Instantiate(Instance.SoundObject,soundPos, Quaternion.identity);
        a.clip = clip;
        a.volume = randVolume;
        a.pitch = randPitch;
        a.panStereo = pan;
        a.spatialBlend = spatialBlend;
        a.Play();
    }

    //Version of the SFX method that takes an array of clips and randomly selects one to play
    public static void PlaySoundFXClip(AudioClip[] clips, Vector3 soundPos, float volume, float pan, float spatialBlend)
    {
        int randClip = Random.Range(0, clips.Length);
        float randVolume = Random.Range(volume - _volumeChangeMultiplier, volume + _volumeChangeMultiplier);
        float randPitch = Random.Range(1 - _pitchChangeMultiplier, 1 + _pitchChangeMultiplier);

        AudioSource a = Instantiate(Instance.SoundObject, soundPos, Quaternion.identity);
        a.clip = clips[randClip];
        a.volume = randVolume;
        a.pitch = randPitch;
        a.panStereo = pan;
        a.spatialBlend = spatialBlend;
        a.Play();
    }
}
