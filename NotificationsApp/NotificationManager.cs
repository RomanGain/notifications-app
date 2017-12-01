using System;
using System.Collections.Generic;
using System.Linq;

namespace NotificationsApp
{
    public class NotificationManager : INotificationManager
    {
        private List<string> returningSignals;

        private List<string> listOfEmails;
        private Dictionary<string, List<string>> listOfMatching;

        public NotificationManager()
        {
            try
            {
                listOfMatching = new Dictionary<string, List<string>>();

                //----------- Произвольное наполнение списка -------------------
                AddSignal("first_signal"); // Добавляем сигнал с пустым списком адресатов
                AddSignal("second_signal"); // Добавляем сигнал с пустым списком адресатов
                AddSignal("third_signal"); // Добавляем сигнал с пустым списком адресатов

                AddSignal("fourth_signal"); // Добавляем сигнал с пустым списком адресатов
                AddSignal("fifth_signal"); // Добавляем сигнал с пустым списком адресатов
                AddSignal("sixth_signal"); // Добавляем сигнал с пустым списком адресатов

                AddAddressForSignal("1@mail.com", "first_signal"); // Добавляем адрес для рассылки сигналом
                AddAddressForSignal("2@mail.com", "first_signal"); // Добавляем адрес для рассылки сигналом
                AddAddressForSignal("3@mail.com", "first_signal"); // Добавляем адрес для рассылки сигналом

                AddAddressForSignal("14@mail.com", "second_signal"); // Добавляем адрес для рассылки сигналом
                AddAddressForSignal("15@mail.com", "second_signal"); // Добавляем адрес для рассылки сигналом

                AddAddressForSignal("16@mail.com", "third_signal"); // Добавляем адрес для рассылки сигналом

                AddAddressForSignal("66@mail.com", "sixth_signal"); // Добавляем адрес для рассылки сигналом
                AddAddressForAllSignals("first_everybody@email.com"); // Добавляем адрес для рассылки всех сигналов
                AddAddressForAllSignals("second_everybody@email.com"); // Добавляем адрес для рассылки всех сигналов
                //---------------------------------------------------
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } // Конструктор класса

        public void ProcessSignal(string signal_code)
        {
            try
            {
                Console.WriteLine("Наступление сигнала \"{0}\". Рассылка уведомления следующим адресатам:", signal_code);

                foreach (string p in listOfMatching[signal_code])
                {
                    //Код рассылки уведомлений
                    Console.WriteLine(p);
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } // Обрабатывает сигнал 

        public void AddAddressForSignal(string email, string signal_code)
        {
            try
            {
                listOfMatching[signal_code].Add(email);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } // Добавляет адресата для сигнала

        public void AddAddressForAllSignals(string email)
        {
            try
            {
                foreach (KeyValuePair<string, List<string>> kvp in listOfMatching)
                {
                    kvp.Value.Add(email);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } // Добавляет адресата для всех сигналов

        public void ExcludeAddressFromSignal(string email, string signal_code)
        {
            try
            {
                listOfMatching[signal_code].Remove(email);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } // Исключает адресата из сигнала

        public void ExcludeAddressFromAllSignals(string email)
        {
            try
            {
                foreach (KeyValuePair<string, List<string>> kvp in listOfMatching)
                {
                    kvp.Value.Remove(email);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } // Исключает адресата из всех сигналов


        public List<string> GetListOfSupportedSignals()
        {
            try
            {
                returningSignals = new List<string>();
                foreach (string keys in listOfMatching.Keys)
                {
                    if (listOfMatching[keys].Any())
                    {
                        returningSignals.Add(keys);
                        Console.WriteLine(keys);
                    }
                }
                return returningSignals;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        } // Получает список поддерживаемых сигналов

        public void AddSignal(string signal_code)
        {
            try
            {
                listOfEmails = new List<string>();
                listOfMatching.Add(signal_code, listOfEmails);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } // Добавляет сигнал

        public bool CheckIfAddressWillGetNotification(string email, string signal_code)
        {
            try
            {
                if (listOfMatching[signal_code].Contains(email))
                    return true;
                else
                    return false;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        } // Проверяет будет ли адресат получать уведомление для сигнала
    }
}
