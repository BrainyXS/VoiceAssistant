using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using VoiceAssistant.Commands.Generals;

namespace VoiceAssistant
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var commands = new List<IVoiceCommand>()
            {
                new ChromeCommand(),
                new PlayCommand(),
                new PauseCommand(),
                new SkipCommand()
            };

            var choices = new Choices();
            var synthesizer = new SpeechSynthesizer();
            synthesizer.SetOutputToDefaultAudioDevice();

            foreach (var t in commands)
            {
                choices.Add(t.GetCommandName());
            }

            var gBuilder = new GrammarBuilder();
            gBuilder.Append(choices);
            var grammar = new Grammar(gBuilder);
            grammar.Name = "Commands";

            var voiceRecognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("de-DE"));
            voiceRecognizer.LoadGrammar(grammar);
            voiceRecognizer.LoadGrammar(new DictationGrammar());

            voiceRecognizer.SetInputToDefaultAudioDevice();
            voiceRecognizer.SpeechRecognized += (sender, eventArgs) =>
            {
                Console.WriteLine(eventArgs.Result.Text);
                if (eventArgs.Result.Grammar.Name != "Commands") return;
                var command = commands.Single(c => c.GetCommandName().Equals(eventArgs.Result.Text));
                command.Execute();
                synthesizer.Speak(command.GetSpeek());
            };

            voiceRecognizer.RecognizeAsync(RecognizeMode.Multiple);
            Task.Delay(-1).GetAwaiter().GetResult();
        }
        
    }
    
}