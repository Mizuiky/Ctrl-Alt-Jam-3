using System;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private DialogBox _dialogBox;

    public Action onContinueDialog;

    public void Init()
    {
        CtrlGameManager.Instance.DialogController.onStartDialog += OpenDialogBox;
        CtrlGameManager.Instance.DialogController.onEndDialog += CloseDialogBox;
        CtrlGameManager.Instance.DialogController.onUpdateOptions += SetDialogOptions;
        CtrlGameManager.Instance.DialogController.onEnableNextButton += HideOptions;
        CtrlGameManager.Instance.DialogController.onChangePortrait += UpdatePortrait;

        DialogOption.onChooseOption += SelectOption;

        _dialogBox.Init();
    }

    public void Reset()
    {
        _dialogBox.ResetFields();
    }

    #region DialogBox

    public void OpenDialogBox()
    {
        _dialogBox.SetBoxVisibility(true);
    }

    public void CloseDialogBox()
    {
        _dialogBox.SetBoxVisibility(false);
    }

    public void SetDialogOptions(List<Option> options)
    {
        _dialogBox.SetOptions(options);
    }

    public void HideOptions()
    {
        _dialogBox.HideDialogOptions();
    }

    public void UpdatePortrait(Sprite newPortrait)
    {
        _dialogBox.ChangePortrait(newPortrait);
    }

    public void SelectOption(int option)
    {
        Debug.Log($"next dialog index: {option}");
        CtrlGameManager.Instance.DialogController.ChangeToNextDialog(option);
    }

    public void OnContinueDialog()
    {
        onContinueDialog?.Invoke();
    }

    #endregion

    private void OnDisable()
    {
        CtrlGameManager.Instance.DialogController.onStartDialog -= OpenDialogBox;
        CtrlGameManager.Instance.DialogController.onEndDialog -= CloseDialogBox;
        CtrlGameManager.Instance.DialogController.onUpdateOptions -= SetDialogOptions;
        CtrlGameManager.Instance.DialogController.onEnableNextButton -= HideOptions;
        CtrlGameManager.Instance.DialogController.onChangePortrait -= UpdatePortrait;

        DialogOption.onChooseOption -= SelectOption;
    }
}
