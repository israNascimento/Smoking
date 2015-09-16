using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    #region Dictionarys
    private Dictionary<string, AudioClip> audios;
    #endregion
    #region Ints
    public int hits = 6;
    public int steps = 8;
    #endregion

    void Start()
    {
        this.audios = new Dictionary<string, AudioClip>();
        this.audios.Add("Blackout", (AudioClip)Resources.Load("Audios/Blackout"));
        this.audios.Add("LightFlicker", (AudioClip)Resources.Load("Audios/LightFlicker"));
        this.audios.Add("Dash", (AudioClip)Resources.Load("Audios/Dash"));
        this.audios.Add("GuardBreak", (AudioClip)Resources.Load("Audios/GuardBreak"));
        this.audios.Add("GuardHit", (AudioClip)Resources.Load("Audios/GuardHit"));

        for (int i = 0; i < this.hits; i++)
        {
            this.audios.Add("Hit_" + i, (AudioClip)Resources.Load("Audios/Hits/Hit_" + i));
        }

        for (int i = 0; i < this.steps; i++)
        {
            this.audios.Add("Step_" + i, (AudioClip)Resources.Load("Audios/Steps/Step_" + i));
        }
    }
    void Update()
    {

    }

    public void Play(string audio)
    {
        AudioSource.PlayClipAtPoint(this.audios[audio], this.transform.position);
    }
    public void Play(string audio, float volume)
    {
        AudioSource.PlayClipAtPoint(this.audios[audio], this.transform.position, volume);
    }
}
