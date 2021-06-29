namespace testtask.sausage
{
    public interface ISaveLoadUtility
    {
        SaveData Load();
        void Save(SaveData save);
    }
}