using UnityEngine;
using UnityEngine.Playables;

public class ReplayTimeline : MonoBehaviour
{
    public PlayableDirector playableDirector;

    void Update()
    {
        // Check if the "J" key is pressed
        if (Input.GetKeyDown(KeyCode.J))
        {
            // Stop the timeline (if it’s playing)
            playableDirector.Stop();

            // Reset the time to the beginning
            playableDirector.time = 0;

            // Replay the timeline
            playableDirector.Play();
        }
    }
}
