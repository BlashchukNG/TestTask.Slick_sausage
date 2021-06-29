namespace testtask.sausage
{
    [System.Serializable]
    public sealed class SaveData
    {
        public int Score;
        public int ColorID;
        public WeatherType Weather;
        public ModeType Mode;
        public MusicState Music;
    }
}