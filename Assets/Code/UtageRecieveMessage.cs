using UnityEngine;
using UnityEngine.UI;
using Utage;


/// <summary>
/// ADV�pSendMessage�R�}���h���瑗��ꂽ���b�Z�[�W���󂯎�鏈���̃T���v��
/// </summary>
[AddComponentMenu("Utage/ADV/Examples/UtageRecieveMessageSample")]
public class UtageRecieveMessage : MonoBehaviour
{
    public AdvEngine engine;            //Adv�G���W���{��
    public InputField inputFiled;       //�e�L�X�g���͗p�̃I�u�W�F�N�g

    void Awake()
    {
        inputFiled.gameObject.SetActive(false);
    }

    //SendMessage�R�}���h�����s���ꂽ�^�C�~���O
    void OnDoCommand(AdvCommandSendMessage command)
    {
        switch (command.Name)
        {
            case "DebugLog":
                DebugLog(command);                
                Player.StartPoint = true;
                break;
            case "InputFileld":
                InputFileld(command);
                break;
            case "startpoint":
                Player.StartPoint = true;
                break;
            default:
                Debug.Log("Unknown Message!!:" + command.Name);
                break;
        }
    }

    //SendMessage�R�}���h�̏����҂��^�C�~���O
    void OnWait(AdvCommandSendMessage command)
    {
        switch (command.Name)
        {
            case "InputFileld":
                //�C���v�b�g�t�B�[���h���L���ȊԂ͑ҋ@
                command.IsWait = inputFiled.gameObject.activeSelf;
                break;
            default:
                command.IsWait = false;
                break;
        }
    }

    //�f�o�b�O���O���o��
    void DebugLog(AdvCommandSendMessage command)
    {
        Debug.Log(command.Arg2);
    }

    //�ݒ肳�ꂽ���̓t�B�[���h��L����
    void InputFileld(AdvCommandSendMessage command)
    {
        inputFiled.gameObject.SetActive(true);
        inputFiled.onEndEdit.RemoveAllListeners();
        inputFiled.onEndEdit.AddListener((string text) => OnEndEditInputFiled(command.Arg2, text));
    }

    //���͏I���B���͂��ꂽ�e�L�X�g�����̃p�����[�^�[�ɐݒ肷��
    void OnEndEditInputFiled(string paramName, string text)
    {
        if (!engine.Param.TrySetParameter(paramName, text))
        {
            Debug.LogError(paramName + "is not found");
        }
        inputFiled.gameObject.SetActive(false);
    }
}