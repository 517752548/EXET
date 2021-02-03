using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ETModel
{
	public static class ActionHelper
	{
		public static void Add(this Button.ButtonClickedEvent buttonClickedEvent, Action action)
		{
			buttonClickedEvent.AddListener(() => { action(); });
		}
		
		public static void Remove(this Button.ButtonClickedEvent buttonClickedEvent, Action action)
		{
			buttonClickedEvent.RemoveListener(() => { action(); });
		}
		
		public static void AddListeners(this BridgeEvent<PointerEventData> ClickedEvent, Action action)
		{
			ClickedEvent.AddListener((data) => { action(); });
		}
		

		public static void RemoveListeners(this BridgeEvent<PointerEventData> ClickedEvent, Action action)
		{
			ClickedEvent.AddListener((data) => { action(); });
		}
	}
}