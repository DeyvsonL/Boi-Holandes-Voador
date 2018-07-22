﻿using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BridgeSegmentScript : MonoBehaviour
{
	[SerializeField] private float _initialChance = 0.001f;
	[SerializeField] private float _finalChance = 0.006f;
	private SegmentStatusEnum _segmentStatus = SegmentStatusEnum.Healthy;
	
	
	
	private ParticleSystem particleSystem;
	
	public enum SegmentStatusEnum { Healthy = 0, Deteriorated = 1, Destroyed = 2 }

	public static bool Paused = false;

	private float _timeSinceStartConsideringPauses;

	private SpriteRenderer _spriteRenderer;

	public Sprite destroyedSprite;
	public Sprite deterioratedSprite;
	public Sprite healthySprite;

	[SerializeField] private bool isPillar;

    [SerializeField]
    private BoiVoadorScript boiVoador;

	public SegmentStatusEnum SegmentStatus
	{
		get { return _segmentStatus; }
		private set { _segmentStatus = value; }
	}

	// Use this for initialization
	private void Start()
	{

		var resourceString = isPillar ? "TijoloParticleSystem" : "ChaoParticleSystem";
		var obj = Instantiate(Resources.Load(resourceString), gameObject.transform) as GameObject;
		if (obj != null) particleSystem = obj.GetComponent<ParticleSystem>();
		else Debug.Log("Particle system not found!");



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
		switch (_segmentStatus)
		{
			case SegmentStatusEnum.Healthy:
				_spriteRenderer.sprite =  deterioratedSprite;
				_segmentStatus = SegmentStatusEnum.Deteriorated;
				particleSystem.Play();
				break;
			case SegmentStatusEnum.Deteriorated:
				_spriteRenderer.sprite =  destroyedSprite;
				_segmentStatus = SegmentStatusEnum.Destroyed;
				particleSystem.Play();
				break;
			case SegmentStatusEnum.Destroyed:
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	public float Repair()
	{
        var result = 1.0f;
		switch (_segmentStatus)
		{
			case SegmentStatusEnum.Healthy:
                result = 1.4f;
                break;
			case SegmentStatusEnum.Deteriorated:
				_spriteRenderer.sprite =  healthySprite;
				_segmentStatus = SegmentStatusEnum.Healthy;
                result = 1.15f;
				break;
			case SegmentStatusEnum.Destroyed:
				_spriteRenderer.sprite =  deterioratedSprite;
				_segmentStatus = SegmentStatusEnum.Deteriorated;
                result = 1.0f;
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
        return result;
	}
}
