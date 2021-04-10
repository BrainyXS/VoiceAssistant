using System.Diagnostics;

namespace VoiceAssistant.Commands.Generals
{
    public class ChromeCommand : IVoiceCommand
    {
        public string GetCommandName()
        {
            return "Chrome";
        }

        public void Execute()
        {
            Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe");
        }

        public string GetSpeek()
        {
            return "Starte Google Chrome";
        }
    }
}