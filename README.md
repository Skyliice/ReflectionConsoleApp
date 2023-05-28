# ReflectionConsoleApp
Первое задание по Школе Инженера Digital Design. Реализацию по вступительному заданию разделить на 2 сборки: exe и dll. Exe читает файл, вызывает приватный метод из dll, передает ему текст из файла, получает результат и записывает его в файл. Dll содержит 1 класс и приватный метод, который принимает на вход текст, возвращает Dictionary<string, int>

## Реализация
### Задание 1.
В решении содержится консольное приложение, которое по указанному пользователем маршруту берет текстовый файл, и получает количество повторяющихся уникальных слов с помощью вызова приватного метода путем рефлексии из DistinctWordCounterLibrary.dll.

### Задание 2. 
В ветке [Задание_Многопоточность] добавлены публичные методы GetWordsQuantityInParallelWithPLinq и GetWordsQuantityInParallelWithParallerFor, отвечающие за параллельный подсчет слов. Скорость работы этих методов предоставлена ниже.
### Результат работы программы:
Задание 1

![Результат](https://github.com/Skyliice/DigitalDesign_TestTasks/blob/master/Screenshots/ConsoleAppScreenshot1.png)
Задание 2.

![Результат](https://github.com/Skyliice/ReflectionConsoleApp/blob/Задание_Многопоточность/Images/ScreenshotParallel.PNG)
