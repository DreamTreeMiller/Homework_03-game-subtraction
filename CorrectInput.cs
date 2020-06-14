using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_03
{
    class CorrectInput
    {

        int value;     // вводимое значение

        public CorrectInput()
        {
            this.value = 0;
        }

        /// <summary>
        /// Просит ввести число в заданном диапазоне, включая крайние значения.
        /// Реализована "защита от дурака"
        /// Возвращает введённое число
        /// </summary>
        /// <param name="introMessage">Сообщение, что надо ввести</param>
        /// <param name="outOfrangeMsg">Сообщение о выходе за пределы диапазона</param>
        /// <param name="minValue">Нижнее значение диапазона</param>
        /// <param name="maxValue">Вержнее значение диапазона</param>
        /// <returns></returns>
        public int Parse(string introMessage, string outOfrangeMsg,
                         int minValue, int maxValue)
        {
            bool isNumber;      // флаг, ввел ли игрок число, а не просто набор символов
            bool isInRange;     // флаг, число, введённое игроком, находятся в заданном диапазоне 

            #region Вводим уровень
            // Осуществляем "защиту от дурака" при вводе числа

            do
            {
                Console.Write($"\n{introMessage} от {minValue} до {maxValue:#,###,###,###}: ");
                isNumber = int.TryParse(Console.ReadLine(), out value);  //  вводим кол-во игроков
                isInRange = true;  // предполагаем, что оно в диапазоне от 2 до 10

                if (isNumber)     // введено числов ?
                {
                    // введено число, но надо проверить,
                    // оно в рамках диапазона minValue - maxValue
                    if ((value < minValue) || (maxValue < value))  
                    {
                        Console.WriteLine($"Ошибка! {outOfrangeMsg} от {minValue} до {maxValue:#,###,###,###}!");
                        isInRange = false;
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка! Вы должны ввести число!");
                }

            } while (!isNumber || !isInRange);    // Если введено не число, или число вне диапазона
                                                  // Вводим число заново
            #endregion
            // на выходе переменная inputValue содержит введённое значение
            return value;
        }
    }
}
