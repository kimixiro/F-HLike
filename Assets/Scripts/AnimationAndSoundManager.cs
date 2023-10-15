using UnityEngine;

public class AnimationAndSoundManager : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;

    public void PlayAnimation(string animationName)
    {
        animator.Play(animationName);
    }

    public void PlaySound(string soundName)
    {
        AudioClip clip = Resources.Load<AudioClip>("Sounds/" + soundName);
        audioSource.clip = clip;
        audioSource.Play();
    }
}