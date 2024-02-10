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
        StartCoroutine(ChangeSignal());
    }

    private IEnumerator ChangeSignal()
    {
        while (true)
        {
            yield return new WaitForSeconds(red.duration);
            red.Deactivate();
            green.Activate();
            signalState = SignalState.Green;
            SetStopsTrafficActive(true);
            yield return new WaitForSeconds(green.duration);
            green.Deactivate();
            yellow.Activate();
            signalState = SignalState.Yellow;
            SetStopsTrafficActive(true);
            yield return new WaitForSeconds(yellow.duration);
            yellow.Deactivate();
            red.Activate();
            signalState = SignalState.Red;
            SetStopsTrafficActive(false);
        }
    }

    private void SetStopsTrafficActive(bool active)
    {
        foreach (GameObject stopTraffic in stopsTraffic)
        {
            stopTraffic.SetActive(active);
        }
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
