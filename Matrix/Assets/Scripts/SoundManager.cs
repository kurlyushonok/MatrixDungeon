using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
   
    public void PlaySound()
    {
		AudioSource.PlayClipAtPoint(audioClip, new Vector3(0,0,0));
	}
}