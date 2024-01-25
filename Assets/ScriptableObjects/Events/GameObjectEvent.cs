using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Events", menuName = "Events/GameObject Event", order = 0)]
public class GameObjectEvent : ScriptableObjectBase {
    public UnityAction<GameObject> onEventRaised;
    public void RaiseEvent(GameObject obj) {
        onEventRaised?.Invoke(obj);
    }
    public void Subscribe(UnityAction<GameObject> function) {
        onEventRaised += function;
    }
    public void Unsubscribe(UnityAction<GameObject> function) {
        onEventRaised -= function;
    }
}