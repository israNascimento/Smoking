using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour
{
    float range;
    AudioSource audioSource;
    GameObject target;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Resources.Load("Sounds/cat") as AudioClip;
        audioSource.loop = true;
        audioSource.priority = 50;
        target = GameObject.Find("Character");
        StartCoroutine(AdjustVolume());
    }


    void FixedUpdate()
    {
        if (audioSource.volume < 0.17f)
        {
            audioSource.mute = true;
        }
        else
        {
            audioSource.mute = false;
        }

    }

    public IEnumerator AdjustVolume()
    {
        while (true)
        {
            if (audio.isPlaying)
            {
                float distanceToTarget = Vector3.Distance(transform.position, this.target.transform.position);
                if (distanceToTarget < 1) { distanceToTarget = 1; }
                audio.volume = 0.4f / distanceToTarget;
                yield return new WaitForSeconds(1);
            }
            else
            {
                yield return new WaitForSeconds(25);
                audioSource.Play();
            }
        }
    }
}