using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneEnd : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public float waitTime = 3f;

    private void Start()
    {
        StartCoroutine(PlayTimelineRoutine(playableDirector, EndSceneDone));
    }

    private IEnumerator PlayTimelineRoutine(PlayableDirector playableDirector, Action onComplete)
        {
            playableDirector.Play();
            yield return new WaitForSeconds((float)playableDirector.duration + waitTime);
        onComplete.Invoke();
        }

    private void EndSceneDone()
    {
        ScenesManager.instance.LoadScene("Start Menu");
    }
}
