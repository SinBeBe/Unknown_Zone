using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameManager : MonoBehaviour
{
    // 싱글톤
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("[GameManager] Instance가 존재하지 않습니다.");
            return _instance;
        }
    }

    [Header("Game Data")]
    [SerializeField] private PlayerData playerData;

    [Header("Candles & Ghost")]
    [SerializeField] private List<GameObject> candleLights = new List<GameObject>();
    [SerializeField] private GameObject ghostSpirit;

    [Header("Items")]
    public List<GameObject> items = new List<GameObject>();

    [Header("Ending Scene")]
    [SerializeField] private CinemachineVirtualCamera[] virtualCameras;
    [SerializeField] private CinemachineDollyCart dollyCart;

    // --- Player 상태 ---
    private const float MaxStamina = 100f;
    private float stamina = MaxStamina;
    private const float RegenRate = 5f;
    private const float DecreaseRate = 7f;

    public float PlayerSpeed { get; private set; }
    public float DamagePercent { get; private set; }

    public bool IsUsedItem { get; set; }
    public bool IsEnemyLimit { get; set; }
    public bool IsPlayerLimit { get; set; }
    public bool IsKilledGhost { get; set; }
    public bool IsFindKnife { get; set; }
    public bool IsFindSoul { get; set; }
    public bool IsPlayerHide { get; set; }
    public bool IsExhausted { get; private set; }

    private int candleIndex = -1;

    // --- 이벤트 ---
    public event Action OnGameOverEvent;
    public event Action<string> OnGameEndEvent;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject); // 필요 시 유지
    }

    private void Start()
    {
        if (playerData != null)
        {
            PlayerSpeed = playerData.Speed;
            DamagePercent = playerData.DamagePercent;
        }
    }

    #region Player Stamina
    public float GetPlayerStamina(bool isRunning)
    {
        if (isRunning && stamina > 0 && !IsExhausted)
        {
            stamina -= DecreaseRate * Time.deltaTime;

            if (stamina <= 0)
            {
                stamina = 0;
                IsExhausted = true;
            }
        }
        else
        {
            if (stamina < MaxStamina)
            {
                stamina += RegenRate * Time.deltaTime;
                if (stamina >= 30f) IsExhausted = false;
            }
        }

        stamina = Mathf.Clamp(stamina, 0f, MaxStamina);
        return stamina / MaxStamina;
    }
    #endregion

    #region Candle & Ghost
    public void ActivateNextCandle()
    {
        candleIndex++;
        if (candleIndex >= 0 && candleIndex < candleLights.Count)
        {
            candleLights[candleIndex].SetActive(true);
        }

        if (candleIndex == 4 && ghostSpirit != null)
        {
            ghostSpirit.SetActive(true);
        }
    }
    #endregion

    #region Utility
    public void ToggleComponents<T>(string tag, bool isEnabled) where T : MonoBehaviour
    {
        var objects = GameObject.FindGameObjectsWithTag(tag);
        foreach (var obj in objects)
        {
            if (obj.TryGetComponent<T>(out var component))
            {
                component.enabled = isEnabled;
            }
        }
    }

    public void SetCursorState(CursorLockMode mode, bool isVisible)
    {
        Cursor.lockState = mode;
        Cursor.visible = isVisible;
    }
    #endregion

    #region Game Flow
    public void GameOver()
    {
        OnGameOverEvent?.Invoke();
        StartCoroutine(UIManager.instance.GameOver());
        SetCursorState(CursorLockMode.None, true);
        Time.timeScale = 1f;
    }

    public void GameClear()
    {
        string endingType;

        if (!IsKilledGhost && !IsFindSoul)
        {
            endingType = "BadEnding";
            BadEnding();
        }
        else if ((!IsKilledGhost && IsFindSoul) || (IsKilledGhost && !IsFindSoul))
        {
            endingType = "NormalEnding";
            NormalEnding();
        }
        else
        {
            endingType = "HappyEnding";
            HappyEnding();
        }

        OnGameEndEvent?.Invoke(endingType);
        StartCoroutine(UIManager.instance.GameEnd(endingType));
    }

    private void BadEnding() => SceneManager.LoadScene("MainScene");
    private void NormalEnding() => SceneManager.LoadScene("MainScene");

    private void HappyEnding()
    {
        SceneManager.LoadScene("HappyEndingScene");
        StartCoroutine(EndingSequence());
    }

    private IEnumerator EndingSequence()
    {
        if (virtualCameras.Length < 2 || dollyCart == null) yield break;

        virtualCameras[0].Priority = 5;

        while (dollyCart.m_Path.PathLength - dollyCart.m_Position > 0.01f)
            yield return null;

        virtualCameras[1].Priority = 4;
    }
    #endregion
}
