# Simple C# Voice Assistant. 

## Set Language
Set your Language in Program.cs line 37
```csharp
var voiceRecognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("de-DE")); // For German
```
## Add Command

To Add A Command, simply create a new Class and Implement the Interface IVoiceCommand. 
This creates 3 Methods.
### GetCommandName
This should return the String, that you have to say on order for the Command to be executed.
Example: 
```csharp
public string GetCommandName()
{
    return "Test";
}// If I now say "test", the Command is Executed. 
```
### Execute
Put the Code, that is executed when the Command is triggered in here. 
```csharp
public void Execute()
{
	//Code in here
} 
```
### GetSpeek
This Method returns a String, which is Spoken, after the Command Executed. 
```csharp
public string GetSpeek()
{
    return "Executed Test Command";
}
```

## Register Command

To Register a Class, add it to the Collection of IVoiceCommand's in Program.cs Line 15:
```csharp
var commands = new List<IVoiceCommand>()
{
    new ChromeCommand(),
    new PlayCommand(),
    new PauseCommand(),
    new SkipCommand(),
	new YourCustomCommand(); // Your Class Name Here
};
```