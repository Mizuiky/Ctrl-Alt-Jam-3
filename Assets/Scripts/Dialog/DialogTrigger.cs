using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    private bool hasDialogStarted = false;

    [SerializeField]
    private int _dialogRoot;

    [SerializeField]
    private KeyCode _dialogKey;

    public void OnTriggerEnter2D(Collider2D other)
    {
       
    }

    public void OnTriggerStay2D(Collider2D other)
    { 
        if (_dialogRoot != -1)
        {
            if (!hasDialogStarted && Input.GetKeyDown(_dialogKey))
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    Debug.Log("Trigger Player");
                    hasDialogStarted = true;
                    CtrlGameManager.Instance.DialogController.StartDialog(_dialogRoot);
                }
            }           
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        CtrlGameManager.Instance.DialogController.OnEndDialog();
        hasDialogStarted = false;    
    }
}
