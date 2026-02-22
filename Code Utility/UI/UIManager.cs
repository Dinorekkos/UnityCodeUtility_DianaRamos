using System.Collections.Generic;
using UnityEngine;


namespace Dino.UtilityTools.UI
{
    /// <summary>
    /// Last Update 21/02/2026 Dino
    /// Main class to manage all UI windows in the scene.
    /// It allows showing, hiding, and retrieving UI windows by their unique identifiers.
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private List<UIWindow> uiWindows = new List<UIWindow>();

        public void ShowUI(string windowUI)
        {
            foreach (var window in uiWindows)
            {
                if (window.WindowID == windowUI)
                {
                    window.Show();
                    return;
                }
            }

            Debug.LogWarning($"UI Window with name {windowUI} not found.");
        }

        public void HideUI(string windowUI)
        {
            foreach (var window in uiWindows)
            {
                if (window.WindowID == windowUI)
                {
                    window.Hide();
                    return;
                }
            }

            Debug.LogWarning($"UI Window with name {windowUI} not found.");
        }

        public UIWindow GetUIWindow(string windowUI)
        {
            foreach (var window in uiWindows)
            {
                if (window.WindowID == windowUI)
                {
                    return window;
                }
            }

            Debug.LogWarning($"UI Window with name {windowUI} not found.");
            return null;
        }

        #region Editor

        private void GetAllUIWindows()
        {
            uiWindows.Clear();
            UIWindow[] windows = FindObjectsByType<UIWindow>(FindObjectsSortMode.InstanceID);
            uiWindows.AddRange(windows);
        }

        #endregion
    }
    
    public static class WindowsIDs
    {
        public static string Popup = "PopupUI";

    }
}