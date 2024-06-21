using UnityEngine;

[CreateAssetMenu(fileName = "AudioAsset", menuName = "ScriptableObjects/AudioAsset", order = 1)]
public class AudioAsset : ScriptableObject
{
    [SerializeField]
    private AudioClip _audioClip;
    
    public void PlayAudio()
    {
        AudioManager.Instance.PlaySound(_audioClip);
    }
}