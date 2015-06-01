using UnityEngine;
using System.Collections.Generic;

public class NotificationsManager : MonoBehaviour {

    private Dictionary<string, List<Component>> Listeners = new Dictionary<string, List<Component>>();

    public void AddListener(Component listener, string notificationName) {
        
        // Add listener to dictionary
        if (!Listeners.ContainsKey(notificationName)) {
            Listeners.Add(notificationName, new List<Component>());
        }

        // Add object to listener list for this notification
        Listeners[notificationName].Add(listener);
    }
}
