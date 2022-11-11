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

            case "senseifirst":
                sensei.senseihantei = 1;
                break;
            case "TAmazime_one":
                TAmazime_one.gotit = true;
                break;
            case "TAsintyo_one":
                TAsintyo_one.gotit = true;
                break;
            case "TAman_one":
                TAman.gotit = true;
                break;
            case "RoomStart":
                RoomStart.gotit = true;
                break;
            case "one_matsu":
                student1.eventone_select = 1;
                break;
            case "one_yobu":
                student1.eventone_select = 2;
                break;
            case "one_hoka":
                student1.eventone_select = 3;
                break;
            case "one_matu":
                student1.eventone_select = 4;
                break;
            case "G2":
                sensei2.Groupe = 2;
                break;
            case "G3":
                sensei2.Groupe = 3;
                break;
            case "G4":
                sensei2.Groupe = 4;
                break;
            case "tyuui":
                student2.eventone_select = 1;
                sensei2.oneday2ndON = true;                
                break;
            case "miru":
                student2.eventone_select = 2;
                sensei2.oneday2ndON = true;
                break;
            case "houru":
                student2.eventone_select = 3;
                sensei2.oneday2ndON = true;
                break;
            case "ex":
                student3.eventone_select = 1;
                sensei2.oneday2ndON = true;
                break;
            case "keizoku":
                student3.eventone_select = 2;
                sensei2.oneday2ndON = true;
                break;
            case "kiku":
                student3.eventone_select = 3;
                sensei2.oneday2ndON = true;
                break;
            case "zenin":
                student4.eventone_select = 1;
                sensei2.oneday2ndON = true;
                break;
            case "haire":
                student4.eventone_select = 2;
                sensei2.oneday2ndON = true;
                break;
            case "simei":
                student4.eventone_select = 3;
                sensei2.oneday2ndON = true;
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