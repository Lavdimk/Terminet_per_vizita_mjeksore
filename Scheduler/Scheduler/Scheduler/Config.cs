namespace Scheduler
{
    static class Config
    {
        public static string Name { get; } = "KLINIKE";
        public static string PhoneNumber { get; } = "049 123 456";
        public static string EmailAddress { get; } = "info@klinike.com";
        public static string Address { get; } = "Rr. Tirana, 10000 Prishtine, Kosove";
        public static string AboutUs { get; } = "\nRreth Nesh\n\n" +
            "   Klinika jone ofron sherbime mjekesore\n" +
            "   ne mjekesi te pergjithshme, pediatri\n" +
            "   dhe dermatologji.\n\n" +
            $"   Telefoni: {PhoneNumber}\n" +
            $"   Email: {EmailAddress}\n" +
            $"   Adresa: {Address}\n" +
            $"   (c) 2022 {Name}\n";
    }
}
