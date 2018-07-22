using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public KeyCode LeftButton;
	public KeyCode RightButton;
	public KeyCode ActionButton;

	public List<BridgeSegmentScript> Objects = new List<BridgeSegmentScript>();

	private int _playerPosition;
	public static bool Paused = false;

    private SoundManager soundManager;

    [SerializeField]
    private int playerIndex;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    // Use this for initialization
    private void Start () {
		SetPosition(0);
	}

	private void Move(bool isRight)
	{
		if (isRight && _playerPosition < Objects.Count - 1)
		{
			SetPosition(_playerPosition + 1);
		} else if(!isRight && _playerPosition > 0)
		{
			SetPosition(_playerPosition - 1);
		}
	}

	private void SetPosition(int newPosition)
	{
		_playerPosition = newPosition;
		if (!(newPosition < Objects.Count)) return;
		var objectAtIndex = Objects[newPosition];
		transform.position = objectAtIndex.transform.position;
	}
	
	// Update is called once per frame
	private void Update ()
	{
		if (Paused) return;
		
		if (Input.GetKeyDown(LeftButton))
		{
			Move(false);
		}else if (Input.GetKeyDown(RightButton))
		{
			Move(true);
		}

		if (Input.GetKeyDown(ActionButton))
		{
			var selectedBridgeSegment = Objects[_playerPosition].GetComponent<BridgeSegmentScript>();
            var pitchValue = selectedBridgeSegment.Repair();
            if (playerIndex == 0) soundManager.PlayHammerOne(pitchValue);
            else soundManager.PlayHammerTwo(pitchValue);
		}
	}
}
