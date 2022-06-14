using Westwind.Globalization;
using Newtonsoft.Json;
using IronOcr;
using System.Text.RegularExpressions;
using System.Speech.Synthesis;
using System.Speech.AudioFormat;

Console.WriteLine("Translating entity names into russian one");
//TranslationServices service = new TranslationServices();

//List<string[]>[] entities =
//{
//    new List<string[]>
//    {
//        new string[] { "Department" },
//        new string[] {"DepartmentName", "DepartmentDescription"},
//    },
//    new List<string[]>
//    {
//        new string[] { "Groups" },
//        new string[] {"GroupName", "GroupSpeciality"},
//    },
//    new List<string[]>
//    {
//        new string[] { "Users" },
//        new string[] {"UserLogin", "UserFIO", "UserPassword"},
//    },
//    new List<string[]>
//    {
//        new string[] { "UserRoles" },
//        new string[] {"RoleName", "UserRoleID"},
//    }
//};
//var Result = new IronOcr.IronTesseract().Read("ocr_test.png").Text;
//var Result2 = new IronOcr.IronTesseract().Read("Безымянный.png").Text;

////Console.WriteLine(Result);
//Console.WriteLine(Result2);

//Console.WriteLine();
////Console.WriteLine(service.TranslateGoogle(Result, "en", "ru"));
//var a = Regex.Replace(Result2, "(?i)[^А-ЯЁA-Z]", "");

//Console.WriteLine();
//Console.WriteLine(a);
//Console.WriteLine();

//a = (service.TranslateGoogle(a, "en", "ru"));
//Console.WriteLine();
//foreach (var item in a.Split(' ')) { Console.WriteLine(item); Thread.Sleep(2000); }
//Console.WriteLine();
//Console.WriteLine(a);
// Initialize a new instance of the SpeechSynthesizer.  
var syn = new System.Speech.Synthesis.SpeechSynthesizer();
syn.SelectVoice(name: "Microsoft David Desktop");
syn.Speak("Hello there");

Console.WriteLine("Press any key to exit...");
Console.ReadKey();
Console.ReadKey();

static byte[] StartSpeak(string word)
{
    var ms = new MemoryStream();
    using (System.Speech.Synthesis.SpeechSynthesizer synhesizer = new System.Speech.Synthesis.SpeechSynthesizer())
    {
        foreach (var voice in synhesizer.GetInstalledVoices())
        {
            Console.WriteLine("select(y/n): " + voice.VoiceInfo.Name);
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Y)
            {
                synhesizer.SelectVoice(voice.VoiceInfo.Name);
                synhesizer.SelectVoiceByHints(voice.VoiceInfo.Gender, voice.VoiceInfo.Age, 1, voice.VoiceInfo.Culture);
                synhesizer.SetOutputToWaveStream(ms);
                synhesizer.Speak(word);
            }
        }
    }

    return ms.ToArray();
}