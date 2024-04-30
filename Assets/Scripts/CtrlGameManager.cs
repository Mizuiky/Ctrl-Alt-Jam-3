
using UnityEngine;

public class CtrlGameManager : Singleton<CtrlGameManager>
{
    #region Dialog

    [SerializeField]
    private DialogController _dialogController;
    public DialogController DialogController { get { return _dialogController; } }

    private InitializeDialogs _initializeDialogs;
    public InitializeDialogs InitializeDialogs { get { return _initializeDialogs; } }

    [SerializeField]
    private TextAsset _dialogFile;
    #endregion

    [SerializeField]
    private LocalizationManager _localizationManager;
    public LocalizationManager LocalizationManager { get { return _localizationManager; } }

    [SerializeField]
    private UIController _uiController;
    public UIController UIController { get { return _uiController; } }

    public void Start()
    {
        Init();    
    }

    private void Init()
    {
        _initializeDialogs = new InitializeDialogs();
        _initializeDialogs.Load(_dialogFile);

        _localizationManager.Init();

        _uiController.Init();

        _dialogController.Init();
    }
}
