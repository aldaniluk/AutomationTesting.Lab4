namespace Selenium
{
    public enum RulesEnum 
    {
        general,
        documents,
        process,
        payment,
        delivery,
        moneyback,
        exchange,
        contact
    }

    public static class SectionName
    {
        public static string Get(RulesEnum rules)
        {
            switch (rules)
            {
                case RulesEnum.general:
                    return "Общие положения";
                case RulesEnum.documents:
                    return "Необходимые документы";
                case RulesEnum.process:
                    return "Процесс заказа авиабилетов";
                case RulesEnum.payment:
                    return "Способ оплаты авиабилетов";
                case RulesEnum.delivery:
                    return "Получение авиабилетов";
                case RulesEnum.moneyback:
                    return "Возврат билетов";
                case RulesEnum.exchange:
                    return "Обмен билетов";
                case RulesEnum.contact:
                    return "Контакты";
            }

            return "";
        }
    }
}