using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Domain.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public int RUT { get; set; }
        public char DV { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string eMail { get; set; }                

        public bool IsValid()
        {
            return
                IsRutValid(this.RUT, this.DV)
                && !string.IsNullOrWhiteSpace(this.FullName)
                && IsEmailValid(this.eMail);
        }

        public string Error_Messages()
        {
            var errors = new StringBuilder();

            if (!IsRutValid(this.RUT, this.DV))
                errors.AppendLine("RUT autor inválido");

            if (string.IsNullOrWhiteSpace(this.FullName))
                errors.AppendLine("Debe incluir un nombre de autor");

            if (!IsEmailValid(this.eMail))
                errors.AppendLine("Email de autor inválido");

            return errors.ToString();
        }

        private bool IsEmailValid(string email)
        {
            // TODO: complete
            return true;
        }

        private bool IsRutValid(int rut, char dv)
        {
            var calculated_dv = Calculate_DV(rut);

            return char.ToUpper(dv) == char.ToUpper(calculated_dv);
        }

        // Adapted from https://github.com/mrcoto/ChileanRut/blob/master/ChileanRut/RutUtil.cs
        private char Calculate_DV(int number)
        {
            int[] series = { 2, 3, 4, 5, 6, 7 };
            var sum = 0;
            var index = 0;
            while (number > 0)
            {
                sum += series[index] * (number % 10);
                number /= 10;
                index = index < series.Length - 1 ? index + 1 : 0;
            }

            var result = 11 - (sum % 11);

            if (result == 11)
                return '0';
            else if (result == 10)
                return 'K';
            else
                return result.ToString()[0];
        }
    }
}
