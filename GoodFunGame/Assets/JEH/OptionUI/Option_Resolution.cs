using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Option_Resolution : MonoBehaviour
{

    private Animator animator;

    public TMP_Dropdown resolutionDropdown;
    public Toggle fullScreenToggle;

    private List<Resolution> resolutions; //�ػ� ���

    private int resolutionNumSet;
    private int resolutionNum; //�ػ� ���� ����Ҷ� ����ϴ¿�

    private FullScreenMode screenMode; //Screen.fullScreenMode�� �ƿ� �� �� ���α׷��� ����â�� ���ϴ°Ű��Ƽ� ���� ���̳�. ����ó�������� �����س��� ����ҵ�.


    // ---------�Ʒ��� �ػ� ���� Ȯ��â ��

    public GameObject ResolutionQestion; // �ػ� �����Ұ��� Ȯ��â
    public TMP_Text countdownTxt;
    private float countdown;
    private WaitForSeconds oneSec;



    public void Awake()
    {
        animator = GetComponent<Animator>();
        resolutions = new List<Resolution>();
        oneSec = new WaitForSeconds(1f);
    }
    void Start()
    {
        Init();
        ResolutionQestion.SetActive(false);

    }


    int Gcd(int n, int m) // a�� b�� �ִ����� ���. �ػ� �������
    {
        //�� �� n, m �� ���� �� ��� �� ���� 0�� �� �� ����
        //gcd(m, n%m) �� ����Լ� �ݺ�
        if (m == 0) return n;
        else return Gcd(m, n % m);
    }

    //=======================================================================


    void Init() // �ػ󵵸�� ���� ��ӹڽ��� �߰�
    {
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            resolutions.Add(Screen.resolutions[i]);
        }

        resolutionDropdown.options.Clear();


        for (int i = 0; i < resolutions.Count; i++)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();

            //�ػ� �������
            option.text = resolutions[i].width + "x" + resolutions[i].height + " " +
                resolutions[i].width / Gcd(resolutions[i].width, resolutions[i].height) + ":" + resolutions[i].height / Gcd(resolutions[i].width, resolutions[i].height) + " " +
                resolutions[i].refreshRateRatio.value.ToString("F0") + "hz";

            //refreshRate���� refreshRateRatio ����� �����Ʃ����� �׷��µ� ���ž��� 59.213123123�̷� ���ļ��� ���ͼ� ������. �׷��� �Ҽ���¥��

            resolutionDropdown.options.Add(option);
            resolutionDropdown.value = i;

        }

        resolutionDropdown.RefreshShownValue();

    }




    public void Resolution_Dropbox(int num) // �ػ� ��ӹڽ��� ���̳��� ����3+1  / �ػ� ��Ͽ��� ���ø� �ϴ°Ű� �Ʒ� Resolution_Preview() ���� ���� ���� �Ŀ� ����� �ػ� �����. ��ӹڽ� ��Ŭ���� �̰Ŷ� ������ �Ѵ� �޷�����
    {
        resolutionNumSet = num;
        resolutionDropdown.value = num; // �ػ󵵸�Ͽ� üũ��ũ�� ����

    }



    public void Save()
    {
        resolutionNum = resolutionNumSet;
        resolutionDropdown.value = resolutionNum;

      //  SaveManager.Instance.userData.gameScreenSizeNumber = resolutionNum;
      //  SaveManager.Instance.SaveUserDataToJson();
    }

    public void Load()
    {
        /*

        if (SaveManager.Instance.userData.gameScreenSizeNumber >= resolutions.Count + 10) // �ػ󵵼��ڰ� �ػ󵵸�� �������� ũ�� �⺻�ػ�
        {
            resolutionNum = resolutions.Count - 1;
            Resolution_Dropbox(resolutions.Count - 1); //���̺꿡 �ػ� �⺻���̸� �� ū ȭ������
        }
        else
        {
            resolutionNum = SaveManager.Instance.userData.gameScreenSizeNumber; //���� ������ �������ֱ�
            Resolution_Dropbox(SaveManager.Instance.userData.gameScreenSizeNumber);
        }

        */
    }




    //---------------------�ػ� ���� Ȯ��â -----------------------

    public void Resolution_Preview() // �ػ� ��� ���� ���� ��ư�� �ް�
    {
        Screen.SetResolution(resolutions[resolutionNumSet].width, resolutions[resolutionNumSet].height, screenMode);

        StartCoroutine("PreviewCountdown");

    }
    IEnumerator PreviewCountdown()
    {
        ResolutionQestion.SetActive(true);

        countdown = 10;
        countdownTxt.text = countdown.ToString();

        while (true)
        {
            if (countdown <= 0) //0�ʵǸ� �ػ󵵺������
            {
                Resolution_NOPE();
                break;
            }

            yield return oneSec;

            countdown--;
            countdownTxt.text = countdown.ToString();

        }
    }
    public void Resolution_OK() // �ػ� ������� â���� "��" �ػ� �����ϰ� ����
    {
        StopAllCoroutines();
        Save();

        ResolutionQestion.SetActive(false);
    }

    public void Resolution_NOPE() // �ػ� ������� â���� "�ƴϿ�"
    {
        StopAllCoroutines();

        resolutionDropdown.value = resolutionNum;
        Screen.SetResolution(resolutions[resolutionNum].width, resolutions[resolutionNum].height, screenMode);

        ResolutionQestion.SetActive(false);
    }

    public void FullScreenToggle(bool On) // ��üȭ�� ��ۿ� ���̳��� ����
    {
        fullScreenToggle.isOn = On;
        screenMode = On ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
        Screen.fullScreen = On;

     //   SaveManager.Instance.userData.isFullscreen = On;
     //   SaveManager.Instance.SaveUserDataToJson();
    }



    public void DefaultSetting()
    {

     //   FullScreenToggle(dataCenter.isFullscreen);

        resolutionDropdown.value = resolutions.Count - 1;

        Resolution_Dropbox(resolutions.Count - 1); //���̺꿡 �ػ� �⺻���̸� �� ū ȭ������

        Save();

        Screen.SetResolution(resolutions[resolutionNumSet].width, resolutions[resolutionNumSet].height, screenMode);


    }

}


