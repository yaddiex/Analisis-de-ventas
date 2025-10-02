using analisisventas.Services;

namespace analisisventas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
            

                ReadProduct ProductRead = new ReadProduct(@"C:\Users\Yaddie\OneDrive - Instituto Tecnológico de Las Américas (ITLA)\Francis Ramirez\Archivo CSV Análisis de Ventas-20250923\products.csv");
                 ProductRead.ReadProducto();

                
            }
            catch (ArgumentNullException aex)
            {
                Console.WriteLine($"Error: {aex.Message}");
            }
            catch (FileNotFoundException fex)
            {
                Console.WriteLine($"Error: {fex.Message}");
            }
        }
    }
}
