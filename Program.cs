﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_03
{
    class Program

    {
        static void Main(string[] args)
        {

            #region
            // Просматривая сайты по поиску работы, у вас вызывает интерес следующая вакансия:

            // Требуемый опыт работы: без опыта
            // Частичная занятость, удалённая работа
            //
            // Описание 
            //
            // Стартап «Micarosppoftle» занимающийся разработкой
            // многопользовательских игр ищет разработчиков в свою команду.
            // Компания готова рассмотреть C#-программистов не имеющих опыта в разработке, 
            // но желающих развиваться в сфере разработки игр на платформе .NET.
            //
            // Должность Интерн C#/
            //
            // Основные требования:
            // C#, операторы ввода и вывода данных, управляющие конструкции 
            // 
            // Конкурентным преимуществом будет знание процедурного программирования.
            //
            // Не технические требования: 
            // английский на уровне понимания документации и справочных материалов
            //
            // В качестве тестового задания предлагается решить следующую задачу.
            //
            // Написать игру, в которою могут играть два игрока.
            // При старте, игрокам предлагается ввести свои никнеймы.
            // Никнеймы хранятся до конца игры.
            // Программа загадывает случайное число gameNumber от 12 до 120 сообщая это число игрокам.
            // Игроки ходят по очереди(игра сообщает о ходе текущего игрока)
            // Игрок, ход которого указан вводит число userTry, которое может принимать значения 1, 2, 3 или 4,
            // введенное число вычитается из gameNumber
            // Новое значение gameNumber показывается игрокам на экране.
            // Выигрывает тот игрок, после чьего хода gameNumber обратилась в ноль.
            // Игра поздравляет победителя, предлагая сыграть реванш
            // 
            // * Бонус:
            // Подумать над возможностью реализации разных уровней сложности.
            // В качестве уровней сложности может выступать настраиваемое, в начале игры,
            // значение userTry, изменение диапазона gameNumber, или указание большего количества игроков (3, 4, 5...)

            // *** Сложный бонус
            // Подумать над возможностью реализации однопользовательской игры
            // т е игрок должен играть с компьютером


            // Демонстрация
            // Число: 12,
            // Ход User1: 3
            //
            // Число: 9
            // Ход User2: 4
            //
            // Число: 5
            // Ход User1: 2
            //
            // Число: 3
            // Ход User2: 3
            //
            // User2 победил!

            #endregion

            CorrectInput correctInput = new CorrectInput(); // создаём класс с методом проверки правильности 

            int numberOfplayers;       // количество игроков, от 2 до 10  
            int currPlayer;            // игрок, делающий ход
            string[] playersNames;     // Массив имён игроков. 
                                       // для удобства будет считать его от 1 до numberOfplayers

            int maxRandNumber;         // максимально возможное значение случайного числа 
                                       // от 12 до 1,000,000,000
                                       // = 120 - условие самой первой задачи

            int maxTry;               // максимальное число одного хода (от 2 до половины maxRandNumber)
                                      // в начале = 4 - условие самой первой задачи
                                      // 0 вводить нельзя. 1 - нельзя, т.к. нет смысла играть
                                      // должно быть хотя бы 2

            int userTry;              // число, вводимое очередным игроком

            int level;                 // уровень сложности от 1 до 4 и опция 5 - игра с компьютером
                                       // Уровень 1 - два игрока. Начальное число от 12 до 120. Макс ход - 4
                                       // Уровень 2 - два игрока. Начальное число от 12 до 120. Выбираем макс ход
                                       // Уровень 3 - два игрока. Выбираем макс начальное число. Вибираем макс ход
                                       // Уровень 4 - Выбираем кол-во игроков, макс начальное число и макс ход
                                       // Опция 5 - два игрова - вы против компьютера

            char continueGame;           //  флаг продолжать игру или останавливать



            do
            {

                #region One iteration of the game

                // инициализируем переменные 
                numberOfplayers = 2;   // по умлочанию количество игроков 2   
                maxRandNumber = 120;   // макс возможное значение случайного числа 
                maxTry = 4;            // максимальное число одного хода (от 2 до половины maxRandNumber)
                level = 1;             // уровень сложности от 1 до 4 и опция 5 - игра с компьютером

                Console.WriteLine("\n<<< *** === Игра \"Кто первый!\" приветствует вас! === *** >>>\n\n" +
                "Суть игры: компьютер выбирает и называет случайное чило между 12 и 120. \n" +
                "Игроки, по очереди, вводят числа от 1 до 4,\n" +
                "которые вычитаются из изначального, а потом из оставшегося, числа, пока не получится 0.\n" +
                "Выиграл тот, кто ввёл последнее число.\n");

                Console.WriteLine("Уровни сложности\n" +
                      "Уровень 1 - два игрока. Начальное число от 12 до 120. Макс. ход - 4\n" +
                      "Уровень 2 - два игрока. Начальное число от 12 до 120. Выбираем макс. ход\n" +
                      "Уровень 3 - два игрока. Выбираем макс. начальное число. Вибираем макс. ход\n" +
                      "Уровень 4 - Выбираем кол-во игроков, макс. начальное число и макс. ход\n" +
                      "Опция 5 - два игрова - вы против компьютера. Выбираете макс. начальное число и макс. ход\n");

                // Вводим уровень сложности
                level = correctInput.Parse("Выберите уровень", "Введите число", 1, 5);

                if (level == 4)
                {
                    // Вводим количество игроков, для уровня 4
                    numberOfplayers = correctInput.Parse("Ведите количество игроков",
                                                         "Число игроков может быть",
                                                         2, 10);
                }

                #region Вводим имена игроков

                playersNames = new string[numberOfplayers];

                if (level == 5)
                {
                    string firstMove;
                    // играем с компьютером
                    Console.Write("Введите 1, если хотите ходить первым, или что угодно, если вторым: ");
                    firstMove = Console.ReadLine();

                    Console.Write($"\nВведите своё имя: ");
                    playersNames[0] = Console.ReadLine();

                    if (firstMove == "1")
                    {
                        playersNames[1] = "Компьютер";
                    }
                    else
                    {
                        playersNames[1] = playersNames[0];
                        playersNames[0] = "Компьютер";
                    }

                }
                else
                {
                    // играют люди. вводим их имена
                    for (currPlayer = 1; currPlayer <= numberOfplayers; currPlayer++)
                    {
                        Console.Write($"\nВведите имя {currPlayer}-го игрока: ");
                        playersNames[currPlayer - 1] = Console.ReadLine();
                    }
                }
                #endregion
                // на выходе в массиве playersNames содержатся имена игроков

                // Устанавливаем максимально возможное значение случайного числа
                // В зависимости от уровня это либо 120, либо введённое пользователем
                if ((level == 3) || (level == 4) || (level == 5))
                {
                    maxRandNumber = correctInput.Parse("Ведите максимально возможное значение случайного числа",
                                                       "Максимальное значение числа может быть",
                                                       12, 1_000_000_000);
                }

                // генерируем случайное число от 12 до maxRandNumber
                Random rand = new Random();
                int gameNumber = rand.Next(12, maxRandNumber + 1);

                Console.WriteLine($"\nИсходное число: {gameNumber}");

                // Устанавливаем максимальную величину хода
                // Это либо 4 для 1 уровня, либо введённое пользователем для всех остальных
                if (level != 1)
                {
                    maxTry = correctInput.Parse("Ведите максимальную величину хода",
                                             "Максимальная величина хода может быть",
                                             2, gameNumber / 2);
                }

                currPlayer = 0;   // инициализируем счётчик игроков

                // Цикл самой игры
                do
                {
                    Console.WriteLine($"\nЧисло: {gameNumber}");

                    if ((level == 5) && (playersNames[currPlayer] == "Компьютер"))
                    {
                        #region Алгоритм победы компьютера
                        // Наверняка есть разные стратегии победы. Предлагаю следующую, которая
                        // при определённом начальном состоянии всегда будет приводить к победе,
                        // какой бы после этого ход ни делал противник.
                        // 
                        // Если gameNumber == Reminder + N * (maxTry + 1), где N - некое целое число >= 0,
                        // а Reminder - остаток от деления gameNumber (maxTry + 1), т.е. <= maxTry
                        // И если Reminder > 0, то ходом компьютера как раз и будет Reminder.
                        // Потому что, какой бы после этого ход ни сделал второй игрок, при ходе компа
                        // новое gameNumber будет выражено той же самой формулой, но уже N = N -1.
                        // Перед последним ходом, который будет ходом компьютера, gameNumber будет уже <= maxTry.
                        //
                        // Единственный вариант, когда компьютер может проиграть, если Reminder всегда == 0
                        // Тогда комп будет просто генерировать случ. число (в допустимых рамках) для своего хода
                        // и ждать, когда противник совешит ошибку и введёт такое число, чтобы новое gameNumber
                        // стало удовлетворять формуле выше.


                        userTry = (gameNumber % (maxTry + 1) > 0) ? gameNumber % (maxTry + 1) : rand.Next(1, maxTry + 1);
                        
                        Console.WriteLine($"\nХод компьютера: {userTry}");
                        #endregion
                    }
                    else
                    {
                        // Игрок currPlayer вводит число
                        userTry = correctInput.Parse($"Ход игрока {playersNames[currPlayer]} ",
                                                  "Вы должны ввести число", 1, maxTry);
                    }

                    gameNumber -= userTry;

                    // проверяем, не стал ли максимально возможный ход меньше изначально заданного,
                    // по причине уменьшения числа в игре
                    maxTry = (gameNumber >= maxTry) ? maxTry : gameNumber;

                    // проверяем - это ход последнего игрока, если да, то сбрасываем счётчик игроков
                    // Если нет, то выбираем следующего игрока
                    currPlayer = (currPlayer == (numberOfplayers - 1)) ? 0 : currPlayer + 1;

                } while (gameNumber > 0);

                // currPlayer содержит № + 1 победившего игрока
                // если победитель - последний игрок, то прозошёл сброс на 0 счётчика игроков
                // поэтому возвращаем счётчик на последнего игрока
                currPlayer = (currPlayer == 0) ? numberOfplayers - 1 : currPlayer - 1;

                // выводим имя победителя
                Console.WriteLine($"\nПобедил игрок {playersNames[currPlayer]} !!!");
                #endregion One iteration of the game

                Console.Write("\nХотите сыграть ещё?\n" + 
                              "Если да - нажмите Y. Если нет - любую другую клавишу.\n" +
                              "Потом нажмите 'Ввод'");
                continueGame = Console.ReadLine()[0];
            } while ((continueGame == 'Y') ||       //  большая
                     (continueGame == 'y') ||       //  маленькая
                     (continueGame == 'Н') ||       //  на русской раскладке
                     (continueGame == 'н'));        //  маленькая на русской раскладке


        } // Main
    }   // Class program
}   // namespace 
