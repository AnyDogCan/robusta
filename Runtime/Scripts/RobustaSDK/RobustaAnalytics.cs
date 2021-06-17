using System;
using System.Collections.Generic;
using Facebook.Unity;
using Robusta.Interfaces;
using UnityEngine;

namespace Robusta
{
	public static class RobustaAnalytics
	{
		private static Settings _settings;

		private static readonly List<IAnalytics> Analytics = new List<IAnalytics> {new Robusta()};

		public static void Init(Settings settings)
		{
			_settings = settings;

			foreach (var analytic in Analytics)
			{
				analytic.Init(_settings);
			}

			FB.Init();
		}

		internal static event Action OnApplicationPaused;
		internal static event Action OnApplicationStarted;
		internal static event Action OnApplicationResumed;
		internal static event Action<string, string> OnCustomEvent;

		internal static void ApplicationPaused()
		{
			Debug.Log("RobustaAnalytics -> ApplicationPaused");
			OnApplicationPaused?.Invoke();
		}

		internal static void ApplicationStarted()
		{
			Debug.Log("RobustaAnalytics -> ApplicationStarted");
			OnApplicationStarted?.Invoke();
		}

		internal static void ApplicationResumed()
		{
			Debug.Log("RobustaAnalytics -> ApplicationResumed");
			OnApplicationResumed?.Invoke();
		}

		internal static void CustomEvent(string eventName, string value)
		{
			OnCustomEvent?.Invoke(eventName, value);
		}
	}
}