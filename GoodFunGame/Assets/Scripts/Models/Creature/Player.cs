using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature {

    #region Properties

    // Inputs.
    public Vector2 Input { get; protected set; }
    public Vector2 Velocity { get; protected set; }

    // Status.
    public float ExpMultiplier { get; protected set; }
    public float CollectDistance => 4.0f;   // TODO:: NO HARDCODING!

    // State.
    public int Level { get; private set; } = 1;
    public float Exp {
        get => _exp;
        set {
            _exp += (value - _exp) * ExpMultiplier;
            // ==================== ������ ó�� ====================
            int level = Level;
            while (true) {
                float requiredExp = Temp_GetRequiredExp(level + 1);
                if (requiredExp < 0 || _exp < requiredExp) break;
                level++;
            }
            if (level != Level) {
                Level = level;
                cbOnPlayerLevelUp?.Invoke();
            }
            // =====================================================

            cbOnPlayerDataUpdated?.Invoke();
        }
    }
    public float ExpRatio {
        get {
            float requiredExp = Temp_GetRequiredExp(Level + 1);
            if (requiredExp < 0) return 0;
            float currentTotalExp = Temp_GetRequiredExp(Level);
            return (Exp - currentTotalExp) / (requiredExp -  currentTotalExp);
        }
    }
    public int KillCount {
        get => _killCount;
        set {
            _killCount = value;
            cbOnPlayerDataUpdated?.Invoke();
        }
    }

    #endregion

    #region Fields

    // State.
    private float _exp;
    private int _killCount;

    // Callbacks.
    public Action cbOnPlayerLevelUp;
    public Action cbOnPlayerDataUpdated;

    #endregion

    #region MonoBehaviours



    #endregion

    #region Initialize / Set

    public override bool Initialize() {
        if (base.Initialize() == false) return false;

        return true;
    }

    public override void SetInfo(string key) {
        base.SetInfo(key);

        Level = 1;
        Exp = 0;
    }

    #endregion


    /// <summary>
    /// �ش� ������ �����ϱ� ���� �ʿ��� ����ġ��
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    // TODO:: LevelData�� �����ϴ� ����� ã�ƺ���!
    private float Temp_GetRequiredExp(int level) {
        // �ִ� �����̶�� return -1;
        // 0 �����̶�� return 0;
        return 1;
    }
}