using UnityEngine;
using System.Collections.Generic;

public class NotificationsManager : MonoBehaviour {

    private Dictionary<string, List<Component>> listeners = new Dictionary<string, List<Component>>();

    public void AddListener(Component listener, string notificationName) {
        
        // Add listener to dictionary
        if (!listeners.ContainsKey(notificationName)) {
            listeners.Add(notificationName, new List<Component>());
        }

        // Add object to listener list for this notification
        listeners[notificationName].Add(listener);
    }

    public void RemoveListener(Component listener, string notificationName) {
        
        if (!listeners.ContainsKey(notificationName)) {
            return;
        }

        for (int i = listeners[notificationName].Count - 1; i >= 0; i--) {
            if (listeners[notificationName][i].GetInstanceID() == listener.GetInstanceID()) {
                listeners[notificationName].RemoveAt(i);
            }
        }
    }

    public void PostNotification(string notificationName) {

        if (!listeners.ContainsKey(notificationName)) {
            return;
        }

        foreach (Component listener in listeners[notificationName]) {
            listener.SendMessage(notificationName, SendMessageOptions.DontRequireReceiver);
        }
    }

    public void RemoveRedundancies() {
        
        Dictionary<string, List<Component>> tmpListeners = new Dictionary<string, List<Component>>();

        foreach (KeyValuePair<string, List<Component>> item in listeners) {
            for (int i = item.Value.Count - 1; i >= 0; i--) {
                if (item.Value[i] == null) {
                    item.Value.RemoveAt(i);
                }
            }

            if (item.Value.Count > 0) {
                tmpListeners.Add(item.Key, item.Value);
            }
        }

        listeners = tmpListeners;
    }

    public void ClearListeners() {
        listeners.Clear();
    }

    public void OnLevelWasLoaded() {
        RemoveRedundancies();
    }
}
