using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public static AudioManager instance; // variable to hold the reference to the instance of the class
	public AudioMixerGroup audioMixerGroup;

	public Sound[] sounds; // an array of sound class to hold all sounds used in th game

	private void Awake() {
		
		// Making the audio manager and hence the audio persistant between the scenes
		# region Making Audio Persistant
		if (instance == null) {
			instance = this;
		} else {
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
		#endregion
	}
	private void Start () {

		// Looping through all sounds in the sounds array and initilizing them 
		foreach (Sound s in sounds)	{
			
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = audioMixerGroup;
		}
	}

	public void Play (string sound)	{

		Sound s = Array.Find(sounds, item => item.name == sound);
		/*The above syntax states that:
		* Find in sounds array an item where item.name == sound
		* */
		if(s == null) {
			Debug.LogError("Audio Clip Named "+sound+" Not Found");
			return;
		}
		else if (s.clip == null) {
			Debug.LogError("No Audio Clip Specified In "+sound);
			return;
			
		}
		else {
			s.source.Play(); // Playing the clip
		}
	}

}
