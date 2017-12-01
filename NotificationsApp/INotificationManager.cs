using System.Collections.Generic;

namespace NotificationsApp
{
    interface INotificationManager
    {
        void ProcessSignal(string signal_code); // Обрабатывает сигнал 

        void AddAddressForSignal(string email, string signal_code); // Добавляет адресата для сигнала

        void AddAddressForAllSignals(string email); // Добавляет адресата для всех сигналов

        void ExcludeAddressFromSignal(string email, string signal_code); // Исключает адресата из сигнала

        void ExcludeAddressFromAllSignals(string email); // Исключает адресата из всех сигналов

        List<string> GetListOfSupportedSignals(); // Получает список поддерживаемых сигналов

        void AddSignal(string signal_code); // Добавляет сигнал

        bool CheckIfAddressWillGetNotification(string email, string signal_code); // Проверяет будет ли адресат получать уведомление для сигнала
    }
}
