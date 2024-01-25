using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COR : MonoBehaviour
{
    [SerializeField] private float time = 3;
    Coroutine timerGuy;
    private void Start() {
        StartCoroutine(Timer(time));
        timerGuy = StartCoroutine(StoryTime());
        StopCoroutine(Timer(1));
        timerGuy = null;
    }
    
    IEnumerator Timer(float time) {
        for (;;) {
            yield return new WaitForSeconds(time);

        }
    }
    IEnumerator StoryTime() {
        print("hello");
        yield return new WaitForSeconds(0.1f);
        print("hello");
        yield return new WaitForSeconds(0.2f);
        print("hello");
        yield return new WaitForSeconds(0.4f);
        print("hello");
        yield return new WaitForSeconds(0.8f);
        yield return null;
    }
    IEnumerator WaitAction() {
        yield return new WaitUntil(() => true);
    }
}
