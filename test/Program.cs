BinarySearchGuess();


static void BinarySearchGuess()
{
    // 1. Встановити початкові межі: min = 1, max = 100.
    int min = 1;
    int max = 100;
    
    // 2. Створити цикл while, який працює поки min <= max.
    while (min <= max)
    {
        // 3. Обчислити mid = min + (max - min) / 2.
        int mid = min + (max - min) / 2;
        
        // 4. Вивести mid та запитати користувача: "Введене число більше (1), менше (-1) чи вгадано (0)?".
        Console.WriteLine($"Ваше число більше {mid} чи менше?");
        
        // 5. Зчитати введення.
        var answer = int.Parse(Console.ReadLine());
        
        // 6. Якщо введено 0: вивести повідомлення про успіх та перервати цикл (break).
        if (answer == 0)
        {
            Console.WriteLine("We guessed");
            break;
        } 
        // 7. Якщо введено 1: оновити min = mid + 1.
        // -> напишіть тут код, який вирішить пункт 7
        else if (answer == 1)
        {
            min = mid + 1;
        } 
        // 8. Якщо введено -1: оновити max = mid - 1.
        // -> напишіть тут код, який вирішить пункт 8
        else if (answer == -1)
        {
            max = mid - 1;
        }
        else
        {
            Console.WriteLine("Invalid input");
        }
    }
}