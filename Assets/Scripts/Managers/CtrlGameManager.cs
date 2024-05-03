using UnityEngine;

public class CtrlGameManager : Singleton<CtrlGameManager>
{
    [SerializeField] private DialogController _dialogController;
    [SerializeField] private LocalizationManager _localizationManager;
    [SerializeField] private UIController _uiController;
    [SerializeField] private TextAsset _dialogFile;

    private InitializeDialogs _initializeDialogs;

    public DialogController DialogController { get { return _dialogController; } } 
    public InitializeDialogs InitializeDialogs { get { return _initializeDialogs; } }    
    public LocalizationManager LocalizationManager { get { return _localizationManager; } }
    public UIController UIController { get { return _uiController; } }

    public void Start()
    {
        Init();    
    }

    private void Init()
    {
        _initializeDialogs = new InitializeDialogs();
        _initializeDialogs.Load(_dialogFile);

        _localizationManager?.Init();

        _uiController?.Init();

        _dialogController?.Init();
    }
}
