using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoiVoadorScript : MonoBehaviour
{
    [SerializeField] public float TimeInSeconds = 10;
    private Vector3 _origin;
    private Vector3 _target;
    
    public float Frequency;  // Speed of sine movement
    public float Magnitude;   // Size of sine movement

    public static bool Paused;

    private float _timeSinceStartConsideringPauses;

    public bool Finished;

    [SerializeField]
    private List<GameObject> fireworksList;

    // Use this for initialization
    private void Start()
    {
        Frequency = 1.0f;
        Magnitude = 0.2f;
        
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
        if (Paused || Finished) return;

        _timeSinceStartConsideringPauses += Time.deltaTime;
        transform.position = Vector3.Lerp(_origin, _target, _timeSinceStartConsideringPauses / TimeInSeconds);
        transform.position = transform.position + transform.up * Mathf.Sin (Time.time * Frequency) * Magnitude;
        if (transform.position.x >= _target.x)
        {
            foreach (var fireworks in fireworksList) {
                fireworks.SetActive(true);
            }
            Invoke("LoadVictoryScene", 5);
        }
    }

    private void LoadVictoryScene()
    {
        SceneManager.LoadScene("VictoryScene");
    }

}
