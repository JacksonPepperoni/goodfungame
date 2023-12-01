using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Option_AudioVolume : MonoBehaviour
{

    private Animator animator;

    public AudioMixer audioMixer;

    public Slider slider_BGM;
    public Slider slider_SFX;

    public Toggle toggle_BGM;
    public Toggle toggle_SFX;

    public TMP_Text bgmVolumeText; //���� ũ�� ����. �Ⱦ��Ÿ� �̺��� ���°� �� ������
    public TMP_Text sfxVolumeText;

    string bgm = "BGM";
    string sfx = "SFX";


    public void Awake()
    {
        animator = GetComponent<Animator>();

    }

    public void Volume_BGM(float value)
    {

        if (!toggle_BGM.isOn) 
            audioMixer.SetFloat(bgm, Mathf.Log10(value) * 20); // audioMixer.SetFloat("SFX", i); �⺻ �ͼ��� �����ִ¹�

        bgmVolumeText.text = (slider_BGM.value * 100).ToString("N0");
    }

    public void Volume_SFX(float value)
    {
        if (!toggle_SFX.isOn) 
            audioMixer.SetFloat(sfx, Mathf.Log10(value) * 20);

        sfxVolumeText.text = (slider_SFX.value * 100).ToString("N0");

    }

    //-------------------------------------

    public void Mute_BGM(bool isMute)
    {
        toggle_BGM.isOn = isMute; //��Ŭ������ �Լ��� �����Ű�°�쵵�����ϱ� ��� �¿��� �ѹ��� �ٲ���

        if (isMute)
            audioMixer.SetFloat(bgm, -80f);
        else
            audioMixer.SetFloat(bgm, Mathf.Log10(slider_BGM.value) * 20);

    }

    public void Mute_SFX(bool isMute)
    {
        toggle_SFX.isOn = isMute;

        if (isMute)
            audioMixer.SetFloat(sfx, -80f);
        else
            audioMixer.SetFloat(sfx, Mathf.Log10(slider_SFX.value) * 20);
    }

    void Save()
    {

        // ���ũ�� = slider_BGM.value;
        // ������Ұ� =  muteToggle_BGM.isOn;

        //  sfxVolume = slider_SFX.value;
        //   sfxMute = muteToggle_SFX.isOn;

        // ����������

    }
    void Load()
    {

     //   slider_BGM.value = SaveManager.Instance.userData.bgmVolume; // ���̳������� �����ص� �� ó���� �������� �����̴� �Ű���ߵȴ� �Ѥ�
     //   slider_SFX.value = SaveManager.Instance.userData.sfxVolume;

      //  Volume_BGM(SaveManager.Instance.userData.bgmVolume);
      //  Mute_BGM(SaveManager.Instance.userData.bgmMute);

    //    Volume_SFX(SaveManager.Instance.userData.sfxVolume);
     //   Mute_SFX(SaveManager.Instance.userData.sfxMute);


    }



    public void Load_DefaultSetting()
    {
     //  Volume_BGM(dataCenter.bgmVolume);
     //   Mute_BGM(dataCenter.bgmMute);

      //  Volume_SFX(dataCenter.sfxVolume);
      //  Mute_SFX(dataCenter.sfxMute);


    }
}
