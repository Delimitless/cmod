using UnityEngine;
using System.Collections;

[RequireComponent (typeof (NotificationsManager))]
public class GameManager : Singleton<GameManager> {

    protected GameManager() { }

    private static NotificationsManager notifications = null;

    public static NotificationsManager Notifications {
        get {
            if (notifications == null) {
                notifications = GameManager.Instance.GetComponent<NotificationsManager>();
            }

            return notifications;
        }
    }
}
