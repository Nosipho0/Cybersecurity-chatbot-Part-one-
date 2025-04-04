    using System;
    using System.IO;
    using System.Media;
    using System.Runtime.CompilerServices;

    namespace Cybersecuritychatbot
    {
    public class Audio
    {


        public Audio()
        {
            // Constructor body
            string project_location = AppDomain.CurrentDomain.BaseDirectory;

            //replacing the bin\Debug\netcoreapp3.1 with the audio folder
            string updated_path = project_location.Replace("bin\\Debug\\", "");
            string full_path = Path.Combine(updated_path, "audio.wav");

            //calling the play_wav method
            Play_wav(full_path);

        }

        internal void PlaySound()
        {
            throw new NotImplementedException();
        }

        private void Play_wav(string full_path)

        //try and catch block to handle exceptions
        {
            try
            {
                //instance of soundplayer class
                using (SoundPlayer player = new SoundPlayer(full_path))
                    //play the audio file
                    player.PlaySync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}



