using UnityEngine;

public class ControlExample : MonoBehaviour
{
    public AudioClip clip_1,clip_2;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SoundManager.instance.AddSound("sound1", clip_1);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            SoundManager.instance.AddSound("sound2", clip_2);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SoundManager.instance.PlaySound("sound1");
            //AudioManager.Instance.PlayClip("ExampleSound2");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            SoundManager.instance.PlaySound("sound2");
            //AudioManager.Instance.PlayClip("ExampleSound2");
        }
    }
}
