using System;

namespace VoiceAssistant
{
    public interface IVoiceCommand
    {
        string GetCommandName();
        void Execute();
        string GetSpeek();
    }
}