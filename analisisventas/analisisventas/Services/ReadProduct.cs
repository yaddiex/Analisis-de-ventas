using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using analisisventas.Class;
using analisisventas.DateBase;
using CsvHelper;


namespace analisisventas.Services
{
    public class ReadProduct
    {
        private readonly string _pathFile; //atributo para almacenar la ruta del archivo CSV
        private ControlData ControlData = new ControlData();
        public ReadProduct(string pathFile) //constructor que recibe la ruta del archivo CSV
        {
            _pathFile = pathFile;
        }

        public void ReadProducto()
        {
            try
            {
                if (File.Exists(_pathFile))
                {
                    using (var reader = new StreamReader(_pathFile))
                    using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
                    {
                        var records = csv.GetRecords<products>().ToList();
                        foreach (var record in records)
                        {
                            Console.WriteLine($"ID: {record.ProductID}, Name: {record.ProductName}, Category: {record.Category}, Price: {record.Price}, Stock: {record.Stock}");
                        }
                        try
                        {
                            foreach (var record in records)
                            {
                                ControlData.Addproduct(record);
                            }
                            Console.WriteLine("Datos agregados a la base de datos correctamente.");
                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error al agregar el producto a la base de datos: {ex.Message}");
                        }
                    }
                }
                else
                {
                    throw new FileNotFoundException("El archivo no existe.", _pathFile);
                }

            }
            catch (Exception)
            { throw; }
}
}
}
