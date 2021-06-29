using System;


namespace testtask.sausage
{
    public interface IStartMenuView
    {
        event Action OnStartClick;
        event Action OnShopClick;
        event Action OnLeaderboardClick;
        event Action<MusicState> OnMusicClick;
        event Action<ModeType> OnChangeModeClick;
        event Action<WeatherType> OnWeatherClick;
    }
}