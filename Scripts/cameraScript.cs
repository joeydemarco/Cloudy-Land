using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public Transform[] cameraPoses;
    bool paused;

    public IEnumerator moveCamera()
    {
        paused = false;
        foreach (Transform foo in cameraPoses)
        {
            // saves the camera current position and size
            Vector3 oldPos = Camera.main.transform.position;
            float oldSize = Camera.main.orthographicSize;

            // freezes time and zooms out/in
            Time.timeScale = 0f;
            for (float i = 0f; i <1f; i += 0.02f)
            {
                Camera.main.transform.position = Vector3.Lerp(oldPos, foo.position, i / 1f);
                Camera.main.orthographicSize = Mathf.Lerp(oldSize, foo.localScale.x, i / 1f);
                yield return new WaitForSecondsRealtime(0.02f);
            }

            // waits a moment before zooming back in and returning time to normal
            if (paused == false)
                yield return new WaitForSecondsRealtime(1.5f);
            Time.timeScale = 1f;
            paused = true;
        }
    }
}
