#region Includes
using Microsoft.Xna.Framework.Audio;
#endregion

namespace ShooterGame200
{
    public class SoundControl
    {
        public SoundEffect sound;
        public SoundEffectInstance instance;
        public float volume;


        public SoundControl(string MUSICPATH)
        {
            sound = null;
            instance = null;

            if (MUSICPATH != "")
            {
                ChangeMusic(MUSICPATH);
            }
        }

        public virtual void ChangeMusic(string MUSICPATH)
        {
            sound = Globals.content.Load<SoundEffect>(MUSICPATH);
            instance = sound.CreateInstance();
            volume = .25f;

            instance.Volume = volume;
            instance.IsLooped = true;
            instance.Play();

        }
    }
}
