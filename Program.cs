using System;
using System.Globalization;
using ExerFixacaoTrabalhandoComArquivos.Entities;
using System.IO;

namespace ExerFixacaoTrabalhandoComArquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file full path: ");
            string sourceFilePath = Console.ReadLine();

            try
            {
                string[] lines = File.ReadAllLines(sourceFilePath);

                string sourceFolderPath = Path.GetDirectoryName(sourceFilePath);
                string targetFolderPath = sourceFolderPath + @"\out";
                string targetFilePath = targetFolderPath + @"\summary.csv";

                Directory.CreateDirectory(targetFolderPath);

                using (StreamWriter sw = File.AppendText(targetFilePath))
                {
                    foreach (string line in lines)
                    {

                        string[] fields = line.Split(';');
                        string nameProduct = fields[0];
                        double priceProduct = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        int quantityProduct = int.Parse(fields[2]);

                        Product prod = new Product(nameProduct, priceProduct, quantityProduct);

                        sw.WriteLine(prod.NameProduct + "," + prod.PriceTotal().ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}