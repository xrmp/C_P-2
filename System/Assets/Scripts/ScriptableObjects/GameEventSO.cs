using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Events/Game Event")]
public class GameEventSO : ScriptableObject
{
    private List<IGameEventListener> listeners = new List<IGameEventListener>();

    public void RegisterObserver(IGameEventListener listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    public void RemoveObserver(IGameEventListener listener)
    {
        if (listeners.Contains(listener))
        {
            listeners.Remove(listener);
        }
    }

    public void Notify()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventTriggered();
        }
    }
}