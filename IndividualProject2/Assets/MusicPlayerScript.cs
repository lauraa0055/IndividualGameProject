using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayerScript : MonoBehaviour
{
    /*Video that helped with me slider
     https://youtu.be/-xvoJ7Q4vw0*/

    /*video that helped with keeping changed volume constant
     in different scenes
    https://youtu.be/scrzEyaIQQk*/

    /*video that helped with music being played simultaneously
     between scenes
    https://youtu.be/Xtfe5S9n4SI*/

    /*where I got the music from:
     Music by <a href="https://pixabay.com/users/coma-media-24399569/?utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=music&amp;utm_content=12099">Coma-Media</a> from <a href="https://pixabay.com/music//?utm_source=link-attribution&amp;utm_medium=referral&amp;utm_campaign=music&amp;utm_content=12099">Pixabay</a>*/

    public Slider volumeSlider;
    public GameObject ObjectMusic;

    private AudioSource AudioSource;
    private float MusicVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        ObjectMusic = GameObject.FindWithTag("BackgroundMusic");
        AudioSource = ObjectMusic.GetComponent<AudioSource>();

        //Set volume
        MusicVolume = PlayerPrefs.GetFloat("volume");
        AudioSource.volume = MusicVolume;
        volumeSlider.value = MusicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = MusicVolume;
        PlayerPrefs.SetFloat("volume", MusicVolume);
    }

    public void updateVolume(float volume)
    {
        MusicVolume = volume;
    }

}
