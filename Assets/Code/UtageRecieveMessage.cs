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
            case "matome1":
                TAmazime2.WinOff = true;
                break;
            case "matome3":
                TAmazime2.WinOff = true;
                break;
            case "matome4":
                TAmazime2.WinOff = true;
                break;
            case "kotae":
                student1.eventtwo_select = 1;
                sensei2.bamen = 3;
                break;
            case "hint":
                student1.eventtwo_select = 2;
                sensei2.bamen = 3;
                break;
            case "siryou":
                student1.eventtwo_select = 3;
                sensei2.bamen = 3;
                break;
            case "bamen4":
                sensei2.bamen = 4;
                break;
            case "bamen5":
                sensei2.bamen = 5;
                break;
            case "bamen6":
                sensei2.bamen = 6;
                Debug.Log(sensei2.bamen);
                TAmazime2.WinOff = false;
                break;
            case "riyu":
                student3.eventtwo_select = 1;                
                break;
            case "yare":
                student3.eventtwo_select = 2;
                break;
            case "help":
                student3.eventtwo_select = 3;
                break;
            case "takusan":
                student1.eventtwo_san = 1;
                break;
            case "rei":
                student1.eventtwo_san = 2;
                break;
            case "itikara":
                student1.eventtwo_san = 3;
                break;
            case "houkoku_P":
                student3.eventtwo_san = 1;
                break;
            case "mawaru":
                student3.eventtwo_san = 2;
                break;
            case "houkoku_TA":
                student3.eventtwo_san = 3;
                break;
            case "okosu":
                student4.eventtwo_select = 1;
                break;
            case "sensei_okosu":
                student4.eventtwo_select =2;
                break;
            case "igai":
                student4.eventtwo_select = 3;
                break;
            case "kogoe":
                student2.eventtwo_select = 1;
                break;
            case "tikaku":
                student2.eventtwo_select = 2;
                break;
            case "kyouin":
                student2.eventtwo_select = 3;
                break;
            case "kaesu":
                student2.eventtwo_san = 1;
                break;
            case "kyo":
                student2.eventtwo_san = 2;
                break;
            case "iu":
                student2.eventtwo_san =3;
                break;
            case "kakunin":
                student4.eventtwo_san = 1;
                break;
            case "nashi":
                student4.eventtwo_san = 2;
                break;
            case "sugu":
                student4.eventtwo_san = 3;
                break;
            case "endset":
                sensei.endset = true;
                break;
            case "bamen10":
                sensei2.bamen = 10;
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