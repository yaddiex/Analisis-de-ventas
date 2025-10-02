using analisisventas.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace analisisventas.DateBase
{
    public class ControlData
    {
        private readonly ConectionDB _context;

        public ControlData()
        {
            _context = new ConectionDB();
        }
        public void Addproduct(products products)
        {
           
                _context.Productos.Add(products);   // Prepara el insert
                _context.SaveChanges();          // Ejecuta en la BD
            }
        }
    }

