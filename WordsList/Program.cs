using System;
using System.Collections;
using static System.Console;
using System.IO;
using System.Text;
using System.Threading;


namespace WordsList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDictionary[] AllD = new MyDictionary[255];

            int flag = 0;
            while (flag == 0)
            {
                int choise = 0;
                WriteLine("1. Создать словарь\n2. Открыть словарь\n3. Выйти");
                choise = Convert.ToInt32(ReadLine());

                switch (choise) 
                {
                    case 1:
                        MyDictionary D = new MyDictionary();
                        string ch;
                        WriteLine("Язык ?");
                        ch = ReadLine();
                        D.Name = ch;
                        for (int i = 0; i < AllD.Length; i++)
                        {
                            if (AllD[i] == null)
                            {
                                AllD[i] = D;
                                break;
                            }
                        } 
                        break;

                    case 2: 
                        int cho = 0;
                        for (int i = 0; i < AllD.Length; i++)
                        {
                            if (AllD[i] == null) break; 
                            WriteLine($"{i + 1}. {AllD[i].Name}"); 
                        } 
                        cho = Convert.ToInt32(ReadLine());

                        int f = 0;
                        while (f == 0)
                        {
                            int chois = 0;
                            WriteLine("1. Добавить слово \n" +
                                "2. Удалить слово \n" +
                                "3. Поиск \n" +
                                "4. Редактировать слово \n" +
                                "5. Удалить все слова \n" +
                                "6. Показать все слова \n" + 
                                "7. Выход ");
                            chois = Convert.ToInt32(ReadLine());

                            switch (chois)
                            {
                                case 1: AllD[cho - 1].Add(); break;
                                case 2: AllD[cho - 1].DeleteWord(); break;
                                case 3: AllD[cho - 1].Search(); break;
                                case 4: AllD[cho - 1].Redact(); break;
                                case 5: AllD[cho - 1].Clear(); break;
                                case 6: AllD[cho - 1].Print(); break; 
                                case 7:
                                    AllD[cho - 1].WriteToFile();
                                    f++; 
                                    break;
                                default: WriteLine("Try again"); break;
                            }
                        } 
                        break;

                    case 3: Environment.Exit(0); break;  
                    default: WriteLine("Try again"); break;
                }
            } 
        }
    } 
}
