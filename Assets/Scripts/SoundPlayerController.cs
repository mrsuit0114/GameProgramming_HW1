using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayerController : MonoBehaviour
{
    public AudioClip destroyedSound;

    public void PlayDestroySound()
    {
        GetComponent<AudioSource>().PlayOneShot(destroyedSound);
    }

}
