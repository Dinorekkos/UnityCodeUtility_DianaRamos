using UnityEngine;
using UnityEngine.Events;

namespace Dino.UtilityTools.UI
{ 
    /// <summary>
    ///  Last update 21/02/2026 Dino
    /// This class represents a UI window in the UI system, providing functionality to show and hide the window.
    /// </summary>
    public class UIWindow : MonoBehaviour
    {
        [Header("UI Window")] 
        [SerializeField] private string windowID;
        [SerializeField] private Canvas windowCanvas;
        [SerializeField] private CanvasGroup windowCanvasGroup;

        [Header("Settings")] 
        [SerializeField] private bool hideOnStart = true;
        

        #region Events

        public UnityEvent OnStartShowingUI { get; private set; } = new UnityEvent();
        public UnityEvent OnFinishedShowingUI { get; private set; } = new UnityEvent();

        public UnityEvent OnStartHidingUI { get; private set; } = new UnityEvent();
        public UnityEvent OnFinishedHidingUI { get; private set; } = new UnityEvent();

        #endregion


        public bool IsShowing { get; private set; } = false;
        public string WindowID => windowID;



        private void Start()
        {
            Initialize();
        }

        protected virtual void Initialize()
        {
            if(hideOnStart) Hide(true);
        
        }
        public virtual void Show(bool instant = false)
        {
            windowCanvas.gameObject.SetActive(true);
        }
    
        public virtual void Hide(bool instant = false)
        {
            windowCanvas.gameObject.SetActive(false);
        }



    }
}
