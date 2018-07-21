using UnityEngine;

public class BoiVoadorScript : MonoBehaviour
{
    [SerializeField] public float TimeInSeconds = 10;
    private Vector3 _origin;
    private Vector3 _target;

    public static bool Paused;

    private float _timeSinceStartConsideringPauses;

    // Use this for initialization
    private void Start()
    {
        _timeSinceStartConsideringPauses = 0;

        _origin = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0.7f, 0f));
        _origin.z = 0;
        transform.position = _origin;

        _target = Camera.main.ViewportToWorldPoint(new Vector3(0.9f, 0.7f, 0f));
        _target.z = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Paused) return;

        _timeSinceStartConsideringPauses += Time.deltaTime;
        transform.position = Vector3.Lerp(_origin, _target, _timeSinceStartConsideringPauses / TimeInSeconds);
    }
}
