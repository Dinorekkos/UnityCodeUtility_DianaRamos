using System;
using DG.Tweening;
using Dino.Utility.Audio;
using UnityEngine;

//Legacy UI
namespace Dino.Utils
{ 
    /// <summary>
    ///  Obsolete: Use UIManager and UIWindow from Dino.UtilityTools.UI instead.
    ///  This class represents a menu window in the UI system, providing functionality to show and hide the window with animations.
    /// </summary>
    public class MenuWindowLegacy : MonoBehaviour
    {
        #region Serialized Fields

        [Header("Menu Window Settings")] 
        [SerializeField] private string windowID;
        [SerializeField] private Transform windowTransform;
        [SerializeField] private Canvas canvas;
        [SerializeField] private float duration = 0.5f;
        [SerializeField] private float delay = 0f;
        [SerializeField] private Ease showEase = Ease.OutBack;
        [SerializeField] private Ease hideEase = Ease.InBack;

        #endregion

        #region private variables

        public bool IsShowing => canvas.enabled;

        #endregion

        #region public variables
        
        public string WindowName => windowID;

        public Action OnStartShowingWindow;
        public Action OnFinishedShowingWindow;
        public Action OnStartHideWindow;
        public Action OnFinishedHideWindow;

        #endregion
        
        

        #region unity methods

        private void Start()
        {
            Initialize();
        }

        #endregion

        #region protected methods

        protected virtual void Initialize()
        {
            canvas.enabled = false;
            windowTransform.localScale = Vector3.zero;

        }

        #endregion

        #region public virtual methods

        public virtual void ShowWindow()
        {
            OnStartShowingWindow?.Invoke();
            canvas.enabled = true;
            windowTransform.DOScale(Vector3.one, duration).SetEase(showEase).SetDelay(delay).OnComplete(() =>
            {
                OnFinishedShowingWindow?.Invoke();
            });
            
            // AudioManager.Instance.PlaySound(AudioKeys.OPEN_WINDOW);
        }

        public virtual void HideWindow()
        {
            OnStartHideWindow?.Invoke();
            windowTransform.DOScale(Vector3.zero, duration).SetEase(hideEase).SetDelay(delay).OnComplete(() =>
            {
                canvas.enabled = false;
                OnFinishedHideWindow?.Invoke();
            });
            
            // AudioManager.Instance.PlaySound(AudioKeys.CLOSE_WINDOW);
        }

        #endregion

    }

    public class AudioKeys
    {
    }
}