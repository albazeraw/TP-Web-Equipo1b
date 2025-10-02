using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace dominio
{
    public class cliente
    {
        public int Id { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public int CP { get; set; }

        public bool EsValido()
        {
            return string.IsNullOrEmpty(ValidarDatos());
        }

        public string ValidarDatos()
        {
            // Validar DNI (7-8 dígitos numéricos)
            if (string.IsNullOrWhiteSpace(Documento))
                return "El documento es obligatorio";
            
            if (!Regex.IsMatch(Documento, @"^\d{7,8}$"))
                return "El documento debe tener entre 7 y 8 dígitos numéricos";

            // Validar Nombre (mínimo 2 caracteres)
            if (string.IsNullOrWhiteSpace(Nombre))
                return "El nombre es obligatorio";
            
            if (Nombre.Trim().Length < 2)
                return "El nombre debe tener al menos 2 caracteres";

            // Validar Apellido (mínimo 2 caracteres)
            if (string.IsNullOrWhiteSpace(Apellido))
                return "El apellido es obligatorio";
            
            if (Apellido.Trim().Length < 2)
                return "El apellido debe tener al menos 2 caracteres";

            // Validar Email (formato válido)
            if (string.IsNullOrWhiteSpace(Email))
                return "El email es obligatorio";
            
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(Email, emailPattern))
                return "El formato del email no es válido";

            // Validar Dirección
            if (string.IsNullOrWhiteSpace(Direccion))
                return "La dirección es obligatoria";

            // Validar Ciudad
            if (string.IsNullOrWhiteSpace(Ciudad))
                return "La ciudad es obligatoria";

            // Validar Código Postal
            if (CP <= 0)
                return "El código postal debe ser un número válido mayor a 0";

            return string.Empty; // No hay errores
        }
    }
}
