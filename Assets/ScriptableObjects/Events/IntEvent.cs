using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Events", menuName = "Events/Int Event", order = 0)]
public class IntEvent : ScriptableObjectBase {
    public UnityAction<int> onEventRaised;
    public void RaiseEvent(int value) {
        onEventRaised?.Invoke(value);
    }
    public void Subscribe(UnityAction<int> function) {
        onEventRaised += function;
    }
    public void Unsubscribe(UnityAction<int> function) {
        onEventRaised -= function;
    }
}