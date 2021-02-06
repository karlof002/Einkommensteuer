
using System;

namespace TaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double grossSalary;         //Bruttogehalt
            double remainingSalary;     //Hier wird nach jeder Tarifstufe der noch zu versteuernde Restwert gespeichert (Bsp. 50.000 € ersten 11.000 € steuerfrei --> remainingSalary nach 1. Stufe = 39.000 €)
            double actValue;            //Hier wird der jeweilige Wert je Einkommenstufe (Tarifstufe) zwischengespeichert
            double netSalary;
            double tax;
            string input;

            Console.WriteLine("Einkommensteuer-Rechner!");
            Console.Write("Bruttoeinkommen eingeben: ");

            input = Console.ReadLine();             //Bruttoeinkommen einlesen und in string-Variable speichern
            grossSalary = Convert.ToInt32(input);   //Wert aus der string-Varialbe (input) in double Variable (grossSalary) konvertieren

            //Die ersten 11000 sind steuerfrei
            actValue = Math.Min(11000, grossSalary);  //Bis zu 11.000 € sind steurfrei. Wenn aber z.B. nur 7.000 verdient wurden, sind natürlich nur 7000 € steuerfrei. Daher Math.Min(11000,grossSalary)
            remainingSalary = grossSalary - actValue;  
            tax = 0; //noch keine Steuer für die ersten 11.000 €

            //Die nächsten 7000 werden mit 25% versteuert
            actValue = Math.Min(7000, remainingSalary);  //Die nächsten 7.000 € sind mit 25% zu versteuern. Wenn nur noch 5000 € übrig sind, natürlich nur 5000 € mit 25% versteuern 
            remainingSalary = remainingSalary - actValue;
            tax=tax+actValue*0.25;

            //Die nächsten 13000 werden mit 35% versteuert
            actValue = Math.Min(13000, remainingSalary);
            remainingSalary = remainingSalary - actValue;
            tax =tax+ actValue * 0.35;

            //Die nächsten 29000 werden mit 42% versteuert
            actValue = Math.Min(29000, remainingSalary);
            remainingSalary = remainingSalary - actValue;
            tax =tax+ actValue * 0.42;

            //Die nächsten 30000 werden mit 48% versteuert
            actValue = Math.Min(30000, remainingSalary);
            remainingSalary = remainingSalary - actValue; 
            tax =tax+ actValue * 0.48;

            //Die nächsten 910000 werden mit 50% versteuert
            actValue = Math.Min(910000, remainingSalary);
            remainingSalary = remainingSalary - actValue;
            tax = tax+actValue * 0.50;

            //Der Rest darüber wrd mit 55% versteuert
            tax = tax+ remainingSalary * 0.55;

            netSalary = grossSalary - tax;

            //Ausgabe
            Console.WriteLine();
            Console.WriteLine("Bruttoeinkommen: "+grossSalary);
            Console.WriteLine("Einkommensteuer: "+tax);
            Console.WriteLine("Nettoeinkommen:  "+netSalary);

            Console.WriteLine("\n<Taste drücken>");
            Console.ReadKey();
        }
    }
}
