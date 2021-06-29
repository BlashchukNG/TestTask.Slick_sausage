using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace testtask.sausage
{
    public sealed class StartMenuView :
        MonoBehaviour,
        IStartMenuView
    {
        private const string MODE_3D_TEXT = "3D";
        private const string MODE_2D_TEXT = "2D";


        [Header("Buttons")]
        [SerializeField] private Button _btnStart;
        [SerializeField] private Button _btnShop;
        [SerializeField] private Button _btnLeaderboard;
        [SerializeField] private Button _btnMusic;
        [SerializeField] private Button _btnChangeMode;
        [SerializeField] private Button _btnWeather;
        [Header("Sprites")]
        [SerializeField] private Sprite _sprMusicOn;
        [SerializeField] private Sprite _sprMusicOff;
        [SerializeField] private Sprite _sprWeatherSunny;
        [SerializeField] private Sprite _sprWeatherCloudy;
        [SerializeField] private Sprite _sprWeatherRainy;
        [SerializeField] private Sprite _sprWeatherStorm;

        private Canvas _cnsMenu;
        private TMP_Text _txtChangeMode;
        private Image _imgMusic;
        private Image _imgWeather;

        private SaveData _saveData;

        public event Action OnStartClick = () => { };
        public event Action OnShopClick = () => { };
        public event Action OnLeaderboardClick = () => { };
        public event Action<MusicState> OnMusicClick = context => { };
        public event Action<ModeType> OnChangeModeClick = context => { };
        public event Action<WeatherType> OnWeatherClick = context => { };


        private void Start()
        {
            _btnStart.onClick.AddListener(StartGame);
            _btnShop.onClick.AddListener(ToShop);
            _btnLeaderboard.onClick.AddListener(ToLeaderboard);
            _btnMusic.onClick.AddListener(MusicOnOff);
            _btnChangeMode.onClick.AddListener(ChangeMode);
            _btnWeather.onClick.AddListener(ChangeWeather);

            TryGetComponent(out _cnsMenu);
            _btnMusic.TryGetComponent(out _imgMusic);
            _btnWeather.TryGetComponent(out _imgWeather);

            _txtChangeMode = _btnChangeMode.GetComponentInChildren<TMP_Text>();
        }


        private void LoadSettings(SaveData data)
        {
            _saveData = data;

            SetWeather(_saveData.Weather);
            SetMode(_saveData.Mode);
            SetMusic(_saveData.Music);
        }
        private void SetWeather(WeatherType type)
        {
            switch (type)
            {
                case WeatherType.Sun:
                    _imgWeather.sprite = _sprWeatherSunny;
                    break;
                case WeatherType.Cloud:
                    _imgWeather.sprite = _sprWeatherCloudy;
                    break;
                case WeatherType.Rain:
                    _imgWeather.sprite = _sprWeatherRainy;
                    break;
                case WeatherType.Storm:
                    _imgWeather.sprite = _sprWeatherStorm;
                    break;
                default:
                    throw new InvalidOperationException("Weather settings is wrong");
            }
            OnWeatherClick.Invoke(type);
        }
        private void SetMode(ModeType type)
        {
            switch (type)
            {
                case ModeType.Mode2D:
                    _txtChangeMode.text = MODE_2D_TEXT;
                    break;
                case ModeType.Mode3D:
                    _txtChangeMode.text = MODE_3D_TEXT;
                    break;
                default:
                    throw new InvalidOperationException("Mode settings is wrong");
            }
            OnChangeModeClick.Invoke(type);
        }
        private void SetMusic(MusicState state)
        {
            switch (state)
            {
                case MusicState.On:
                    _imgMusic.sprite = _sprMusicOn;
                    break;
                case MusicState.Off:
                    _imgMusic.sprite = _sprMusicOff;
                    break;
                default:
                    throw new InvalidOperationException("Music settings is wrong");
            }
            OnMusicClick.Invoke(state);
        }

        #region ButtonsListeners

        private void StartGame()
        {
            OnStartClick.Invoke();
        }
        private void ToShop()
        {
            _cnsMenu.enabled = false;

            OnShopClick.Invoke();
        }
        private void ToLeaderboard()
        {
            OnLeaderboardClick.Invoke();
        }
        private void MusicOnOff()
        {
            switch (_saveData.Music)
            {
                case MusicState.On:
                    _imgMusic.sprite = _sprMusicOff;
                    OnMusicClick.Invoke(MusicState.Off);
                    break;
                case MusicState.Off:
                    _imgMusic.sprite = _sprMusicOn;
                    OnMusicClick.Invoke(MusicState.On);
                    break;
                default:
                    throw new InvalidOperationException("Music settings is wrong");
            }
        }
        private void ChangeMode()
        {
            switch (_saveData.Mode)
            {
                case ModeType.Mode2D:
                    _txtChangeMode.text = MODE_3D_TEXT;
                    OnChangeModeClick.Invoke(ModeType.Mode3D);
                    break;
                case ModeType.Mode3D:
                    _txtChangeMode.text = MODE_2D_TEXT;
                    OnChangeModeClick.Invoke(ModeType.Mode2D);
                    break;
                default:
                    throw new InvalidOperationException("Mode settings is wrong");
            }
        }
        private void ChangeWeather()
        {
            switch (_saveData.Weather)
            {
                case WeatherType.Sun:
                    _imgWeather.sprite = _sprWeatherCloudy;
                    OnWeatherClick.Invoke(WeatherType.Cloud);
                    break;
                case WeatherType.Cloud:
                    _imgWeather.sprite = _sprWeatherRainy;
                    OnWeatherClick.Invoke(WeatherType.Rain);
                    break;
                case WeatherType.Rain:
                    _imgWeather.sprite = _sprWeatherStorm;
                    OnWeatherClick.Invoke(WeatherType.Storm);
                    break;
                case WeatherType.Storm:
                    _imgWeather.sprite = _sprWeatherSunny;
                    OnWeatherClick.Invoke(WeatherType.Sun);
                    break;
                default:
                    throw new InvalidOperationException("Weather settings is wrong");
            }
        }

        #endregion
    }
}