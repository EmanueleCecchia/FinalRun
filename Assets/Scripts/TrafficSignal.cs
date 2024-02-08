using System.Collections;
using UnityEngine;

public class TrafficSignal : MonoBehaviour
{
    [SerializeField] private Signal red;
    [SerializeField] private Signal yellow;
    [SerializeField] private Signal green;

    private void Start()
    {
        red.Activate();
        StartCoroutine(ChangeSignal());
    }

    private IEnumerator ChangeSignal()
    {
        while (true)
        {
            yield return new WaitForSeconds(red.duration);
            red.Deactivate();
            green.Activate();
            yield return new WaitForSeconds(green.duration);
            green.Deactivate();
            yellow.Activate();
            yield return new WaitForSeconds(yellow.duration);
            yellow.Deactivate();
            red.Activate();
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


