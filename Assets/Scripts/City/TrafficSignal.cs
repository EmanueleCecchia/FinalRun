using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSignal : MonoBehaviour
{
    public enum SignalState
    {
        Red,
        Yellow,
        Green
    }
    public SignalState signalState;

    [SerializeField] private List<GameObject> stopsTraffic = new List<GameObject>();

    [SerializeField] private Signal red;
    [SerializeField] private Signal yellow;
    [SerializeField] private Signal green;

    private void Start()
    {
        red.Activate();
        signalState = SignalState.Red;
        SetStopsTrafficActive(false);
        StartCoroutine(SignalChanges());
    }
    private void SetStopsTrafficActive(bool active)
    {
        foreach (GameObject stopTraffic in stopsTraffic)
        {
            stopTraffic.SetActive(active);
        }
    }

    private IEnumerator SignalChanges()
    {
        while (true)
        {
            yield return new WaitForSeconds(red.duration);
            ChangeSignal(red, green, SignalState.Green, true);
            yield return new WaitForSeconds(green.duration);
            ChangeSignal(green, yellow, SignalState.Yellow, true);
            yield return new WaitForSeconds(yellow.duration);
            ChangeSignal(yellow, red, SignalState.Red, false);
        }
    }

    private void ChangeSignal(Signal deactivate, Signal activate, SignalState state, bool stopsTrafficActive)
    {
        deactivate.Deactivate();
        activate.Activate();
        signalState = state;
        SetStopsTrafficActive(stopsTrafficActive);
    }

    [System.Serializable]
    protected class Signal
    {
        public GameObject signalObject;
        public float duration;

        public void Activate()
        {
            signalObject.SetActive(true);
        }

        public void Deactivate()
        {
            signalObject.SetActive(false);
        }
    }
}
