using UnityEngine;

public class SocialButtons : MonoBehaviour
{
    private AudioManager audioManager;

    private void Start() {
        audioManager = AudioManager.instance;
    }

    public void OnHover()
    {
        audioManager.Play("Hover");
    }
    public void openYoutube()
    {
        audioManager.Play("Click");
        Application.OpenURL("https://www.youtube.com/channel/UCYxq9F0dj0_C43zl2tFbX2g");
    }
    public void openTwitter()
    {
        audioManager.Play("Click");
        Application.OpenURL("https://twitter.com/StudiosSykey");
    }
    public void openInstagram()
    {
        audioManager.Play("Click");
        Application.OpenURL("https://www.instagram.com/sykeystudios/");
    }
}
