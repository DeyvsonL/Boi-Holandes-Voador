using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnHighlightSoundScript : MonoBehaviour,IPointerEnterHandler, ISelectHandler
{

	[SerializeField]
	private AudioSource Source;


	public void OnPointerEnter(PointerEventData ped)
	{
		Source.Play();
	}

	public void OnSelect(BaseEventData eventData)
	{
		Source.Play();
	}
}
