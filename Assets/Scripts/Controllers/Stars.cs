using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms = new List<Transform>();
    public float drawingTime;

    int currentIndex = 0;
    float timer = 0f;
    bool lineDone = false;

    // Update is called once per frame
    void Update()
    {
        DrawConstellations();
    }

    public void DrawConstellations()
    {
        if (starTransforms.Count < 2)
        {
            return;
        }

        for (int i = 0; i < currentIndex; i++)
        {
            Vector3 a = starTransforms[i].position;
            Vector3 b = starTransforms[(i + 1) % starTransforms.Count].position;
            Debug.DrawLine(a, b, Color.white);
        }

        if (!lineDone)
        {
            Transform start = starTransforms[currentIndex];
            Transform end = starTransforms[(currentIndex + 1) % starTransforms.Count];

            timer += Time.deltaTime;
            float t = timer / drawingTime;
            t = Mathf.Clamp01(t);

            Vector3 currentEnd = Vector3.Lerp(start.position, end.position, t);
            Debug.DrawLine(start.position, currentEnd, Color.white);

            if (t >= 1f)
            {
                lineDone = true;
                timer = 0f;
                currentIndex++;

                if (currentIndex >= starTransforms.Count - 1)
                {
                    currentIndex = 0;
                }

                lineDone = false;
            }
        }
    }
}

