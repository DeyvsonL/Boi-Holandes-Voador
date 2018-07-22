using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BridgeSegmentScript : MonoBehaviour
{
	[SerializeField] private float _initialChance = 0.001f;
	[SerializeField] private float _finalChance = 0.006f;
	public SegmentStatusEnum SegmentStatus = SegmentStatusEnum.Healthy;
	
	public enum SegmentStatusEnum { Destroyed, Deteriorated, Healthy }

	public static bool Paused = false;

	private float _timeSinceStartConsideringPauses;

	private SpriteRenderer _spriteRenderer;

	public Sprite destroyedSprite;
	public Sprite deterioratedSprite;
	public Sprite healthySprite;

    [SerializeField]
    private BoiVoadorScript boiVoador;

	// Use this for initialization
	private void Start ()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_timeSinceStartConsideringPauses = 0;
	}

	// Update is called once per frame
	private void Update ()
	{
		if (Paused) return;

		_timeSinceStartConsideringPauses += Time.deltaTime;
        try
        {
            var currentChance = Mathf.Lerp(_initialChance, _finalChance, _timeSinceStartConsideringPauses / boiVoador.TimeInSeconds);
            if (!(Random.value <= currentChance)) return;
            Deteriorate();
        }
        catch (Exception e)
        {
            var game = gameObject;
            Debug.Log(e.Message);
        }

	}

	private void Deteriorate()
	{
		switch (SegmentStatus)
		{
			case SegmentStatusEnum.Healthy:
				_spriteRenderer.sprite =  deterioratedSprite;
				SegmentStatus = SegmentStatusEnum.Deteriorated;
				break;
			case SegmentStatusEnum.Deteriorated:
				_spriteRenderer.sprite =  destroyedSprite;
				SegmentStatus = SegmentStatusEnum.Destroyed;
				break;
			case SegmentStatusEnum.Destroyed:
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	public void Repair()
	{
		print("Repairing bridge segment!");
		switch (SegmentStatus)
		{
			case SegmentStatusEnum.Healthy:
				break;
			case SegmentStatusEnum.Deteriorated:
				_spriteRenderer.sprite =  healthySprite;
				SegmentStatus = SegmentStatusEnum.Healthy;
				break;
			case SegmentStatusEnum.Destroyed:
				_spriteRenderer.sprite =  deterioratedSprite;
				SegmentStatus = SegmentStatusEnum.Deteriorated;
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}
}
