using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using DistinctWordCounterLibrary;

Console.Write("Введите путь к текстовому файлу (прим: C:\\Users\\Skylice\\Desktop\\voina.fb2): ");
var path = Console.ReadLine();
var text = string.Empty;
var time = string.Empty;
if (File.Exists(path))
{
    text = File.ReadAllText(path, Encoding.UTF8);
    Assembly assembly = Assembly.LoadFrom("DistinctWordCounterLibrary.dll");
    var type = assembly.GetType("DistinctWordCounterLibrary.DistinctWordCounter");
    var methodInfo = type.GetMethod("GetWordsQuantity",BindingFlags.NonPublic | BindingFlags.Instance);
    var instance = Activator.CreateInstance(type);
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    var resultDictionary = methodInfo.Invoke(instance, new object[] { text }) as Dictionary<string,int>;
    stopwatch.Stop();
    time = $"Usual method: {stopwatch.Elapsed.Minutes}:{stopwatch.Elapsed.Seconds}:{stopwatch.Elapsed.Milliseconds}";
    var asyncInstance = new DistinctWordCounter();
    stopwatch.Restart();
    var parallDict = asyncInstance.GetWordsQuantityInParallel(text);
    stopwatch.Stop();
    time = time + $"\tMethodInParallel: {stopwatch.Elapsed.Minutes}:{stopwatch.Elapsed.Seconds}:{stopwatch.Elapsed.Milliseconds}";
    Console.WriteLine(time);
    var curDir = new DirectoryInfo(Directory.GetCurrentDirectory());
    var finPath = curDir.FullName.Replace(curDir.Name, string.Empty) + $"{Path.GetFileName(path)
        .Split(new[] { ".txt", ".fb2", ".docx", ".doc", ".rtf" }, StringSplitOptions.RemoveEmptyEntries)[0]}_words.txt";
    File.WriteAllLines(finPath, resultDictionary.Select(x=> x.Key + ": " + x.Value).ToArray());
    Console.WriteLine($"Готово!\nМесторасположение созданного файла: {finPath}");
    Process.Start("explorer.exe", finPath);
}
else
{
    Console.WriteLine("Файл не найден!");
}
Console.ReadLine();