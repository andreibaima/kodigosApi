using System;

namespace kodigos.api.Models
{
    public class Produto 
    {

        public Produto()
        {
            // TIRAR O GUID
            // id = Guid.NewGuid();
            id = 0;
        }

        // Guid GERA UM ID DE FORMA NÃO SEQUENCIAL
        public int id { get; set; }

        public string nome { get; set; }

        public string descricao { get; set; }

        public string uniMedida { get; set; }

    }
}