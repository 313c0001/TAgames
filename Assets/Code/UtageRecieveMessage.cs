using UnityEngine;
using UnityEngine.UI;
using Utage;


/// <summary>
/// ADV用SendMessageコマンドから送られたメッセージを受け取る処理のサンプル
/// </summary>
[AddComponentMenu("Utage/ADV/Examples/UtageRecieveMessageSample")]
public class UtageRecieveMessage : MonoBehaviour
{
    public AdvEngine engine;            //Advエンジン本体
    public InputField inputFiled;       //テキスト入力用のオブジェクト

    void Awake()
    {
        inputFiled.gameObject.SetActive(false);
    }

    //SendMessageコマンドが実行されたタイミング
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

    //SendMessageコマンドの処理待ちタイミング
    void OnWait(AdvCommandSendMessage command)
    {
        switch (command.Name)
        {
            case "InputFileld":
                //インプットフィールドが有効な間は待機
                command.IsWait = inputFiled.gameObject.activeSelf;
                break;
            default:
                command.IsWait = false;
                break;
        }
    }

    //デバッグログを出力
    void DebugLog(AdvCommandSendMessage command)
    {
        Debug.Log(command.Arg2);
    }

    //設定された入力フィールドを有効化
    void InputFileld(AdvCommandSendMessage command)
    {
        inputFiled.gameObject.SetActive(true);
        inputFiled.onEndEdit.RemoveAllListeners();
        inputFiled.onEndEdit.AddListener((string text) => OnEndEditInputFiled(command.Arg2, text));
    }

    //入力終了。入力されたテキストを宴のパラメーターに設定する
    void OnEndEditInputFiled(string paramName, string text)
    {
        if (!engine.Param.TrySetParameter(paramName, text))
        {
            Debug.LogError(paramName + "is not found");
        }
        inputFiled.gameObject.SetActive(false);
    }
}