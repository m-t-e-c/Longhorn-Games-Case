namespace PAC.Scripts.Runtime.Managers.SoundManager
{
    public interface ISoundManager
    {
        void PlaySound(string id);
        void PlayMusic(string clipName);
        void StopMusic();
        void StopSound();
    }
}