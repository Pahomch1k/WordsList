using System;
using System.Collections;
using static System.Console;
using System.IO;
using System.Text;
using System.Threading;

namespace WordsList
{
    class MyDictionary
    {
        SortedList mySL = new SortedList();

        public string Name { get; set; }

        public MyDictionary() { }

        public MyDictionary(string n)
        {
            Name = n;
        }

        public void Add()
        {
            string str1, str2;

            Write("Слово - ");
            str1 = ReadLine();
            Write("Перевод - ");
            str2 = ReadLine();

            mySL.Add(str1, str2);
        }

        public void Search()
        {
            string str1;
            int ch = 0;
            Write("Поиск по 1 - слову или 2- переводу?");
            ch = Convert.ToInt32(ReadLine());
            if (ch == 1)
            {
                Write("Слово - ");
                str1 = ReadLine();
            }
            else
            {
                Write("Перевод - ");
                str1 = ReadLine();
            }

            for (int i = 0; i < mySL.Count; i++)
                if (mySL.GetKey(i) == str1)
                    WriteLine($"\t{mySL.GetKey(i)}:\t{mySL.GetByIndex(i)}");
        }

        public void Redact()
        {
            string str1, str2;
            int ch = 0;
            Write("Поиск по 1 - слову или 2- переводу?");
            ch = Convert.ToInt32(ReadLine());
            if (ch == 1)
            {
                Write("Слово - ");
                str1 = ReadLine();
            }
            else
            {
                Write("Перевод - ");
                str1 = ReadLine();
            }

            for (int i = 0; i < mySL.Count; i++)
                if (mySL.GetKey(i) == str1)
                {
                    WriteLine($"\t{mySL.GetKey(i)}:\t{mySL.GetByIndex(i)}");
                    Write($"Заменить на ? ");
                    str2 = ReadLine();
                    mySL.SetByIndex(mySL.IndexOfKey(i), str2);
                }
        }

        public void DeleteWord()
        {
            string str1;

            Write("Слово - ");
            str1 = ReadLine();

            mySL.Remove(str1);

            WriteToFile();
        }

        public void Clear()
        {
            mySL.Clear();
        }

        public void Print()
        {
            WriteLine("\t-Слово-\t-Перевод-");
            for (int i = 0; i < mySL.Count; i++)
                WriteLine($"\t{mySL.GetKey(i)}:\t{mySL.GetByIndex(i)}");
            WriteLine();
        }
          
        public void WriteToFile()
        {
            StreamWriter sw = new StreamWriter($"{Name}_D.txt", true);
            string line;

            // Считываем строку с клавиатуры
            line = "\t-Слово-\t-Перевод-";
            // Записываем строку в файл
            sw.WriteLine(line);

            for (int i = 0; i < mySL.Count; i++)
            {
                line = $"\t{mySL.GetKey(i)}:\t{mySL.GetByIndex(i)}";
                sw.WriteLine(line);
            }
            sw.Close();
        }

        public void ReadInFile()
        {
            StreamReader sr = new StreamReader("Dictionary.txt", Encoding.UTF8);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                WriteLine(line);
                Thread.Sleep(100);
            }
            sr.Close();
        }
    }
} 